using Galaga.Class.EnemyScripts;
using Galaga.Class.LevelScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaga.Class.Screen {
    class GameScreen : Screen{

        public static Player player;
        public Level level;

        public GameScreen(ContentManager theContent, EventHandler theScreenEvent) : base(theScreenEvent) {
            player = new Player();
            level = new Level();
        }

        public override void Update(GameTime theTime) {
            level.update(theTime);
            player.Update(theTime);

            base.Update(theTime);
        }

        public override void Draw(SpriteBatch theBatch) {
            player.Draw(theBatch);
            level.draw(theBatch);

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
            */

            level.fourthWaveEndpoints.ForEach((endpoint) => {
                theBatch.Draw(Game1.textureManager.point, endpoint, Color.White);
            });

            theBatch.Draw(Game1.textureManager.centerLine, new Vector2(Game1.WIDTH / 2, 0), Color.White);
            base.Draw(theBatch);
        }

        public void StartGame() {


        }
    }
}
