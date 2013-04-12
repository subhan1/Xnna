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
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class ChangeSoundVolume : Microsoft.Xna.Framework.DrawableGameComponent
    {

        Song song1;
        Song song2;

        KeyboardState nowState;
        KeyboardState prevState;

        // Volume

        AudioEngine engine;
        SoundBank soundBank;
        WaveBank waveBank;
        AudioCategory musicCategory;

        // Music volume

        float musicVolume = 1.0f;

        public ChangeSoundVolume(Game game)
            : base(game)
        {
            
        }
        public override void Initialize()
        {

            //engine = new AudioEngine("Content\\Audio\\ChangeSoundVolume.xgs");
            //soundBank = new SoundBank(engine, "Content\\Audio\\Sound Bank.xsb");
            //waveBank = new WaveBank(engine, "Content\\Audio\\Wave Bank.xwb");

            //musicCategory = engine.GetCategory("music");
            base.Initialize();
        }
        protected override void LoadContent()
        {
            song1 = Game.Content.Load<Song>("Music/song1");
            song2 = Game.Content.Load<Song>("Music/song2");

            MediaPlayer.Play(song1);
            base.LoadContent();
        }
        protected void UpdateInput()
        {
            nowState = Keyboard.GetState();
            if (Keyboard.GetState().IsKeyDown(Keys.D5))
            {
                musicVolume = MathHelper.Clamp(musicVolume + 0.01f, 0.0f, 2.0f);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D6))
            {
                musicVolume = MathHelper.Clamp(musicVolume - 0.01f, 0.0f, 2.0f);
            }

            // set the volume
            musicCategory.SetVolume(musicVolume);

            // If player pressed the gamepad thumbstick, move the sprite
            GamePadState gamepadState = GamePad.GetState(PlayerIndex.One);
            if (gamepadState.Buttons.RightStick != 0)
            {
                musicVolume = MathHelper.Clamp(musicVolume + 0.01f, 0.0f, 2.0f);
            }

            if (gamepadState.Buttons.RightStick != 0)
            {
                musicVolume = MathHelper.Clamp(musicVolume - 0.01f, 0.0f, 2.0f);
            }
                
        }
        public override void Update(GameTime gameTime)
        {
            //engine.Update();
            
            nowState = Keyboard.GetState();

            // bytte med 1 
            if (Keyboard.GetState().IsKeyDown(Keys.D1))
            {
                MediaPlayer.Play(song1);
                // bytte med 2
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D2))
                MediaPlayer.Play(song2);

            if (prevState.IsKeyUp(Keys.P) && nowState.IsKeyDown(Keys.P))
            {
                if (MediaPlayer.State == MediaState.Paused)
                {
                    MediaPlayer.Resume();
                }
                    else
                    {
                        if (MediaPlayer.State == MediaState.Playing)
                        {
                            MediaPlayer.Pause();
                        }
                    }

                }
            if (prevState.IsKeyUp(Keys.S) && nowState.IsKeyDown(Keys.S))
            {
                if (MediaPlayer.State == MediaState.Stopped)
                {
                    MediaPlayer.Resume();
                }
                else
                {
                    if (MediaPlayer.State == MediaState.Playing)
                    {
                        MediaPlayer.Stop();
                    }
                }
            }
            GamePadState gamepadState = GamePad.GetState(PlayerIndex.One);
            if (gamepadState.Buttons.A != 0)
            {
                MediaPlayer.Play(song1);
            }
                
            if (gamepadState.Buttons.B != 0)
                MediaPlayer.Play(song2);

                base.Update(gameTime);
            }
        }
    }

