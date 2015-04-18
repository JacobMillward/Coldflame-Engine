using System;
using System.Collections.Generic;

namespace ColdFlame
{

    public abstract class GameSystem
    {
        protected EntityManager entityManager;
        public List<int> actionableEntities = new List<int>();
        protected List<Type> actionableComponents = new List<Type>();

        public GameSystem(EntityManager entityManager)
        {
            this.entityManager = entityManager;
            entityManager.EntityEvent += new EntityManager.EntityEventHandler(OnNotify);
            
        }

        protected virtual void OnNotify(int entity, string value)
        {
            Console.WriteLine("{0} Recieved {1} event from {2}", typeof(GameSystem).FullName, value, entity.ToString());

            int componentsMatched = 0;
            foreach (Type t in actionableComponents)
            {
                if (entityManager.containsComponent(entity, t))
                {
                    componentsMatched++;
                }
            }

            if (componentsMatched == actionableComponents.Count)
            {
                actionableEntities.Add(entity);
            }
        }

        public abstract void Update();
    }
}
