using System;
using System.Collections.Generic;
using SFML.Window;

namespace ColdFlame
{
    public class InputSystem : GameSystem
    {
        public override bool isUnique { get; } = true;
        public override int priority { get; } = 2;

        public InputSystem() : base()
        {
            actionableComponents.Add(typeof(KeyboardInput));
        }

        public override void Update()
        {
            foreach (Entity e in actionableEntities)
            {
                Dictionary<KeyboardInput.Key, Action> inputEvents = e.GetComponent<KeyboardInput>().inputEvents;
                foreach(KeyValuePair<KeyboardInput.Key, Action> inputEvent in inputEvents)
                {
                    switch(inputEvent.Key.keyState)
                    {
                        case KeyboardInput.KeyState.Down:
                            if(Keyboard.IsKeyPressed(inputEvent.Key.keyCode))
                            {
                                inputEvent.Value();
                            }
                          break;
                        case KeyboardInput.KeyState.Up:
                            if (!Keyboard.IsKeyPressed(inputEvent.Key.keyCode))
                            {
                                inputEvent.Value();
                            }
                            break;
                    }
                }
            }
        }
    }
}
