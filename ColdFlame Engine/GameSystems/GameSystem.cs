using System;
using System.Collections.Generic;
using System.Linq;

namespace ColdFlame
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
        public virtual int Priority { get; } = 0;

        protected virtual void OnNotify(Entity e, string value)
        {
            //TODO: Replace with code that checks type of notification properly
            var componentsMatched = ActionableComponents.Count(e.ContainsComponent);

            if (componentsMatched == ActionableComponents.Count && !ActionableEntities.Contains(e))
            {
                ActionableEntities.Add(e);
                Console.WriteLine("{0} Added {1} to actionable entities", GetType().FullName, e);
            }

            if (value != "Removed Component" || !ActionableEntities.Contains(e) ||
                componentsMatched == ActionableComponents.Count) return;
            ActionableEntities.Remove(e);
            Console.WriteLine("{0} Removed {1} from actionable entities", GetType().FullName, e);
        }

        public abstract void Update();
    }
}