using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;

namespace ColdFlame.Components
{
    public class Animation : Component
    {
        public bool FirstRun = true;
        public bool Play = true;
        public List<SFML.Graphics.Sprite> SpriteList = new List<SFML.Graphics.Sprite>();
        public float totalDeltaTime;

        public Animation(List<SFML.Graphics.Sprite> list)
        {
            SpriteList = list;
            CurrentFrame = 0;
        }

        public Animation(string imagePath, int frameWidth, int frameHeight, int frames, int xOffset = 0, int yOffset = 0,
            float frameRate = 24f)
        {
            FrameRate = frameRate;
            var size = new Vector2i(frameWidth, frameHeight);
            CurrentFrame = 0;
            var t = new Texture(@imagePath);
            for (var i = 0; i < frames; i++)
            {
                var pos = new Vector2i(i*frameWidth, 0);

                SpriteList.Add(new SFML.Graphics.Sprite(t, new IntRect(pos, size)));
            }
        }

        public int CurrentFrame { get; set; }
        public float FrameRate { get; }
    }
}