using Galaga.Class.LevelScripts;
using Galaga.Class.Screen;
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
        GameScreen gameScreen;
        Vector2 pos;
        float speed = 300f;
        float shootCooldown = 0f;
        public List<Bullet> bullets;
        public static Rectangle boundingBox;
        static Boolean destroyed;
        float counter = 0f;

        public Player(GameScreen gs) {
            gameScreen = gs;
            bullets = new List<Bullet>();
            playerTexture = Game1.textureManager.player;
            destroyed = false;
            pos = new Vector2(Game1.WIDTH / 2, Game1.HEIGHT - Game1.HEIGHT / 10);
            boundingBox = new Rectangle((int)pos.X, (int)pos.Y, playerTexture.Width, playerTexture.Height);
        }

        public void Update(GameTime theTime) {
            //Handle movement
            handlePlayerMovement(theTime);

            // Update bounding box
            updateBoundingBox();

            // Handle timers
            handleTimers(theTime);

            //Update bullets
            bullets.ForEach((bullet) => {
                bullet.update(theTime);
            });

            if (destroyed) {
                Animator.animate(theTime,ref playerTexture,Game1.textureManager.playerExplosion,0.3f,ref counter,true);
                if (playerTexture.Equals(Game1.textureManager.playerExplosion.Last())) {
                    gameScreen.gameOver();
                }
            }

            bullets = bullets.FindAll((bullet) => bullet.onScreen).FindAll((bullet)=> bullet.isTriggerable);
        }

        private void updateBoundingBox() {
            boundingBox = new Rectangle((int)pos.X, (int)pos.Y, playerTexture.Width, playerTexture.Height);
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
            counter += (float)theTime.ElapsedGameTime.TotalSeconds;
            if (this.shootCooldown > 0) {
                this.shootCooldown -= (float)theTime.ElapsedGameTime.TotalSeconds;
            }
        }

        private void handlePlayerMovement(GameTime theTime) {
            KeyboardState kstate = Keyboard.GetState();

            if (kstate.IsKeyDown(Keys.A) && !destroyed) {
                this.pos.X -= speed * (float)theTime.ElapsedGameTime.TotalSeconds;
            } else if (kstate.IsKeyDown(Keys.D) && !destroyed) {
                this.pos.X += speed * (float)theTime.ElapsedGameTime.TotalSeconds;
            }

            if (kstate.IsKeyDown(Keys.Space) && this.shootCooldown <= 0 && !destroyed) {
                shoot();
                this.shootCooldown = 0.4f;
            }
        }

        private void shoot() {
            bullets.Add(new Bullet(pos, new Vector2(0,-1),400f,false));
        }

        public static void explode() {
            destroyed = true;
        }

        public class Bullet {
            Vector2 pos;
            public Boolean onScreen = true;
            float speed = 800f;
            public Vector2 dir;
            Texture2D texture;
            public Rectangle boundingBox;
            public bool isVisible = true;
            public bool isTriggerable = true;

            public Bullet(Vector2 playerPos, Vector2 _dir,float _speed, bool _enemyBullet) {
                dir = _dir;
                speed = _speed;
                if (!_enemyBullet) {
                    this.texture = Game1.textureManager.bullet;
                } else {
                    this.texture = Game1.textureManager.enemyBullet;
                }
                this.pos = new Vector2(playerPos.X - Game1.textureManager.bullet.Width/2,playerPos.Y);
            }

            public void update(GameTime theTime) {
                this.pos.Y += this.dir.Y * speed * (float)theTime.ElapsedGameTime.TotalSeconds;

                boundingBox = new Rectangle((int)pos.X, (int)pos.Y, Game1.textureManager.bullet.Width, Game1.textureManager.bullet.Height);

                if (this.pos.Y < 0) this.onScreen = false;
            }

            public void draw(SpriteBatch theBatch) {

                theBatch.Draw(texture, pos, Color.White);
            }
        }
    }
}
