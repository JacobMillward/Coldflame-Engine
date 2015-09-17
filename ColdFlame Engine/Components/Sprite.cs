using SFML.Graphics;
using System;

namespace ColdFlame
{
    public class Sprite : Component
    {
        public SFML.Graphics.Sprite image {get; set; }

        public Sprite()
        {
            image = new SFML.Graphics.Sprite();
        }

        public Sprite(string path)
        {
            image = new SFML.Graphics.Sprite(new Texture(@path));
        }

        public Sprite(string path, IntRect rect)
        {
            image = new SFML.Graphics.Sprite(new Texture(@path, rect));
        }

        public Sprite(SFML.Graphics.Sprite sfmlSprite)
        {
            this.image = sfmlSprite;
        }
    }
}