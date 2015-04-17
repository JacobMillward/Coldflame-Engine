using System;
using System.Collections.Generic;

namespace ColdFlame
{

    public abstract class GameSystem
    {
        protected EntityManager entityManager;
        protected List<int> actionableEntities;
        protected List<Type> actionableComponents;

        public GameSystem(EntityManager entityManager)
        {
            this.entityManager = entityManager;
            entityManager.EntityEvent += new EntityManager.EntityEventHandler(OnNotify);
            actionableComponents = new List<Type>();
            List<int> actionableEntities = new List<int>();
        }

        protected virtual void OnNotify(int entity)
        {
            Console.WriteLine("{0} Recieved EntityEvent from {1}", typeof(GameSystem).FullName, entity.ToString());

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
