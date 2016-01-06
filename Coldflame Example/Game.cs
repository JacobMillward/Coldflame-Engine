using ColdFlame;
using ColdFlame.Components;
using ColdFlame.GameSystems;
using SFML.System;
using SFML.Window;

namespace Coldflame_Example
{
    internal class Game : GameBase
    {
        private Entity _player;

        protected override void Initialise()
        {
            var renderSys = new RenderSystem(new Vector2u(800, 600));
            renderSys.SetDebug();
            var anim = new AnimationSystem();
            var inputSys = new InputSystem();

            _player = new Entity();
            _player.AddComponent(new Position(0, 0));
            _player.AddComponent(new Sprite());
            _player.AddComponent(new Animation(@"player.png", 25, 25, 6, frameRate: 5f));
            _player.AddComponent(new KeyboardInput());

            var k = _player.GetComponent<KeyboardInput>();
            k.InputEvents.Add(new KeyboardInput.Key(KeyboardInput.KeyState.Down, Keyboard.Key.Down),
                delegate { _player.GetComponent<Position>().Y += 1; });
            k.InputEvents.Add(new KeyboardInput.Key(KeyboardInput.KeyState.Down, Keyboard.Key.Up),
                delegate { _player.GetComponent<Position>().Y -= 1; });
            k.InputEvents.Add(new KeyboardInput.Key(KeyboardInput.KeyState.Down, Keyboard.Key.Left),
                delegate { _player.GetComponent<Position>().X -= 1; });
            k.InputEvents.Add(new KeyboardInput.Key(KeyboardInput.KeyState.Down, Keyboard.Key.Right),
                delegate { _player.GetComponent<Position>().X += 1; });
        }
    }
}