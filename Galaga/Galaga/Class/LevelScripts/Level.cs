using Galaga.Class.EnemyScripts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaga.Class.LevelScripts {
    public class Level {

        const float SPAWN_RATE = 0.3f;

        public int wave = 3;
        List<TestEnemy> enemies;
        float spawnCounter = SPAWN_RATE;

        public Level() {
            enemies = new List<TestEnemy>();
            initializeLevel(wave);
        }

        public void update(GameTime theTime) { 
            spawnEnemies(wave);
            spawnCounter -= (float)theTime.ElapsedGameTime.TotalSeconds;

            // Update Enemies
            enemies.ForEach((enemy) => {
                enemy.Update(theTime);
            });

        }

        public void draw(SpriteBatch theBatch) {
            // Draw Enemies
            enemies.ForEach((enemy) => {
                enemy.Draw(theBatch);
            });
        }

        private void initializeLevel(int levelIndex) {
            if (levelIndex == 0) return;

            setupPaths();
            spawnEnemies(levelIndex);
            
        }

        private void setupPaths() {
            // Path 1
            Paths.path1.setupCurve(0, new Vector2(540, 2), new Vector2(538, 183), new Vector2(703, 523), new Vector2(368, 513));
            Paths.path1.setupCurve(1, new Vector2(368, 513), new Vector2(196, 558), new Vector2(7, 504), new Vector2(39, 195));
            Paths.path1.setupCurve(2, new Vector2(39, 195), new Vector2(191, 97), new Vector2(438, 169), new Vector2(528, 363));
            Paths.path1.setupPointsList();

            // Path 2
            Paths.path2.setupCurve(0, new Vector2(0, 144), new Vector2(104, 52), new Vector2(200, 49), new Vector2(358, 204));
            Paths.path2.setupCurve(1, new Vector2(358, 204), new Vector2(462, 380), new Vector2(579, 396), new Vector2(797, 225));
            Paths.path2.setupCurve(2, new Vector2(797, 225), new Vector2(670, 104), new Vector2(428, 68), new Vector2(395, 205));
            Paths.path2.setupPointsList();

            // Path 3
            Paths.path3.setupCurve(0, new Vector2(0, 485), new Vector2(294, 280), new Vector2(43, 260), new Vector2(179, 201));
            Paths.path3.setupCurve(1, new Vector2(179, 201), new Vector2(385, 86), new Vector2(509, 197), new Vector2(501, 320));
            Paths.path3.setupCurve(2, new Vector2(501, 320), new Vector2(485, 420), new Vector2(375, 448), new Vector2(298, 264));
            Paths.path3.setupPointsList();

            // Path 4
            Paths.path4.setupCurve(0, new Vector2(), new Vector2(), new Vector2(), new Vector2());
            Paths.path4.setupCurve(1, new Vector2(), new Vector2(), new Vector2(), new Vector2());
            Paths.path4.setupCurve(2, new Vector2(), new Vector2(), new Vector2(), new Vector2());
            Paths.path4.setupPointsList();
        }

        public Path getCurrentWavePath() {
            switch (wave) {
                case 1:
                    return Paths.path1;
                case 2:
                    return Paths.path2;
                case 3:
                    return Paths.path3;
                case 4:
                    return Paths.path4;
                default:
                    return new Path();
            }
        }

        private void spawnEnemies(int waveIndex) {
            switch (waveIndex) {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }

            if (spawnCounter <= 0f) {
                enemies.Add(new TestEnemy(this, true));
                enemies.Add(new TestEnemy(this, false));
                spawnCounter = SPAWN_RATE;
            }
            
        }
    }
}
