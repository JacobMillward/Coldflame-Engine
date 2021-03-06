using System;
using System.Collections.Generic;
using System.Linq;
using ColdFlame.Events;

namespace ColdFlame
{
    internal static class EntityManager
    {
        public delegate void EntityEventHandler(EntityEventData eventData);

        public static EntityEventHandler EntityEvent;
        private static readonly Dictionary<Guid, List<Component>> EntityList = new Dictionary<Guid, List<Component>>();

        internal static Guid GenerateGuid()
        {
            return Guid.NewGuid();
        }

        internal static void AddComponent(Guid entityGuid, Component component)
        {
            List<Component> value;
            if (EntityList.TryGetValue(entityGuid, out value))
            {
                value.Add(component);
            }
            EntityEvent(new EntityEventData(EntityEventType.NewComponent, new Entity(entityGuid), component));
        }

        internal static void RemoveComponent(Guid entityGuid, Component component)
        {
            EntityList[entityGuid].Remove(component);
            EntityEvent(new EntityEventData(EntityEventType.RemovedComponent, new Entity(entityGuid), component));
        }

        internal static void AddComponent(Guid entityGuid, IEnumerable<Component> componentList)
        {
            List<Component> value;
            var collection = componentList as IList<Component> ?? componentList.ToList();
            if (EntityList.TryGetValue(entityGuid, out value))
            {
                value.AddRange(collection);
            }
            foreach (var c in collection)
            {
                EntityEvent(new EntityEventData(EntityEventType.NewComponent, new Entity(entityGuid), c));
            }
        }

        internal static void AddEntity(Entity entity)
        {
            EntityList.Add(entity.Guid, new List<Component>());
            EntityEvent(new EntityEventData(EntityEventType.NewEntity, entity, null));
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
            return EntityList.TryGetValue(entityGuid, out components)
                ? components.Where(item => item.GetType() == comType).ToList()
                : null;
        }

        internal static Component GetComponent(Guid entityGuid, Type comType)
        {
            List<Component> components;
            return !EntityList.TryGetValue(entityGuid, out components)
                ? null
                : components.FirstOrDefault(item => item.GetType() == comType);
        }

        internal static List<Guid> GetEntityList()
        {
            return EntityList.Keys.ToList();
        }

        internal static bool ContainsComponent(Guid entityGuid, Type comType)
        {
            List<Component> componentList;
            return EntityList.TryGetValue(entityGuid, out componentList) &&
                   componentList.Any(c => comType == c.GetType());
        }
    }
}