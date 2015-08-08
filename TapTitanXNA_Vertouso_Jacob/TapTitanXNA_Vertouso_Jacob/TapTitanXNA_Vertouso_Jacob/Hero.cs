using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace TapTitanXNA_Vertouso_Jacob
{
    public class Hero
    {
        #region Properties
        Vector2 playerPosition;
        Texture2D player;
        //Texture2D player1;
        ContentManager content;
        Level level;
        Texture2D support;
        Vector2 supportPosition;
        Animation supportAnimation;
        Animation idleAnimation;
        Animation attackAnimation;
        AnimationPlayer spritePlayer;
        AnimationPlayer supportPlayer;
        AnimationPlayer bossPlayer;
        Texture2D boss;
        Vector2 bossPosition;
        Animation bossAnimation;
        Animation supportAttack;
        Animation bossHit;

        Texture2D finn;
        Animation finnAnimation;
        AnimationPlayer finnPlayer;
        Vector2 finnPosition;
        int dk = 0;

        int y1 = 0;
        int playerDamage = 0;
        SpriteFont damageStringFont;
        int enemyHp = 500;
        SpriteFont HpStringFont;
        String s1 = "Idle";

        
        #endregion

        public Hero(ContentManager content, Level level)
        {
            this.content = content;
            this.level = level;
        }

        public void LoadContent()
        {
            if (dk== 0)
            
            {
                
                player = content.Load<Texture2D>("hero/dk-idle");
                idleAnimation = new Animation(player, 0.1f, true, 2);
                int positionX = (Level.windowWidth / 2) - (player.Width / 4)-30;
                int positionY = (Level.windowHeight / 2) - (player.Height / 4) + 80;
                playerPosition = new Vector2((float)positionX, (float)positionY);
               
                support = content.Load<Texture2D>("hero/link");
                supportAnimation = new Animation(support, 0.1f, true, 4);
                int support_positionX = (Level.windowWidth / 2) - (support.Width / 4) + 110;
                int support_positionY = (Level.windowHeight / 2) - (support.Height / 4) + 70;
                supportPosition = new Vector2((float)support_positionX, (float)support_positionY);

                boss = content.Load<Texture2D>("hero/boss2");
                bossAnimation = new Animation(boss, 0.1f, true, 7);
                int boss_positionX = (Level.windowWidth / 2) - (support.Width / 4) ;
                int boss_positionY = (Level.windowHeight / 2) - (support.Height / 4) + 30;
                bossPosition = new Vector2((float)boss_positionX, (float)boss_positionY);

              

             }

                finn = content.Load<Texture2D>("hero/at");
                finnAnimation = new Animation(finn, 0.1f, true, 8);
                int finn_positionX = (Level.windowWidth / 2) - (finn.Width / 4);
                int finn_positionY = (Level.windowHeight / 2) - (finn.Height / 4) +75;
                finnPosition = new Vector2((float)finn_positionX, (float)finn_positionY);
            
                damageStringFont = content.Load<SpriteFont>("Font");
                HpStringFont = content.Load<SpriteFont>("Font");
                spritePlayer.PlayAnimation(idleAnimation);
                supportPlayer.PlayAnimation(supportAnimation);
                bossPlayer.PlayAnimation(bossAnimation);
                finnPlayer.PlayAnimation(finnAnimation);
      
        }

        public void Update(GameTime gameTime)
        {
         
            if (level.mouseState.LeftButton == ButtonState.Pressed && 
                level.oldMouseState.LeftButton == ButtonState.Released)
            {
                        y1 = 0;
                        
                        player = content.Load<Texture2D>("hero/dk-attack1");
                        attackAnimation = new Animation(player, 0.1f, false, 8);
                        int positionX = (Level.windowWidth / 2) - (player.Width / 4)+30 ;
                        int positionY = (Level.windowHeight / 2) - (player.Height / 4) + 80;
                        playerPosition = new Vector2((float)positionX, (float)positionY);

                        support = content.Load<Texture2D>("hero/linkAttack");
                        
                        supportAttack = new Animation(support, 0.1f, false, 6);
                        int support_positionX = (Level.windowWidth / 2) - (support.Width / 4) + 140;
                        int support_positionY = (Level.windowHeight / 2) - (support.Height / 4) + 65;
                        supportPosition = new Vector2((float)support_positionX, (float)support_positionY);


                        boss = content.Load<Texture2D>("hero/bossHit");
                        bossHit = new Animation(boss, 0.1f, true, 7);
                        int boss_positionX = (Level.windowWidth / 2) - (support.Width / 4) + 80;
                        int boss_positionY = (Level.windowHeight / 2) - (support.Height / 4) + 30;
                        bossPosition = new Vector2((float)boss_positionX, (float)boss_positionY);

                        spritePlayer.PlayAnimation(attackAnimation);
                        supportPlayer.PlayAnimation(supportAttack);
                        bossPlayer.PlayAnimation(bossHit);

                        

                        s1 = "attack";
                        enemyHp--;


                        playerDamage = 1;                  
                    
                
            }

            if (s1 == "Idle")
            {

            }
            else if (s1 == "attack")
            {
                //Trace.Write(supportPlayer.varStop + ",");
                if (supportPlayer.varStop == 5) 
                {
                    int support_positionX = (Level.windowWidth / 2) - (support.Width / 4) + 180;
                    int support_positionY = (Level.windowHeight / 2) - (support.Height / 4) + 75;
                    supportPosition = new Vector2((float)support_positionX, (float)support_positionY);
                    supportPlayer.PlayAnimation(supportAnimation);


                    int positionX = (Level.windowWidth / 2) - (player.Width / 4) +30;
                    int positionY = (Level.windowHeight / 2) - (player.Height / 4) + 80;
                    playerPosition = new Vector2((float)positionX, (float)positionY);
                    spritePlayer.PlayAnimation(idleAnimation);


                    int boss_positionX = (Level.windowWidth / 2) - (support.Width / 4)+80;
                    int boss_positionY = (Level.windowHeight / 2) - (support.Height / 4) + 30;
                    bossPosition = new Vector2((float)boss_positionX, (float)boss_positionY);
                    bossPlayer.PlayAnimation(bossAnimation);
                    s1 = "idle";

                    
                }
              
            }

        }


        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(player, playerPosition, null, Color.White, 0.0f, Vector2.Zero, 1.0f, SpriteEffects.None, 0);

            spritePlayer.Draw(gameTime, spriteBatch, playerPosition, SpriteEffects.None);
            supportPlayer.Draw(gameTime, spriteBatch, supportPosition, SpriteEffects.None);
            bossPlayer.Draw(gameTime, spriteBatch, bossPosition, SpriteEffects.None);
            finnPlayer.Draw(gameTime, spriteBatch, finnPosition, SpriteEffects.None);

            y1 -= 5;
            spriteBatch.DrawString(damageStringFont, "-" + playerDamage + " Hp", new Vector2(190, y1 + 250), Color.Red);
            spriteBatch.DrawString(HpStringFont, enemyHp  +" Hp", new Vector2(100, /*y1 +*/ 250), Color.Black);
                
        }


       
    }
}
