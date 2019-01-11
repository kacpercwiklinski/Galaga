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
                    Paths.path1.setupCurve(0,new Vector2(0, 289), new Vector2(281, 166), new Vector2(75, 121), new Vector2(209, 270));
                    Paths.path1.setupCurve(1, new Vector2(209, 270), new Vector2(416, 462), new Vector2(778, 159), new Vector2(433, 108));
                    Paths.path1.setupCurve(2, new Vector2(433, 108), new Vector2(1231, 176), new Vector2(1106, 656), new Vector2(929, 250));
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
