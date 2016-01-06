using System;
using System.Collections.Generic;
using System.Linq;

namespace ColdFlame
{
    internal static class EntityManager
    {
        public delegate void EntityEventHandler(Entity entity, string eventType);

        public static EntityEventHandler EntityEvent;
        private static readonly Dictionary<Guid, List<Component>> EntityList = new Dictionary<Guid, List<Component>>();

        internal static Guid GenerateGuid()
        {
            return Guid.NewGuid();
        }

        internal static void AddComponent(Guid entityGuid, Component component)
        {
            List<Component> value;
            EntityList.TryGetValue(entityGuid, out value);
            value.Add(component);
            EntityEvent(new Entity(entityGuid), "New Component");
        }

        internal static void RemoveComponent(Guid entityGUID, Component component)
        {
            EntityList[entityGUID].Remove(component);
            EntityEvent(new Entity(entityGUID), "Removed Component");
        }

        internal static void AddComponent(Guid entityGuid, IEnumerable<Component> componentList)
        {
            List<Component> value;
            EntityList.TryGetValue(entityGuid, out value);
            value.AddRange(componentList);
            EntityEvent(new Entity(entityGuid), "New Component");
        }

        internal static void AddEntity(Entity entity)
        {
            EntityList.Add(entity.Guid, new List<Component>());
            EntityEvent(entity, "New Entity");
        }

        internal static List<Component> GetComponents(Guid entityGuid)
        {
            List<Component> components;
            EntityList.TryGetValue(entityGuid, out components);
            return components;
        }

        internal static List<Component> GetComponents(Guid entityGuid, Type comType)
        {
            List<Component> components;
            EntityList.TryGetValue(entityGuid, out components);
            return components.Where(item => item.GetType() == comType).ToList();
        }

        internal static Component GetComponent(Guid entityGuid, Type comType)
        {
            List<Component> components;
            EntityList.TryGetValue(entityGuid, out components);
            foreach (var item in components.Where(item => item.GetType() == comType))
            {
                return item;
            }
            return components[0];
        }

        internal static List<Guid> GetEntityList()
        {
            return EntityList.Keys.ToList();
        }

        internal static bool ContainsComponent(Guid entityGuid, Type comType)
        {
            List<Component> componentList;
            return EntityList.TryGetValue(entityGuid, out componentList) && componentList.Any(c => comType == c.GetType());
        }
    }
}