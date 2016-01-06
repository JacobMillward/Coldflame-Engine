using SFML.Graphics;

namespace ColdFlame.Components
{
    public class Sprite : Component
    {
        public Sprite()
        {
            Image = new SFML.Graphics.Sprite();
        }

        public Sprite(string path)
        {
            Image = new SFML.Graphics.Sprite(new Texture(@path));
        }

        public Sprite(string path, IntRect rect)
        {
            Image = new SFML.Graphics.Sprite(new Texture(@path, rect));
        }

        public Sprite(SFML.Graphics.Sprite sfmlSprite)
        {
            Image = sfmlSprite;
        }

        public SFML.Graphics.Sprite Image { get; set; }
    }
}