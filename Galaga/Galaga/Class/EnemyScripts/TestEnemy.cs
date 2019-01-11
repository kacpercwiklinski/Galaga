using Galaga.Class.LevelScripts;
using Galaga.Class.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaga.Class.EnemyScripts {
    class TestEnemy {

        Texture2D texture;
        float t;
        Vector2 pos;
        Level level;
        float counter = 0f;

        public TestEnemy(float _t, Level _level) {
            t = _t;
            level = _level; 
            texture = Game1.textureManager.enemy2.First();
        }

        public void Update(GameTime theTime) {
            counter += (float)theTime.ElapsedGameTime.TotalSeconds;

            Animator.animate(theTime, ref this.texture, Game1.textureManager.enemy2, 0.4f, ref counter, true);

            this.pos = level.getCurrentLevelPath().getPoint(t);
            t += 0.005f;
            t = t > 3 ? 0 : t;
        }

        public void Draw(SpriteBatch theBatch) {
            theBatch.Draw(texture, pos, Color.White);
        }
    }

}
