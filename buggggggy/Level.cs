using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace buggggggy
{
    public class Level
    {
       public Texture2D texture;
        public Rectangle position;

       
        private const int player_movement_speed = -15;
        private KeyboardState _currentState;
        private KeyboardState _previousState;
        

        public Level(Texture2D newTexture, Rectangle newPosition)
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