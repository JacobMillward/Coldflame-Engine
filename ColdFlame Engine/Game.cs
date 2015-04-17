using SFML.Graphics;
using SFML.Window;
using System;
using System.Threading;

namespace ColdFlame
{
    class Game
    {
        private RenderWindow _window;

        public void Start()
        {
            Thread oThread = new Thread(new ThreadStart(this.WindowThread));
            oThread.Start();
            while (!oThread.IsAlive) ;

            EntityManager entityManager = new EntityManager();
            RenderSystem rs = new RenderSystem(entityManager, _window);

            entityManager.createEntity();
        }

        public void WindowThread()
        {
            _window = new RenderWindow(new VideoMode(800, 600), "SFML window");
            _window.Closed += delegate { _window.Close(); };
            _window.SetVisible(true);

            while (_window.IsOpen)
            {
                _window.DispatchEvents();
                _window.Clear(Color.Cyan);
                _window.Display();
            }
        }
    }
}