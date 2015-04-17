using SFML.Graphics;

namespace ColdFlame
{

    public class RenderSystem : GameSystem
    {
        RenderWindow _window;
        public RenderSystem(EntityManager entityManager, RenderWindow window) : base(entityManager) {
            actionableComponents.Add(typeof(Position));
            actionableComponents.Add(typeof(Sprite));
            _window = window;
        }

        public override void Update()
        {
            foreach (int e in actionableEntities)
            {
                Sprite s = (Sprite) entityManager.getComponent(e, typeof(Sprite));
                Position p = (Position)entityManager.getComponent(e, typeof(Position));
                s.sprite.Position = new SFML.System.Vector2f((float)p.x, (float)p.y);

                _window.Draw(s.sprite);
            }
        }
    }
}