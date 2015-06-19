using System;
using System.Collections.Generic;
using System.Linq;

namespace ColdFlame
{

    static class EntityManager
    {

        public delegate void EntityEventHandler(Entity entity, string eventType);
        public static EntityEventHandler EntityEvent;
        private static Dictionary<int, List<Component>> _entityList = new Dictionary<int, List<Component>>();
        private static int lowestUUID { get; set; }

        public static int generateUUID()
        {
            if (lowestUUID < int.MaxValue)
            {
                return lowestUUID ++;
            }
            for (int i = 0; i < int.MaxValue; i++)
            {
                List<Component> value;
                if (!_entityList.TryGetValue(i, out value))
                {
                    return i;
                }
            }
            throw new Exception("Cannot create new UUID");
        }

        public static void addComponent(int entityUUID, Component component)
        {
            List<Component> value;
            _entityList.TryGetValue(entityUUID, out value);
            value.Add(component);
            EntityEvent(new Entity(entityUUID), "New Component");
        }

        public static void addComponent(int entityUUID, List<Component> componentList)
        {
            EntityEvent(new Entity(entityUUID), "New Component");
            throw new NotImplementedException();
        }

        public static void addEntity(Entity entity)
        {
            _entityList.Add(entity.uuid, new List<Component>());
            EntityEvent(entity, "New Entity");
        }

        public static List<Component> getComponents(int entityUUID)
        {
            List<Component> components;
            _entityList.TryGetValue(entityUUID, out components);
            return components;
        }

        public static Component getComponent(int entityUUID, Type comType)
        {
            List<Component> components;
            _entityList.TryGetValue(entityUUID, out components);
            foreach (Component item in components)
            {
                if (item.GetType().Equals(comType))
                {
                    return item;
                }
            }
            return components[0];
        }

        public static List<int> getEntityList()
        {
            return _entityList.Keys.ToList<int>();
        }

        public static bool containsComponent(int entityUUID, Type comType)
        {
            List<Component> componentList;
            if (_entityList.TryGetValue(entityUUID, out componentList))
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