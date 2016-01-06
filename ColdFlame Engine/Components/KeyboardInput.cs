using System;
using System.Collections.Generic;
using SFML.Window;

namespace ColdFlame.Components
{
    public class KeyboardInput : Component
    {
        public enum KeyState
        {
            Up,
            Down
        }

        public Dictionary<Key, Action> InputEvents;

        public KeyboardInput()
        {
            InputEvents = new Dictionary<Key, Action>();
        }

        public struct Key
        {
            public KeyState KeyState;
            public Keyboard.Key KeyCode;

            public Key(KeyState keyState, Keyboard.Key keyCode)
            {
                this.KeyState = keyState;
                this.KeyCode = keyCode;
            }
        }
    }
}