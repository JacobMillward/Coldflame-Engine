using SFML.Graphics;
using System.Collections.Generic;

namespace ColdFlame
{
    public class GameBase
    {

        public static bool running { get; set; }
        protected List<GameSystem> SystemList = new List<GameSystem>();

        protected virtual void Initialise() { }

        public void Start()
        {
            Initialise();
            GameBase.running = true;
            while(GameBase.running)
            {
                foreach(GameSystem system in SystemList)
                {
                    system.Update();
                }
            }
        }
    }
}