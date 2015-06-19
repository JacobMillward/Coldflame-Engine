using SFML.Graphics;
using System;
using System.Collections.Generic;

namespace ColdFlame
{
    class Animation : Component
    {
        public List<Sprite> spriteList;
        public int currentIndex = 0;

        public Animation(List<Sprite> list)
        {
            spriteList = list;
        }

        public Animation(string imagePath, int frameWidth, int frameHeight, int frames, int xOffset = 0, int yOffset = 0)
        {
            Texture t = new Texture(@imagePath);
            List<Sprite> list = new List<Sprite>();

            for(int i = 0; i < frames; i++)
            {
                list.Add(new Sprite(new SFML.Graphics.Sprite(t, new IntRect((i*frameWidth)+xOffset,yOffset,(i+1)*frameWidth, frameHeight))));
            }

            spriteList = list;
        }
    }
}
