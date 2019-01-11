using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaga.Class.LevelScripts {
    public class Level {
        public int levelIndex = 1;

        public Level() {
            initializeLevel(levelIndex);
        }

        private void initializeLevel(int levelIndex) {
            if (levelIndex == 0) return;

            setupPath(levelIndex);
            spawnEnemies(levelIndex);
        }

        private void setupPath(int levelIndex) {
            switch (levelIndex) {
                case 1:
                    Paths.path1.setupCurve(0,new Vector2(15, 15), new Vector2(Game1.WIDTH / 2, Game1.HEIGHT / 2 + 100), new Vector2(Game1.WIDTH / 2, Game1.HEIGHT / 2), new Vector2(Game1.WIDTH/2, Game1.HEIGHT));
                    Paths.path1.setupCurve(1, new Vector2(Game1.WIDTH/2, Game1.HEIGHT), new Vector2(0,0), new Vector2(Game1.WIDTH,Game1.HEIGHT), new Vector2(Game1.WIDTH / 2 + 100, Game1.HEIGHT - 100));
                    Paths.path1.setupCurve(2, new Vector2(Game1.WIDTH / 2 + 100, Game1.HEIGHT - 100), new Vector2(0,Game1.HEIGHT), new Vector2(Game1.WIDTH,0), new Vector2(Game1.WIDTH / 2, Game1.HEIGHT/2));
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

        public Path getCurrentLevelPath() {
            switch (levelIndex) {
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

        private void spawnEnemies(int levelIndex) {
            switch (levelIndex) {
                case 1:
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
