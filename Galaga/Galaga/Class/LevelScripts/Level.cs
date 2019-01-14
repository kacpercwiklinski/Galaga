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

        public int wave = 1;
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

            setupPath(levelIndex);
            spawnEnemies(levelIndex);
            
        }

        private void setupPath(int levelIndex) {
            switch (levelIndex) {
                case 1:
                    Paths.path1.setupCurve(0, new Vector2(540, 2), new Vector2(538, 183), new Vector2(703, 523), new Vector2(368, 513));
                    Paths.path1.setupCurve(1, new Vector2(368, 513), new Vector2(196, 558), new Vector2(7, 504), new Vector2(39, 195));
                    Paths.path1.setupCurve(2, new Vector2(39, 195), new Vector2(191, 97), new Vector2(438, 169), new Vector2(528, 363));
                    Paths.path1.setupPointsList();
                    break;
                case 2:
                    Paths.path2.setupCurve(0, new Vector2(), new Vector2(), new Vector2(), new Vector2());
                    Paths.path2.setupCurve(1, new Vector2(), new Vector2(), new Vector2(), new Vector2());
                    Paths.path2.setupCurve(2, new Vector2(), new Vector2(), new Vector2(), new Vector2());
                    break;
                case 3:
                    Paths.path3.setupCurve(0, new Vector2(), new Vector2(), new Vector2(), new Vector2());
                    Paths.path3.setupCurve(1, new Vector2(), new Vector2(), new Vector2(), new Vector2());
                    Paths.path3.setupCurve(2, new Vector2(), new Vector2(), new Vector2(), new Vector2());
                    break;
                case 4:
                    Paths.path4.setupCurve(0, new Vector2(), new Vector2(), new Vector2(), new Vector2());
                    Paths.path4.setupCurve(1, new Vector2(), new Vector2(), new Vector2(), new Vector2());
                    Paths.path4.setupCurve(2, new Vector2(), new Vector2(), new Vector2(), new Vector2());
                    break;
            }
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
                    if (spawnCounter <= 0f) {
                        enemies.Add(new TestEnemy(this));
                        spawnCounter = SPAWN_RATE;
                    }
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }
    }
}
