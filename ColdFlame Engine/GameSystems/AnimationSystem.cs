using System;

namespace ColdFlame
{
    public class AnimationSystem : GameSystem
    {
        public AnimationSystem() : base ()
        {
            actionableComponents.Add(typeof(Sprite));
            actionableComponents.Add(typeof(Animation));
        }

        public override void Update()
        {
            foreach (Entity e in actionableEntities)
            {
                Sprite s = e.GetComponent<Sprite>();
                Animation a = e.GetComponent<Animation>();
                s = a.spriteList[0];
            }
        }
    }
}
