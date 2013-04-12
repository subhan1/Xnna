using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace buggggggy
{
    class Gem
    {
         
        Texture2D texture;
        public Vector2 position;
        private const int player_movement_speed = -10;
        private KeyboardState _currentState;
        private KeyboardState _previousState;
        public Rectangle Rectangle;
        
        

        public Gem(Texture2D newTexture, Vector2 newPosition)
        {
            texture = newTexture;
            position = newPosition;

        }



        public void Update(GameTime gameTime, GraphicsDevice graphics)
        {
            Rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
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


            if (_currentState.IsKeyDown(Keys.W))
                position.Y -= player_movement_speed;
            if (_currentState.IsKeyDown(Keys.D))
                position.X += player_movement_speed;
            if (_currentState.IsKeyDown(Keys.A))
                position.X -= player_movement_speed;
            if (_currentState.IsKeyDown(Keys.S))
                position.Y += player_movement_speed;
            
           
            
            
            
            
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {


            spriteBatch.Draw(texture,position, Color.White);

        }

    }
}
    