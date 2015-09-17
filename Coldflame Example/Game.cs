using ColdFlame;

namespace Coldflame_Example
{
    class Game : GameBase
    {
        protected override void Initialise()
        {
            RenderSystem renderSys = new RenderSystem(new SFML.System.Vector2u(800, 600));
            renderSys.setDebug();
            AnimationSystem anim = new AnimationSystem();
            

            Entity player = new Entity();
            player.AddComponent(new Position(0, 0));
            player.AddComponent(new Sprite());
            player.AddComponent(new Animation(@"player.png", 25, 25, 6, frameRate: 5f));
        }
    }
}
