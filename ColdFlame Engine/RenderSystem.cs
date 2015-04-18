using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace ColdFlame
{

    public class RenderSystem : GameSystem
    {
        private RenderWindow _window;

        public RenderSystem(EntityManager entityManager, Vector2u screenDimensions): base(entityManager) {
            actionableComponents.Add(typeof(Position));
            actionableComponents.Add(typeof(Sprite));

            if (screenDimensions == null) screenDimensions = new Vector2u(800, 600);
            _window = new RenderWindow(new VideoMode(screenDimensions.X, screenDimensions.Y), "SFML window");
            _window.Closed += delegate { Game.running = false; _window.Close(); };
            _window.SetVisible(true);

        }

        public override void Update()
        {
            _window.DispatchEvents();
            _window.Clear(Color.Cyan);
            foreach (int e in actionableEntities)
            {
                Sprite s = (Sprite) entityManager.getComponent(e, typeof(Sprite));
                Position p = (Position)entityManager.getComponent(e, typeof(Position));
                s.sprite.Position = new SFML.System.Vector2f((float)p.x, (float)p.y);

                _window.Draw(s.sprite);
            }
            _window.Display();
        }
    }
}