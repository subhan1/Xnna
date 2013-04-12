using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace buggggggy
{
    class MouseTex{
         Texture2D texture;
        public Rectangle position;
        private MouseState _currentMouseState;
        
       

        public MouseTex(Texture2D newTexture)
        {
            texture = newTexture;
            

        }



        public void Update(GameTime gameTime)
        {
            _currentMouseState = Mouse.GetState();
            position = new Rectangle(_currentMouseState.X,_currentMouseState.Y, texture.Width, texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {


            spriteBatch.Draw(texture,position, Color.White);

        }

    }
}