using ColdFlame;

namespace Coldflame_Test
{
    class Game : ColdFlame.GameBase
    {
        protected override void Initialise()
        {
            SystemList.Add(new RenderSystem(new SFML.System.Vector2u(800, 600)));
            SystemList.Add(new AnimationSystem());

            Entity player = new Entity();
            player.AddComponent(new Position(0, 0));
            player.AddComponent(new Sprite(@"player.png"));
            player.AddComponent(new Animation(@"player.png", 24, 25, 6));
        }
    }
}
