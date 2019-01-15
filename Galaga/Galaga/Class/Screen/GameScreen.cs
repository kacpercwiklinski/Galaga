﻿using Galaga.Class.EnemyScripts;
using Galaga.Class.LevelScripts;
using Galaga.Class.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaga.Class.Screen {
    class GameScreen : Screen{

        public static Player player;
        public Level level;
        List<Explosion> explosionsList = new List<Explosion>();
        Background background;

        public int score = 0;
        private SpriteFont scoreFont;


        public GameScreen(ContentManager theContent, EventHandler theScreenEvent) : base(theScreenEvent) {
            player = new Player();
            level = new Level();
            background = new Background();
            scoreFont = theContent.Load<SpriteFont>("font/scoreFont");


        }

        public override void Update(GameTime theTime) {
            level.update(theTime);
            player.Update(theTime);
            background.Update(theTime);


            if (Keyboard.GetState().IsKeyDown(Keys.X)) {
                level.nextWave();
            }


            // Aktualizacja przeciwnikow i test kolizji
            foreach (Enemy e in level.enemies)
            {
                //sprawdzenie kolzji pocisku gracza z przeciwnikiem
                for (int i = 0; i < player.bullets.Count; i++)
                {
                    if (player.bullets[i].boundingBox.Intersects(e.boundingBox) && player.bullets[i].isTriggerable)
                    {
                        explosionsList.Add(new Explosion(new Vector2(e.pos.X, e.pos.Y)));
                        player.bullets[i].isVisible = false;
                        player.bullets[i].isTriggerable = false;
                        e.isVisible = false;
                    }
                }
            }

            foreach (Explosion explosion in explosionsList) {
                explosion.Update(theTime);
            }

            //usuwanie eksplozji
            explosionsList = explosionsList.FindAll((explosion) => explosion.isVisible);
            
            base.Update(theTime);
        }

        public override void Draw(SpriteBatch theBatch) {


            background.Draw(theBatch);
            player.Draw(theBatch);
            level.draw(theBatch);

            

            // Draw player score on screen
            theBatch.DrawString(scoreFont, "" + score, new Vector2(1000, 360), Color.Yellow);


            foreach (Explosion explosion in explosionsList)
            {
                explosion.Draw(theBatch);
            }

            // Draw debug mouse point
            theBatch.Draw(Game1.textureManager.point, new Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y), Color.White);

            

            /*
            level.firstWaveEndpoints.ForEach((endpoint) => {
                theBatch.Draw(Game1.textureManager.point, endpoint, Color.White);
            });
            */
            /*
            level.secondWaveEndpoints.ForEach((endpoint) => {
                theBatch.Draw(Game1.textureManager.point, endpoint, Color.White);
            });
            
            level.thirdWaveEndpoints.ForEach((endpoint) => {
                theBatch.Draw(Game1.textureManager.point, endpoint, Color.White);
            });
            
            level.fourthWaveEndpoints.ForEach((endpoint) => {
                theBatch.Draw(Game1.textureManager.point, endpoint, Color.White);
            });
            */

            theBatch.Draw(Game1.textureManager.centerLine, new Vector2(Game1.WIDTH / 2, 0), Color.White);
            base.Draw(theBatch);
        }

        public void StartGame() {


        }

    }
}
