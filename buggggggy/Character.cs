using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace buggggggy
{
    class Character
    {
        Texture2D texture;
        public Vector2 position;
        private const int player_movement_speed = 4;
        private KeyboardState _currentState;
        private KeyboardState _previousState;
        public Rectangle Rectangle;
        public bool stop;
        public bool stopRight;
        public bool stopLeft;
        public bool stopTop;
       
        private MouseState _currentMouseState;
        
        private Rectangle mouse;
        
        public Character(Texture2D newTexture, Vector2 newPosition)
        {
            texture = newTexture;
            position = newPosition;

        }



        public void Update(GameTime gameTime, GraphicsDevice graphics)
        {

             _previousState = _currentState;
             _currentState = Keyboard.GetState();




             if (_currentState.IsKeyDown(Keys.Up))
                 position.Y -= player_movement_speed;
             if (_currentState.IsKeyDown(Keys.Right))
                 position.X += player_movement_speed;
             if (_currentState.IsKeyDown(Keys.Left))
                 position.X -= player_movement_speed;
             if (_currentState.IsKeyDown(Keys.Down))
                 position.Y += player_movement_speed;

            /* if (_currentState.IsKeyDown(Keys.W))
                 position.Y -= player_movement_speed;
             if (_currentState.IsKeyDown(Keys.D))
                 position.X += player_movement_speed;
             if (_currentState.IsKeyDown(Keys.A))
                 position.X -= player_movement_speed;
             if (_currentState.IsKeyDown(Keys.S))
                 position.Y += player_movement_speed;*/

              Rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            
            //left
              if (position.X < 0)
              {
                  position = new Vector2(0, position.Y);
                  stopLeft = true;
              }else stopLeft= false;
              
             //right
              int rightEdge = graphics.Viewport.Width - texture.Width;
              if (position.X > rightEdge)
              {
                  position = new Vector2(rightEdge, position.Y);
                  stopRight = true;
              }
              else
                  stopRight = false;
              
            //bottom
              int bottomEdge = graphics.Viewport.Height - texture.Width;
              if (position.Y > bottomEdge)
              {
                  position = new Vector2(position.X, bottomEdge);
                  stop = true;
              }
              else
                  stop = false;
             
              //top
              if (position.Y < 50)
              {
                  position = new Vector2(position.X, 50);
                  stopTop = true;
              }
              else stopTop = false;
               

              _currentMouseState = Mouse.GetState();
             
             mouse = new Rectangle(_currentMouseState.X, _currentMouseState.Y, mouse.Width+20, mouse.Height+20 );
              if (_currentMouseState.LeftButton == ButtonState.Pressed &&mouse.Intersects(Rectangle))
             {

                 position= new Vector2(_currentMouseState.X,_currentMouseState.Y);
             }
            

        }

        public void Draw(SpriteBatch spriteBatch)
        {


            spriteBatch.Draw(texture,position, Color.White);

        }

    }
}