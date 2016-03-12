using System;
using System.Collections.Generic;
using System.Linq;
using ColdFlame.Events;

namespace ColdFlame.GameSystems
{
    public abstract class GameSystem
    {
        protected readonly List<Type> ActionableComponents = new List<Type>();
        protected readonly List<Entity> ActionableEntities = new List<Entity>();

        protected GameSystem()
        {
            EntityManager.EntityEvent += OnNotify;
            SystemManager.Add(this);
            Console.WriteLine("Added {0} to SystemMananger", GetType().FullName);
        }

        public virtual bool IsUnique { get; } = false;
        public virtual SystemPriority Priority { get; } = SystemPriority.LOW;

        protected virtual void OnNotify(Entity e, EntityEventType eventType)
        {
            var componentsMatched = ActionableComponents.Count(e.ContainsComponent);

            switch (eventType)
            {
                case EntityEventType.NewEntity:
                    break;

                case EntityEventType.NewComponent:
                    if (componentsMatched == ActionableComponents.Count && !ActionableEntities.Contains(e))
                    {
                        ActionableEntities.Add(e);
                        Console.WriteLine("{0} Added {1} to actionable entities", GetType().FullName, e);
                    }
                    break;

                case EntityEventType.RemovedComponent:
                    if (ActionableEntities.Contains(e) && componentsMatched != ActionableComponents.Count)
                    {
                        ActionableEntities.Remove(e);
                        Console.WriteLine("{0} Removed {1} from actionable entities", GetType().FullName, e);
                    }
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(eventType), eventType, null);
            }
        }

        public abstract void Update();
    }
}