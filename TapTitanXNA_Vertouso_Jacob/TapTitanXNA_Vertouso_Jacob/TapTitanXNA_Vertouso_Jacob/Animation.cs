using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace TapTitanXNA_Vertouso_Jacob
{
    public class Animation
    {
        public Texture2D texture;

        public float frametime;

        public bool isLooping;

        public int FrameCount;
        
      
        public int FrameWidth
        {
            get {return texture.Width / FrameCount;}
        }
        public int FrameHeight 
        {
            get {return texture.Height;}
        }
        public Animation (Texture2D texture, float frametime, bool isLooping, int FrameCount)
        {
            this.texture = texture;
            this.frametime = frametime;
            this.isLooping = isLooping;
            this.FrameCount = FrameCount;
        }
    }
}
