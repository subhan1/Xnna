using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace buggggggy
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        SpriteBatch spriteBatch;
        GraphicsDeviceManager graphics;
        ChangeSoundVolume audioComponent;

        Random randX = new Random();
        Random random = new Random();
        List<Enemy> enemy = new List<Enemy>();
        
        List<Level> level = new List<Level>();
        
        Character character;
        Heart[] heart = new Heart[5];
        List<Gem> gem = new List<Gem>();
        HUD hud;
        
        MouseTex mouseTex;
        int count = 5;
        int space = 0;
        int gemSpace = 0;
        int winGemSpace = 0;
        int score = 0;
         
        int lvlSpace = -3000;
        int lvlSpaceTop = -3000;
        int lvlSpaceBottom = -3000;

        
        
        

      //  GameControll gameControll;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            
           
            Content.RootDirectory = "Content";
            

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {


            audioComponent = new ChangeSoundVolume(this);
            Components.Add(audioComponent);
           
            base.Initialize();


        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            enemy.Add(new Enemy(Content.Load<Texture2D>("Sword"), new Vector2(1100, 345)));
            character = new Character(Content.Load<Texture2D>("Character Boy"), new Vector2(300, 345));
            mouseTex = new MouseTex(Content.Load<Texture2D>("mouse"));


          

           
          /*  for (int i = 0; i <= 20; i++)
            {
              
                gem.Add(new Gem(Content.Load<Texture2D>("Gem Blue"), new Rectangle(gemSpace, randPos, 100, 100)));
                gemSpace += 100;
            }*/
            
            for (int i = 0; i <= 10; i++)
            {

                level.Add(new Level(Content.Load<Texture2D>("riffled-background"), new Rectangle(lvlSpace, -50, 1000, 1000)));
                lvlSpace += 1000;
            }
            for (int i = 0; i <= 10; i++)
            {

                level.Add(new Level(Content.Load<Texture2D>("riffled-background"), new Rectangle(lvlSpaceTop, -1050, 1000, 1000)));
                lvlSpaceTop += 1000;
            }
           
            for (int i = 0; i <= 10; i++)
            {

                level.Add(new Level(Content.Load<Texture2D>("riffled-background"), new Rectangle(lvlSpaceBottom, 950, 1000, 1000)));
                lvlSpaceBottom += 1000;
            }




            
            heart[0] = new Heart(Content.Load<Texture2D>("Heart"), new Rectangle(50, 50, 100, 100));
            heart[1] = new Heart(Content.Load<Texture2D>("Heart"), new Rectangle(50, 100, 100, 100));
            heart[2] = new Heart(Content.Load<Texture2D>("Heart"), new Rectangle(50, 150, 100, 100));
            heart[3] = new Heart(Content.Load<Texture2D>("Heart"), new Rectangle(50, 200, 100, 100));
            heart[4] = new Heart(Content.Load<Texture2D>("Heart"), new Rectangle(50, 250, 100, 100));
            
            hud = new HUD();
            hud.Font = Content.Load<SpriteFont>("Arial");
           

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        float spawn = 0;
        protected override void Update(GameTime gameTime)
        {

            int x = randX.Next(500);
            int size = randX.Next(40, 100);
            // TODO: Add your update code here
            spawn += (float)gameTime.ElapsedGameTime.TotalSeconds;
            foreach (Enemy Enemy in enemy)
            {
             Enemy.Update(graphics.GraphicsDevice);
             if (Enemy.Rectangle.Intersects(character.Rectangle))
             {
                 Enemy.position = new Vector2(x, x);
                 count--;
             }
            }
            
           character.Update(gameTime);
           mouseTex.Update(gameTime);
            int randpos = random.Next(-1000,3000);
           foreach (Gem Gem in gem)
           {
               Gem.Update(gameTime);
               if (Gem.Rectangle.Intersects(character.Rectangle))
               {
                   Gem.position = new Vector2(randpos, randpos);
                   hud.Score += 10;
                   winGemSpace += 50;
                   score++;
               }
           }
            foreach (Level Level in level)
                Level.Update(gameTime);

            

            /*if (count <= 0)
                     {
                         Game.Exit();
                     }*/
            loadEnemies();
            loadGems();
            base.Update(gameTime);
        }
        public void loadGems() {
            
                int randPos = random.Next(-1000, 1000);
                int randPos2 = random.Next(-1000, 3000);
                   if(gem.Count() < 50 ) 
                    gem.Add(new Gem(Content.Load<Texture2D>("Gem Blue"), new Vector2(randPos2,randPos)));
                
              
            
        }
        public void loadEnemies()
        {
            int randY = random.Next(100, 400);
           
            if (spawn >= 1)
            {
                spawn = 0;
                if (enemy.Count() < 1000)
                    enemy.Add(new Enemy(Content.Load<Texture2D>("Sword"), new Vector2(1100, 300)));
            }

          /*  for (int i = 0; i < enemy.Count; i++)
                if (!enemy[i].isVisible)
                {
                    enemy.RemoveAt(i);
                    i--;
                }*/
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //// TODO: Add your drawing code here
            spriteBatch.Begin();



            foreach (Level Level in level)
                Level.Draw(spriteBatch);

            
            if (count >= 1)
            {
                for (int i = 0; i < count; i++)
                {
                    heart[i].Draw(spriteBatch);
                }
            }

            foreach (Gem Gem in gem)
            {
                Gem.Draw(spriteBatch);
            }
            


         

            character.Draw(spriteBatch);
            mouseTex.Draw(spriteBatch);
            hud.Draw(spriteBatch);
             
            foreach (Enemy Enemy in enemy)
                Enemy.Draw(spriteBatch);

            spriteBatch.End();



            base.Draw(gameTime);
        }

    }
}
