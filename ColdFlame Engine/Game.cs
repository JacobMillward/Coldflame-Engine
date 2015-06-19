using SFML.Graphics;
using System.Collections.Generic;

namespace ColdFlame
{
    public class Game
    {

        public static bool running { get; set; }
        List<GameSystem> SystemList = new List<GameSystem>();

        public void Start()
        {
            SystemList.Add(new RenderSystem(new SFML.System.Vector2u(800,600)));
            SystemList.Add(new AnimationSystem());

            Entity player = new Entity();
            player.AddComponent(new Position(0, 0));
            player.AddComponent(new Sprite(@"player.png"));
            player.AddComponent(new Animation(@"player.png", 24, 25, 6));

            Game.running = true;
            while(Game.running)
            {
                foreach(GameSystem system in SystemList)
                {
                    system.Update();
                }
            }
        }
    }
}