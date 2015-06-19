using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace ColdFlame
{

    public class RenderSystem : GameSystem
    {
        private RenderWindow _window;

        public RenderSystem(Vector2u screenDimensions): base() {
            actionableComponents.Add(typeof(Position));
            actionableComponents.Add(typeof(Sprite));

            _window = new RenderWindow(new VideoMode(screenDimensions.X, screenDimensions.Y), "SFML window");
            _window.Closed += delegate { GameBase.running = false; _window.Close(); };
            _window.SetVisible(true);

        }

        public override void Update()
        {
            _window.DispatchEvents();
            _window.Clear(Color.Cyan);
            foreach (Entity e in actionableEntities)
            {
                Sprite s = e.GetComponent<Sprite>();
                Position p = e.GetComponent<Position>();
                s.sprite.Position = new SFML.System.Vector2f((float)p.x, (float)p.y);

                _window.Draw(s.sprite);
            }
            _window.Display();
        }
    }
}