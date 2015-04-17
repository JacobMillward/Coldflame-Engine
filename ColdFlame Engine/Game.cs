using SFML.Graphics;
using SFML.Window;
using System;

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

            EntityManager entityManager = new EntityManager();
            RenderSystem rs = new RenderSystem(entityManager);

            entityManager.createEntity();

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
            throw new NotImplementedException();
        }

        //Updates game logic - called before Draw()
        void Update()
        {
            throw new NotImplementedException();
        }
    }
}