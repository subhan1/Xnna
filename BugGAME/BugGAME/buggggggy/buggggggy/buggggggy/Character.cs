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
        private const int player_movement_speed = 2;
        private KeyboardState _currentState;
        private KeyboardState _previousState;
        public Rectangle Rectangle;
     
     
        
        
        
        public Character(Texture2D newTexture, Vector2 newPosition)
        {
            texture = newTexture;
            position = newPosition;

        }



        public void Update(GameTime gameTime)
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
              Rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);


              // If player pressed the gamepad thumbstick, move the sprite
              GamePadState gamepadState = GamePad.GetState(PlayerIndex.One);
              if (gamepadState.ThumbSticks.Left.X != 0)
                  position.X += gamepadState.ThumbSticks.Left.X;
              if (gamepadState.ThumbSticks.Left.Y != 0)
                  position.Y -= gamepadState.ThumbSticks.Left.Y;
           
              
            

             /*
              _currentMouseState = Mouse.GetState();
             
             mouse = new Rectangle(_currentMouseState.X, _currentMouseState.Y, mouse.Width+20, mouse.Height+20 );
              if (_currentMouseState.LeftButton == ButtonState.Pressed &&mouse.Intersects(position))
             {

                 position = new Rectangle(_currentMouseState.X,_currentMouseState.Y, 100, 100);
             }
            */

        }

        public void Draw(SpriteBatch spriteBatch)
        {


            spriteBatch.Draw(texture,position, Color.White);

        }

    }
}