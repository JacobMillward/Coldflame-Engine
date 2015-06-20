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
                if ((a.clock.ElapsedTime.AsSeconds() > (1/a.frameRate) || a.firstRun) && a.play)
                {
                    a.firstRun = false;
                    int frameCount = a.spriteList.Count;
                    if (a.currentFrame < frameCount - 1)
                    {
                        a.currentFrame++;
                    }
                    else
                    {
                        a.currentFrame = 0;
                    }
                    s.image = a.spriteList[a.currentFrame];
                    a.clock.Restart();
                }
                
            }
        }
    }
}
