using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace buggggggy
{
    class Player1Win
    {
        private Vector2  winPos = new Vector2(160, 400);

        public SpriteFont Font { get; set; }

       

        public Player1Win()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the Score in the top-left of screen
            spriteBatch.DrawString(
                Font,                           // SpriteFont
                "Player One Win" ,   // Text
                winPos,                       // Position
                Color.Gold);                   // Tint
        }
    }
}

