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
        List<Vector2> bezierPoints = new List<Vector2>();
        float t;
        Vector2 pos;
        float counter = 0f;

        public TestEnemy(float _t) {
            t = _t;
            texture = Game1.textureManager.enemy2.First();
            bezierPoints.Add(new Vector2(15, 15));
            bezierPoints.Add(new Vector2(Game1.WIDTH/2, Game1.HEIGHT/2 + 100));
            bezierPoints.Add(new Vector2(Game1.WIDTH/2, Game1.HEIGHT/2));
            bezierPoints.Add(new Vector2(Game1.WIDTH - 15, 15));
        }

        public void Update(GameTime theTime) {
            counter += (float)theTime.ElapsedGameTime.TotalSeconds;

            Animator.animate(theTime, ref this.texture, Game1.textureManager.enemy2, 0.4f, ref counter, true);

            this.pos = BezierCurve.GetPoint(t, bezierPoints.ElementAt(0), bezierPoints.ElementAt(1), bezierPoints.ElementAt(2), bezierPoints.ElementAt(3));
            t += 0.005f;
            t = t > 1 ? 0 : t;
        }

        public void Draw(SpriteBatch theBatch) {
            theBatch.Draw(texture, pos, Color.White);
        }
    }

}
