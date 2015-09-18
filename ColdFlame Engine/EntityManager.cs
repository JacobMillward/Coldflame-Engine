using System;
using System.Collections.Generic;
using System.Linq;

namespace ColdFlame
{

    internal static class EntityManager
    {

        public delegate void EntityEventHandler(Entity entity, string eventType);
        public static EntityEventHandler EntityEvent;
        private static Dictionary<Guid, List<Component>> _entityList = new Dictionary<Guid, List<Component>>();

        public static Guid generateGUID()
        {
            return Guid.NewGuid();
        }

        public static void addComponent(Guid entityGUID, Component component)
        {
            List<Component> value;
            _entityList.TryGetValue(entityGUID, out value);
            value.Add(component);
            EntityEvent(new Entity(entityGUID), "New Component");
        }

        public static void addComponent(Guid entityGUID, List<Component> componentList)
        {
            List<Component> value;
            _entityList.TryGetValue(entityGUID, out value);
            foreach(Component component in componentList)
            {
                value.Add(component);
            }
            EntityEvent(new Entity(entityGUID), "New Component");
        }

        public static void addEntity(Entity entity)
        {
            _entityList.Add(entity.guid, new List<Component>());
            EntityEvent(entity, "New Entity");
        }

        public static List<Component> getComponents(Guid entityGUID)
        {
            List<Component> components;
            _entityList.TryGetValue(entityGUID, out components);
            return components;
        }

        public static List<Component> getComponents(Guid entityGUID, Type comType)
        {
            List<Component> components;
            List<Component> matchedComponents = new List<Component>();
            _entityList.TryGetValue(entityGUID, out components);
            foreach (Component item in components)
            {
                if (item.GetType().Equals(comType))
                {
                    matchedComponents.Add(item);
                }
            }
            return matchedComponents;
        }

        public static Component getComponent(Guid entityGUID, Type comType)
        {
            List<Component> components;
            _entityList.TryGetValue(entityGUID, out components);
            foreach (Component item in components)
            {
                if (item.GetType().Equals(comType))
                {
                    return item;
                }
            }
            return components[0];
        }

        public static List<Guid> getEntityList()
        {
            return _entityList.Keys.ToList<Guid>();
        }

        public static bool containsComponent(Guid entityGUID, Type comType)
        {
            List<Component> componentList;
            if (_entityList.TryGetValue(entityGUID, out componentList))
            {
                foreach (Component c in componentList)
                {
                    if (comType.Equals(c.GetType()))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}