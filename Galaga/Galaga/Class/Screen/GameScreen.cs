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

        public GameScreen(ContentManager theContent, EventHandler theScreenEvent) : base(theScreenEvent) {
            player = new Player();
        }

        public override void Update(GameTime theTime) {
            player.Update(theTime);

            base.Update(theTime);
        }

        public override void Draw(SpriteBatch theBatch) {

            player.Draw(theBatch);

            theBatch.Draw(Game1.textureManager.centerLine, new Vector2(Game1.WIDTH / 2, 0), Color.White);

            base.Draw(theBatch);
        }

        public void StartGame() {


        }
    }
}
