namespace ColdFlame.Events
{
    public enum EntityEventType
    {
        NewEntity,
        NewComponent,
        RemovedComponent
    }

    public struct EntityEventData
    {
        public EntityEventType EventType;
        public Entity Entity;
        public Component Component;

        public EntityEventData(EntityEventType eventType, Entity entity, Component component)
        {
            EventType = eventType;
            Entity = entity;
            Component = component;
        }
    }
}