using SFML.Graphics;
using SFML.Window;

namespace ColdFlame
{
    class Game
    {
        RenderWindow _window;
        public void Start()
        {
            _window = new RenderWindow(new VideoMode(800, 600), "SFML window");
            _window.SetVisible(true);
            _window.Closed += delegate { _window.Close(); };

            while (_window.IsOpen)
            {
                _window.DispatchEvents();
                _window.Clear(Color.Red);
                _window.Display();
            }
        }

        //Draws game objects
        void Draw()
        {
        }

        //Updates game logic - called before Draw()
        void Update()
        {
        }
    }
}