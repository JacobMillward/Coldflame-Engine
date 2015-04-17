using System;

namespace ColdFlame
{

    public class RenderSystem : GameSystem
    {

        public RenderSystem(EntityManager entityManager) : base(entityManager) {
            actionableComponents.Add(typeof(Position));
            actionableComponents.Add(typeof(Sprite));
        }

        public override void Update()
        {
            foreach (int e in actionableEntities)
            {
                //Render entity here using drawing library
            }
        }
    }
}