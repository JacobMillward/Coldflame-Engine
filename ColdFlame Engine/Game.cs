using SFML.Graphics;
using System.Collections.Generic;

namespace ColdFlame
{
    class Game
    {

        public static bool running { get; set; }
        List<GameSystem> SystemList = new List<GameSystem>();
        EntityManager entityManager;

        public void Start()
        {
            entityManager = new EntityManager();
            SystemList.Add(new RenderSystem(entityManager, new SFML.System.Vector2u(800,600)));

            int playerHandle = entityManager.createEntity();
            entityManager.addComponent(playerHandle, new Position(0, 0));
            entityManager.addComponent(playerHandle, new Sprite(@"player.png", new IntRect(0,0,24,25)));

            Game.running = true;
            while(Game.running)
            {
                foreach(GameSystem system in SystemList)
                {
                    system.Update();
                }
            }
        }

        public void WindowThread()
        {
           
        }
    }
}