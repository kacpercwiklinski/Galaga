using Galaga.Class.LevelScripts;
using Galaga.Class.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaga.Class {
    class Player {

        Texture2D playerTexture;
        Vector2 pos;
        float speed = 300f;
        float shootCooldown = 0f;
        public List<Bullet> bullets;


        public Player() {
            bullets = new List<Bullet>();
            playerTexture = Game1.textureManager.player;
            pos = new Vector2(Game1.WIDTH / 2, Game1.HEIGHT - Game1.HEIGHT / 10);
        }

        public void Update(GameTime theTime) {
            //Handle movement
            handlePlayerMovement(theTime);

            // Handle timers
            handleTimers(theTime);

            //Update bullets
            bullets.ForEach((bullet) => {
                bullet.update(theTime);
            });

            bullets = bullets.FindAll((bullet) => bullet.onScreen).FindAll((bullet)=> bullet.isTriggerable);
            }

        public void Draw(SpriteBatch theBatch) {

            //Draw player texture
            theBatch.Draw(playerTexture, new Vector2(this.pos.X - this.playerTexture.Width/2,this.pos.Y), Color.White);

            // Draw bullets
            bullets.ForEach((bullet) => {
                bullet.draw(theBatch);
            });
        }

        private void handleTimers(GameTime theTime) {
            if (this.shootCooldown > 0) {
                this.shootCooldown -= (float)theTime.ElapsedGameTime.TotalSeconds;
            }
        }

        private void handlePlayerMovement(GameTime theTime) {
            KeyboardState kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.A)) {
                this.pos.X -= speed * (float)theTime.ElapsedGameTime.TotalSeconds;
            } else if (kstate.IsKeyDown(Keys.D)) {
                this.pos.X += speed * (float)theTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Space) && this.shootCooldown <= 0) {
                shoot();
                this.shootCooldown = 0.2f;
            }
        }

        private void shoot() {
            bullets.Add(new Bullet(pos));
        }

        public class Bullet {
            Vector2 pos;
            public Boolean onScreen = true;
            float speed = 800f;
            public Rectangle boundingBox;
            public bool isVisible = true;
            public bool isTriggerable = true;

            public Bullet(Vector2 playerPos) {
                this.pos = new Vector2(playerPos.X - Game1.textureManager.bullet.Width/2,playerPos.Y);
            }

            public void update(GameTime theTime) {
                this.pos.Y -= speed * (float)theTime.ElapsedGameTime.TotalSeconds;

                boundingBox = new Rectangle((int)pos.X, (int)pos.Y, Game1.textureManager.bullet.Width, Game1.textureManager.bullet.Height);

                if (this.pos.Y < 0) this.onScreen = false;
            }

            public void draw(SpriteBatch theBatch) {
                theBatch.Draw(Game1.textureManager.bullet, pos, Color.White);
            }
        }
    }
}
