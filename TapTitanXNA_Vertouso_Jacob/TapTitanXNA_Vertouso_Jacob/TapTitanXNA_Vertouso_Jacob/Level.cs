using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TapTitanXNA_Vertouso_Jacob
{
    public class Level
    {
        public static int windowWidth = 400;
        public static int windowHeight = 500;

        #region
        Texture2D bg;
        public MouseState oldMouseState;
        ContentManager content;
        Hero hero;
        Hero hero1;
        public MouseState mouseState;
        SpriteFont damageStringFont;
        Button playButton;
        //Button attackButton;
        bool mpressed, prev_mpressed = false;
        int damageNumber = 0;
        int mouseX, mouseY;
        #endregion

        public Level(ContentManager content)
        {
            this.content = content;

            hero = new Hero(content, this);
            //hero1 = new Hero(content, this);

        }

        public void LoadContent ()
        {
            
            bg = content.Load<Texture2D>("hero/gamebg");
            damageStringFont = content.Load<SpriteFont>("Font");

           playButton = new Button(content,"hero/button", new Vector2(60,380));
           //attackButton = new Button(content, "hero/button", Vector2.Zero);
            hero.LoadContent();
            //hero1.LoadContent();
        }

        public void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();
            mouseX = mouseState.X;
            mouseY = mouseState.Y;
            prev_mpressed = mpressed;
            mpressed = mouseState.LeftButton == ButtonState.Pressed;
            hero.Update(gameTime);

            oldMouseState = mouseState;

            if (playButton.Update(gameTime, mouseX, mouseY, mpressed, prev_mpressed))
            {
                damageNumber += 1;
            }
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bg, new Vector2(0,0), null, Color.White, 0.0f, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
            
            hero.Draw(gameTime, spriteBatch);

            spriteBatch.DrawString(damageStringFont, damageNumber + " damage!", Vector2.Zero, Color.White);

            playButton.Draw(gameTime, spriteBatch);
        }
    }
}
