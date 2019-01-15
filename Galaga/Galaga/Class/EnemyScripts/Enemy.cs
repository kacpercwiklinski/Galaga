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
using static Galaga.Class.Player;

namespace Galaga.Class.EnemyScripts {
    public class Enemy {

        const float SHOOT_RATE = 2f;

        Texture2D texture;
        List<Texture2D> textureList;
        public Vector2 pos;
        public String label = "Yellow";
        Level level;
        float speed = 500f;
        float counter = 0f;
        float shootCounter = 0f;
        float shootChance = 0.005f;
        int enemyTexture = 0;
        Random random;

        List<Bullet> bullets;

        Boolean reversed = false;
        Boolean finishedPath = false;
        Boolean end = false;
        Boolean onEndPoint = false;

        private float angle = 0;

        Vector2 followedPoint;
        int followedPointIdx = 0;

        public Rectangle boundingBox;
        public bool isVisible;

        public Enemy(Level _level, bool _reversed) {
            random = new Random();
            enemyTexture = random.Next(1, 4);
            level = _level;
            reversed = _reversed;
            finishedPath = false;
            end = false;
            onEndPoint = false;
            switch (enemyTexture) {
                case 1:
                    texture = Game1.textureManager.enemy1.First();
                    textureList = Game1.textureManager.enemy1;
                    label = "Boss";
                    break;
                case 2:
                    texture = Game1.textureManager.enemy2.First();
                    textureList = Game1.textureManager.enemy2;
                    label = "Blue";
                    break;
                case 3:
                    label = "Red";
                    texture = Game1.textureManager.enemy3.First();
                    textureList = Game1.textureManager.enemy3;
                    break;
            }
            followedPoint = level.getCurrentWavePath().getNextFollowedPoint(followedPointIdx);
            followedPointIdx++;
            pos = level.getCurrentWavePath().startingPoint;
            bullets = new List<Bullet>();
            if (reversed) {
                float reflectedX = followedPoint.X + (2 * (Game1.WIDTH / 2 - followedPoint.X));
                followedPoint = new Vector2(reflectedX, followedPoint.Y);
                pos = new Vector2(level.getCurrentWavePath().startingPoint.X + (2 * (Game1.WIDTH / 2 - level.getCurrentWavePath().startingPoint.X)), level.getCurrentWavePath().startingPoint.Y);
            }
            isVisible = true;
        }

        public void Update(GameTime theTime) {
            
            boundingBox = new Rectangle((int)pos.X - texture.Width/2, (int)pos.Y, texture.Width, texture.Height);

            counter += (float)theTime.ElapsedGameTime.TotalSeconds;
            shootCounter += (float)theTime.ElapsedGameTime.TotalSeconds;

            if(shootCounter > SHOOT_RATE && (float)random.NextDouble() < shootChance) {
                shoot();
                shootCounter = 0f;
            }

            Animator.animate(theTime, ref this.texture, textureList, 0.4f, ref counter, true);

            bullets.ForEach((bullet) => bullet.update(theTime));

            checkBulletsCollisions();

            followPoint(theTime);
        }

        private void checkBulletsCollisions() {
            bullets.ForEach((bullet) => {
                if (bullet.boundingBox.Intersects(Player.boundingBox) && bullet.isTriggerable) {
                    Player.explode();
                }
            });
        }

        public void Draw(SpriteBatch theBatch) {
            theBatch.Draw(texture, pos, new Rectangle(0, 0, texture.Width, texture.Height), Color.White, angle, new Vector2(texture.Width / 2, 0), -1.0f, SpriteEffects.None, 1);
            bullets.ForEach((bullet) => bullet.draw(theBatch));
        }

        private void followPoint(GameTime theTime) {
            Vector2 dir = Vector2.Normalize(followedPoint - pos);
            
            angle = (float)Math.Atan2(-dir.X, dir.Y);
            
            float distance = Vector2.Distance(pos, followedPoint);

            if(distance < 20f && !finishedPath) {
                followedPoint = level.getCurrentWavePath().getNextFollowedPoint(followedPointIdx);
                if(followedPoint == level.getCurrentWavePath().lastPoint) {
                    finishedPath = true;
                }
                if (reversed) {
                    float reflectedX = followedPoint.X + (2 * (Game1.WIDTH / 2 - followedPoint.X));
                    followedPoint = new Vector2(reflectedX, followedPoint.Y);
                }
                followedPointIdx++;
            } else {
                if (finishedPath && !end) {
                    followedPoint = level.getEndpoint();
                    end = true;
                }
                if (!onEndPoint) {
                    this.pos += Vector2.Multiply(dir, this.speed * (float)theTime.ElapsedGameTime.TotalSeconds);
                    if(Vector2.Distance(followedPoint,this.pos) < 5f && end) {
                        onEndPoint = true;
                    }
                } else {
                    angle = (float)Math.PI;
                }
            }

        }

        private void shoot() {
            bullets.Add(new Bullet(pos, new Vector2(0, 1),500f,true));
        }
    }

}
