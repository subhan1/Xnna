using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace buggggggy
{
    public class Enemy 
    {

        Texture2D texture;
        public Vector2 position;
        Random random = new Random();
        public bool isVisible;
        int randX, randY;
        public Vector2 velocity;
        public Rectangle Rectangle;
        public Enemy(Texture2D newTexture, Vector2 newPosition)
        {
            texture = newTexture;
            position = newPosition;

            randY = random.Next(-7, 7);
            randX = random.Next(-7, 7);

            velocity = new Vector2(randX, randY);
           

        }

     



        public void Update( GraphicsDevice graphics)
        {
            Rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            position += velocity;
            
            if (position.Y <= 0 || position.Y >= graphics.Viewport.Height - texture.Height)
                velocity.Y = -velocity.Y;
            if (position.X < 0 - texture.Width)
                isVisible = false; 
            
            
           

   
          
        }

         
        
      
        public void Draw(SpriteBatch spriteBatch)
        {


            spriteBatch.Draw(texture, position, Color.White);

        }

    }
}