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
                foreach(KeyValuePair<KeyboardInput.Key, Action> keyEvent in inputEvents)
                {
                    switch(keyEvent.Key.keyState)
                    {
                        case KeyboardInput.Key.KeyState.Down:
                            if(Keyboard.IsKeyPressed(keyEvent.Key.keyCode))
                            {
                                keyEvent.Value();
                            }
                          break;
                        case KeyboardInput.Key.KeyState.Up:
                            if (!Keyboard.IsKeyPressed(keyEvent.Key.keyCode))
                            {
                                keyEvent.Value();
                            }
                            break;
                    }
                }
            }
        }
    }
}
