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
            actionableComponents = new List<Type>();
            List<int> actionableEntities = new List<int>();
        }

        protected void gatherActionableEntities() {
		List<int> allEntities = entityManager.getEntityList();
		foreach(int entity in allEntities) {
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
		
	}

        public abstract void Update();

    }
}
