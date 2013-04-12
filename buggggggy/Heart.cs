﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace buggggggy
{
    class Heart
    {
         Texture2D texture;
        Rectangle position;
        

        public  Heart(Texture2D newTexture, Rectangle newPosition)
        {
            texture = newTexture;
            position = newPosition;

           position = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
    
}