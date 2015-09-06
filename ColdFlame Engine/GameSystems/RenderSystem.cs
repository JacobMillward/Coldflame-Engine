using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System;

namespace ColdFlame
{

    public class RenderSystem : GameSystem
    {
        private RenderWindow _window;
        private bool debugMode = false;
        private Font debugFont;
        private Text debugText;
        private Clock clock = new Clock();
        private int frameCount;

        public RenderSystem(Vector2u screenDimensions, Font font = null): base() {
            actionableComponents.Add(typeof(Position));
            actionableComponents.Add(typeof(Sprite));

            _window = new RenderWindow(new VideoMode(screenDimensions.X, screenDimensions.Y), "SFML window", Styles.Close);
            _window.Closed += delegate { GameBase.running = false; _window.Close(); };
            _window.SetVisible(true);
            debugFont = font;
            debugText = new Text("FPS: 0", font, 24);
            debugText.Position = new Vector2f(_window.GetViewport(_window.GetView()).Width - debugText.GetLocalBounds().Width - 10, 0f);
            debugText.Color = Color.Black;
            debugText.CharacterSize = 16;

        }

        public override void Update()
        {
            _window.DispatchEvents();
            _window.Clear(Color.White);
            foreach (Entity e in actionableEntities)
            {
                Sprite s = e.GetComponent<Sprite>();
                Position p = e.GetComponent<Position>();
                s.image.Position = new SFML.System.Vector2f((float)p.x, (float)p.y);

                _window.Draw(s.image);
            }
            if (debugMode)
            {
                frameCount++;
                if (clock.ElapsedTime.AsSeconds() > 1f)
                {
                    debugText.DisplayedString = "FPS: " + Math.Floor(frameCount / clock.Restart().AsSeconds());
                    debugText.Position = new Vector2f(_window.GetViewport(_window.GetView()).Width - debugText.GetLocalBounds().Width - 10, 0f);
                    frameCount = 0;
                }
                
                _window.Draw(debugText);
            }
            _window.Display();
        }

        public void setDebug(bool enable = true)
        {
            debugMode = enable;
        }
    }
}