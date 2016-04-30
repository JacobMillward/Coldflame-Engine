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

        public override void Update(float deltaTime)
        {
            foreach (var e in ActionableEntities)
            {
                var s = e.GetComponent<Sprite>();
                var a = e.GetComponent<Animation>();
                a.totalDeltaTime += deltaTime;
                if ((!(a.totalDeltaTime > 1/a.FrameRate) && !a.FirstRun) || !a.Play) continue;
                a.totalDeltaTime = 0;
                a.FirstRun = false;
                var frameCount = a.SpriteList.Count;
                a.CurrentFrame = (a.CurrentFrame + 1)%frameCount;
                s.Image = a.SpriteList[a.CurrentFrame];
            }
        }
    }
}