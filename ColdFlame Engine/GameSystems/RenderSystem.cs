using System;
using ColdFlame.Components;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using Sprite = ColdFlame.Components.Sprite;

namespace ColdFlame.GameSystems
{
    public class RenderSystem : GameSystem
    {
        private readonly Clock _clock = new Clock();
        private readonly Font _debugFont = new Font(@"C:\Windows\Fonts\arial.ttf");
        private readonly Text _debugText;
        private readonly RenderWindow _window;
        private bool _debugMode;
        private int _frameCount;

        public RenderSystem(Vector2u screenDimensions)
        {
            ActionableComponents.Add(typeof (Position));
            ActionableComponents.Add(typeof (Sprite));

            _window = new RenderWindow(new VideoMode(screenDimensions.X, screenDimensions.Y), "SFML window",
                Styles.Close);
            _window.Closed += delegate
            {
                GameBase.Running = false;
                _window.Close();
            };
            _window.SetVisible(true);
            _window.SetFramerateLimit(60);
            _debugText = new Text("FPS: 0", _debugFont, 24);
            _debugText.Position =
                new Vector2f(_window.GetViewport(_window.GetView()).Width - _debugText.GetLocalBounds().Width - 10, 0f);
            _debugText.Color = Color.Black;
            _debugText.CharacterSize = 16;
        }

        public float Fps { get; private set; }

        public override bool IsUnique { get; } = true;
        public override int Priority { get; } = 20;

        public override void Update()
        {
            _window.DispatchEvents();
            _window.Clear(Color.White);
            foreach (var e in ActionableEntities)
            {
                var s = e.GetComponent<Sprite>();
                var p = e.GetComponent<Position>();
                s.Image.Position = new Vector2f(p.X, p.Y);

                _window.Draw(s.Image);
            }
            if (_debugMode)
            {
                _frameCount++;
                if (_clock.ElapsedTime.AsSeconds() > 1f)
                {
                    Fps = _frameCount/_clock.Restart().AsSeconds();
                    _debugText.DisplayedString = "FPS: " + Math.Floor(Fps);
                    _debugText.Position =
                        new Vector2f(
                            _window.GetViewport(_window.GetView()).Width - _debugText.GetLocalBounds().Width - 10, 0f);
                    _frameCount = 0;
                }

                _window.Draw(_debugText);
            }
            _window.Display();
        }

        public void SetDebug(bool value = true)
        {
            _debugMode = value;
        }
    }
}