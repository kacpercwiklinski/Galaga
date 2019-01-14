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
    class TestEnemy {

        Texture2D texture;
        Vector2 pos;
        Level level;
        float speed = 300f;
        float counter = 0f;

        private float angle = 0;

        Vector2 followedPoint;
        int followedPointIdx = 0;

        public TestEnemy(Level _level) {
            level = _level; 
            texture = Game1.textureManager.enemy2.First();
            followedPoint = level.getCurrentWavePath().getNextFollowedPoint(followedPointIdx);
            followedPointIdx++;
            pos = level.getCurrentWavePath().startingPoint;
        }

        public void Update(GameTime theTime) {
            counter += (float)theTime.ElapsedGameTime.TotalSeconds;

            Animator.animate(theTime, ref this.texture, Game1.textureManager.enemy2, 0.4f, ref counter, true);

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

            if(distance < 20f || this.pos == followedPoint) {
                followedPoint = level.getCurrentWavePath().getNextFollowedPoint(followedPointIdx);
                followedPointIdx++;
            } else {
                this.pos += Vector2.Multiply(dir, this.speed * (float)theTime.ElapsedGameTime.TotalSeconds);
            }

        }
    }

}
