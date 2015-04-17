using SFML.Graphics;
using System;

namespace ColdFlame
{
    public class Sprite : Component
    {
        public SFML.Graphics.Sprite sprite;

        public Sprite(string path)
        {
            sprite = new SFML.Graphics.Sprite(new Texture(@path));
        }

        public Sprite(string path, IntRect rect)
        {
            sprite = new SFML.Graphics.Sprite(new Texture(@path, rect));
        }

    }
}