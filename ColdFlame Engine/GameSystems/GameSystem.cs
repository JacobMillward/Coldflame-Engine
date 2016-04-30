using System;
using System.Collections.Generic;
using System.Linq;
using ColdFlame.Events;
using SFML.System;

namespace ColdFlame.GameSystems
{
    public abstract class GameSystem
    {
        protected readonly List<Type> ActionableComponents = new List<Type>();
        protected readonly List<Entity> ActionableEntities = new List<Entity>();
        public readonly Clock TimerClock;

        protected GameSystem()
        {
            EntityManager.EntityEvent += OnNotify;
            SystemManager.Add(this);
            TimerClock = new Clock();
            Console.WriteLine("Added {0} to SystemMananger", GetType().FullName);
        }

        public virtual bool IsUnique { get; } = false;
        public virtual int Priority { get; } = 0;

        protected virtual void OnNotify(EntityEventData eventData)
        {
            var componentsMatched = ActionableComponents.Count(eventData.Entity.ContainsComponent);

            switch (eventData.EventType)
            {
                case EntityEventType.NewEntity:
                    break;

                case EntityEventType.NewComponent:
                    if (componentsMatched == ActionableComponents.Count && !ActionableEntities.Contains(eventData.Entity))
                    {
                        ActionableEntities.Add(eventData.Entity);
                        Console.WriteLine("{0} Added {1} to actionable entities", GetType().FullName, eventData.Entity);
                    }
                    break;

                case EntityEventType.RemovedComponent:
                    if (ActionableEntities.Contains(eventData.Entity) && componentsMatched != ActionableComponents.Count)
                    {
                        ActionableEntities.Remove(eventData.Entity);
                        Console.WriteLine("{0} Removed {1} from actionable entities", GetType().FullName, eventData.Entity);
                    }
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(eventData.EventType), eventData.EventType, null);
            }
        }

        public abstract void Update(float deltaTime);
    }
}