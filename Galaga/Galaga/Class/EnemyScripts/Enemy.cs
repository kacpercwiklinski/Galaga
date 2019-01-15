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

namespace Galaga.Class.EnemyScripts {
    class Enemy {

        Texture2D texture;
        Vector2 pos;
        Level level;
        float speed = 300f;
        float counter = 0f;

        Boolean reversed = false;
        Boolean finishedPath = false;
        Boolean end = false;
        Boolean onEndPoint = false;

        private float angle = 0;

        Vector2 followedPoint;
        int followedPointIdx = 0;

        public Enemy(Level _level, bool _reversed) {
            level = _level;
            reversed = _reversed;
            texture = Game1.textureManager.enemy1.First();
            followedPoint = level.getCurrentWavePath().getNextFollowedPoint(followedPointIdx);
            followedPointIdx++;
            pos = level.getCurrentWavePath().startingPoint;
            if (reversed) {
                float reflectedX = followedPoint.X + (2 * (Game1.WIDTH / 2 - followedPoint.X));
                followedPoint = new Vector2(reflectedX, followedPoint.Y);
                pos = new Vector2(level.getCurrentWavePath().startingPoint.X + (2 * (Game1.WIDTH / 2 - level.getCurrentWavePath().startingPoint.X)), level.getCurrentWavePath().startingPoint.Y);
            }
        }

        public void Update(GameTime theTime) {
            counter += (float)theTime.ElapsedGameTime.TotalSeconds;

            Animator.animate(theTime, ref this.texture, Game1.textureManager.enemy1, 0.4f, ref counter, true);

            var mouseState = Mouse.GetState();

            followPoint(theTime);

            /*
            this.pos = level.getCurrentLevelPath().getPoint(t);
            t += 0.005f;
            t = t > 3 ? 0 : t;
            */
        }

        public void Draw(SpriteBatch theBatch) {
            theBatch.Draw(texture, pos, new Rectangle(0, 0, texture.Width, texture.Height), Color.White, angle, new Vector2(texture.Width / 2, 0), -1.0f, SpriteEffects.None, 1);
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
    }

}
