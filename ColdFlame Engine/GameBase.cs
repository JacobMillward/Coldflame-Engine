using SFML.Graphics;
using System.Collections.Generic;

namespace ColdFlame
{
    public class GameBase
    {

        public static bool running { get; set; }

        protected virtual void Initialise() { }

        public void Start()
        {
            Initialise();
            GameBase.running = true;
            while(GameBase.running)
            {
                SystemManager.doSystemUpdates();
            }
        }
    }
}