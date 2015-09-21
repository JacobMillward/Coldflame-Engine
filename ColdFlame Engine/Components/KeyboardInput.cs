using System;
using System.Collections.Generic;
using SFML.Window;

namespace ColdFlame
{
    public class KeyboardInput : Component
    {
        public Dictionary<Key, Action> inputEvents;
        
        public struct Key
        {
            public enum KeyState
            {
                Up,
                Down,
            };

            public KeyState keyState;
            public SFML.Window.Keyboard.Key keyCode;

            public Key( KeyState keyState, SFML.Window.Keyboard.Key keyCode)
            {
                this.keyState = keyState;
                this.keyCode = keyCode;
            }
        }
        
        public KeyboardInput()
        {
            inputEvents = new Dictionary<Key, Action>();
        }
    }
}
