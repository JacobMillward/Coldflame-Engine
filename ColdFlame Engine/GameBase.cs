using SFML.System;

namespace ColdFlame
{
    public class GameBase
    {
        public static bool Running { private get; set; }
        public static int Framerate { private get; set; }
        private Clock GameClock = new Clock();

        protected virtual void Initialise()
        {
            Framerate = 60;
        }

        protected virtual void Update()
        {
        }

        public void Start()
        {
            Initialise();
            Running = true;
            int milliSecondsPerFrame = 1000 / Framerate;
            while (Running)
            {
                GameClock.Restart();
                // Critical System updates and user defined update code have priority
                SystemManager.DoCriticalSystemUpdates();
                Update();
                // Then calculate the time remaining in this tick and use that for other stuff.
                SystemManager.DoOtherSystemUpdates(milliSecondsPerFrame - GameClock.ElapsedTime.AsMilliseconds());
            }
        }
    }
}