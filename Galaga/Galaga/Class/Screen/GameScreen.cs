using Galaga.Class.EnemyScripts;
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


        public GameScreen(ContentManager theContent, EventHandler theScreenEvent) : base(theScreenEvent) {
            player = new Player(this);
            level = new Level();
            background = new Background();
            
          
        }

        public override void Update(GameTime theTime) {
            level.update(theTime);
            player.Update(theTime);
            background.Update(theTime);
            
            // Aktualizacja przeciwnikow i test kolizji
            foreach (Enemy e in level.enemies)
            {
                //sprawdzenie kolzji pocisku gracza z przeciwnikiem
                for (int i = 0; i < player.bullets.Count; i++){
                    if (player.bullets[i].boundingBox.Intersects(e.boundingBox) && player.bullets[i].isTriggerable){
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

            // Remove explosion animations
            explosionsList = explosionsList.FindAll((explosion) => explosion.isVisible);
            
            base.Update(theTime);
        }

        public override void Draw(SpriteBatch theBatch) {
            background.Draw(theBatch);
            player.Draw(theBatch);
            level.draw(theBatch);

            foreach (Explosion explosion in explosionsList){
                explosion.Draw(theBatch);
            }
            
            base.Draw(theBatch);
        }

        public void gameOver() {
            ScreenEvent.Invoke(this, new EventArgs());
        }

        public void StartGame() {
            player = new Player(this);
            level = new Level();
            background = new Background();
        }
    }
}
