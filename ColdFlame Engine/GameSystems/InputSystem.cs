using System;
using System.Linq;
using ColdFlame.Components;
using SFML.Window;

namespace ColdFlame.GameSystems
{
    public class InputSystem : GameSystem
    {
        public InputSystem()
        {
            ActionableComponents.Add(typeof (KeyboardInput));
        }

        public override bool IsUnique { get; } = true;
        public override int Priority { get; } = 2;

        public override void Update()
        {
            foreach (
                var inputEvent in
                    ActionableEntities.Select(e => e.GetComponent<KeyboardInput>().InputEvents)
                        .SelectMany(inputEvents => inputEvents))
            {
                switch (inputEvent.Key.KeyState)
                {
                    case KeyboardInput.KeyState.Down:
                        if (Keyboard.IsKeyPressed(inputEvent.Key.KeyCode))
                        {
                            inputEvent.Value();
                        }
                        break;
                    case KeyboardInput.KeyState.Up:
                        if (!Keyboard.IsKeyPressed(inputEvent.Key.KeyCode))
                        {
                            inputEvent.Value();
                        }
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}