using ColdFlame.Components;

namespace ColdFlame.GameSystems
{
    public class AnimationSystem : GameSystem
    {
        public AnimationSystem()
        {
            ActionableComponents.Add(typeof (Sprite));
            ActionableComponents.Add(typeof (Animation));
        }

        public override void Update()
        {
            foreach (var e in ActionableEntities)
            {
                var s = e.GetComponent<Sprite>();
                var a = e.GetComponent<Animation>();
                if ((!(a.Clock.ElapsedTime.AsSeconds() > 1/a.FrameRate) && !a.FirstRun) || !a.Play) continue;
                a.FirstRun = false;
                var frameCount = a.SpriteList.Count;
                if (a.CurrentFrame < frameCount - 1)
                {
                    a.CurrentFrame++;
                }
                else
                {
                    a.CurrentFrame = 0;
                }
                s.Image = a.SpriteList[a.CurrentFrame];
                a.Clock.Restart();
            }
        }
    }
}