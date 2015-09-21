using ColdFlame;

namespace Coldflame_Example
{
    class Game : GameBase
    {
        Entity player;

        protected override void Initialise()
        {
            RenderSystem renderSys = new RenderSystem(new SFML.System.Vector2u(800, 600));
            renderSys.setDebug();
            AnimationSystem anim = new AnimationSystem();
            InputSystem inputSys = new InputSystem();

            player = new Entity();
            player.AddComponent(new Position(0, 0));
            player.AddComponent(new Sprite());
            player.AddComponent(new Animation(@"player.png", 25, 25, 6, frameRate: 5f));
            player.AddComponent(new KeyboardInput());

            KeyboardInput k = player.GetComponent<KeyboardInput>();
            k.inputEvents.Add(new KeyboardInput.Key(KeyboardInput.Key.KeyState.Down, SFML.Window.Keyboard.Key.Down), new System.Action(delegate() { player.GetComponent<Position>().y += 1; }));
            k.inputEvents.Add(new KeyboardInput.Key(KeyboardInput.Key.KeyState.Down, SFML.Window.Keyboard.Key.Up), new System.Action(delegate () { player.GetComponent<Position>().y -= 1; }));
            k.inputEvents.Add(new KeyboardInput.Key(KeyboardInput.Key.KeyState.Down, SFML.Window.Keyboard.Key.Left), new System.Action(delegate () { player.GetComponent<Position>().x -= 1; }));
            k.inputEvents.Add(new KeyboardInput.Key(KeyboardInput.Key.KeyState.Down, SFML.Window.Keyboard.Key.Right), new System.Action(delegate () { player.GetComponent<Position>().x += 1; }));
        }

    }
}
