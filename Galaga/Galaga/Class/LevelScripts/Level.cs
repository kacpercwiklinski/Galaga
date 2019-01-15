using Galaga.Class.EnemyScripts;
using Galaga.Class.Utils;
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

    

        const float SPAWN_RATE = 0.7f;
        const int MAX_ENEMIES = 9;

        int stage = 1;

        public int wave = 1;
        private List<Enemy> enemies = new List<Enemy>();
        float spawnCounter = SPAWN_RATE;

        public List<Vector2> firstWaveEndpoints;
        public List<Vector2> secondWaveEndpoints;
        public List<Vector2> thirdWaveEndpoints;
        public List<Vector2> fourthWaveEndpoints;

        internal List<Enemy> Enemies { get => enemies; set => enemies = value; }

        public Level() {
            
            firstWaveEndpoints = new List<Vector2>();
            secondWaveEndpoints = new List<Vector2>();
            thirdWaveEndpoints = new List<Vector2>();
            fourthWaveEndpoints = new List<Vector2>();
            initializeLevel(wave);
        }

        public void update(GameTime theTime)
        {
            spawnEnemies();
            spawnCounter -= (float)theTime.ElapsedGameTime.TotalSeconds;

            // Update Enemies
            Enemies.ForEach((enemy) =>
            {
                enemy.Update(theTime);
            });



           




        }

        public void draw(SpriteBatch theBatch) {
            // Draw Enemies
            Enemies.ForEach((enemy) => {
                enemy.Draw(theBatch);
            });
        }

        private void initializeLevel(int levelIndex) {
            wave = 1;

            setupPaths();
            spawnEnemies();
            setupEndpoints();
        }

        public void nextWave() {
            Enemies.Clear();
            if(wave + 1 == 5) {
                setupEndpoints();
                nextStage();
            } else {
                wave++;
            }
        }
        
        private void nextStage() {
            stage++;
            wave = 1;
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
            Paths.path4.setupCurve(0, new Vector2(0, 705), new Vector2(281, 666), new Vector2(584, 594), new Vector2(546, 355));
            Paths.path4.setupCurve(1, new Vector2(546, 355), new Vector2(520, 175), new Vector2(257, 155), new Vector2(52, 243));
            Paths.path4.setupCurve(2, new Vector2(52, 243), new Vector2(228, 398), new Vector2(487, 403), new Vector2(563, 233));
            Paths.path4.setupPointsList();
        }

        private void setupEndpoints()
        {
            int xOffsetIdx = 0;
            float leftMargin = 200;
            float offset = (Game1.WIDTH - (2 * leftMargin)) / 10;
            // First wave
            for(int i = 0; i < 20; i++) {
                if(i < 10) {
                    firstWaveEndpoints.Add(new Vector2(leftMargin + xOffsetIdx * offset, Game1.HEIGHT / 6));
                    if(i == 9) {
                        xOffsetIdx = -1;
                    }
                }
                else {
                    firstWaveEndpoints.Add(new Vector2(leftMargin + xOffsetIdx * offset, Game1.HEIGHT / 6 + 100));
                }
                xOffsetIdx++;
            }

            xOffsetIdx = 0;
            leftMargin = 100;
            offset = (Game1.WIDTH/2 - (3 * leftMargin)) / 5;

            // Second wave
            for (int i = 0; i < 20; i++) {
                if(i < 10) {
                    if(i < 5) {
                        Vector2 tempPoint = new Vector2(leftMargin + xOffsetIdx * offset, Game1.HEIGHT / 6);
                        secondWaveEndpoints.Add(tempPoint);
                        secondWaveEndpoints.Add(new Vector2(BezierCurve.getReflectedX(tempPoint.X),tempPoint.Y));
                        if (i == 4) {
                            xOffsetIdx = -1;
                        }
                    } else {
                        Vector2 tempPoint = new Vector2(leftMargin + xOffsetIdx * offset, Game1.HEIGHT / 6 + 75);
                        secondWaveEndpoints.Add(tempPoint);
                        secondWaveEndpoints.Add(new Vector2(BezierCurve.getReflectedX(tempPoint.X), tempPoint.Y));
                    }
                }
                xOffsetIdx++;
            }

            xOffsetIdx = 0;
            leftMargin = 100;
            offset = (Game1.WIDTH / 2 - (3 * leftMargin)) / 5;

            // Third wave
            for (int i = 0; i < 20; i++) {
                if (i < 10) {
                    if (i < 5) {
                        Vector2 tempPoint = new Vector2(leftMargin + xOffsetIdx * offset, Game1.HEIGHT - Game1.HEIGHT / 2);
                        thirdWaveEndpoints.Add(tempPoint);
                        thirdWaveEndpoints.Add(new Vector2(BezierCurve.getReflectedX(tempPoint.X), tempPoint.Y));
                        if (i == 4) {
                            xOffsetIdx = -1;
                        }
                    } else {
                        Vector2 tempPoint = new Vector2(leftMargin + xOffsetIdx * offset, Game1.HEIGHT - Game1.HEIGHT / 2 + 75);
                        thirdWaveEndpoints.Add(tempPoint);
                        thirdWaveEndpoints.Add(new Vector2(BezierCurve.getReflectedX(tempPoint.X), tempPoint.Y));
                    }
                }
                xOffsetIdx++;
            }

            // Fourth wave
            fourthWaveEndpoints.Add(new Vector2(Game1.WIDTH/4,100));
            fourthWaveEndpoints.Add(new Vector2(BezierCurve.getReflectedX(Game1.WIDTH / 4), 100));

            fourthWaveEndpoints.Add(new Vector2(Game1.WIDTH / 4 - 75, 175));
            fourthWaveEndpoints.Add(new Vector2(BezierCurve.getReflectedX(Game1.WIDTH / 4 - 75), 175));

            fourthWaveEndpoints.Add(new Vector2(Game1.WIDTH / 4 + 75, 175));
            fourthWaveEndpoints.Add(new Vector2(BezierCurve.getReflectedX(Game1.WIDTH / 4 + 75), 175));

            fourthWaveEndpoints.Add(new Vector2(Game1.WIDTH / 4, 250));
            fourthWaveEndpoints.Add(new Vector2(BezierCurve.getReflectedX(Game1.WIDTH / 4), 250));

            fourthWaveEndpoints.Add(new Vector2(Game1.WIDTH / 4 - 150, 100));
            fourthWaveEndpoints.Add(new Vector2(BezierCurve.getReflectedX(Game1.WIDTH / 4 - 150), 100));

            fourthWaveEndpoints.Add(new Vector2(Game1.WIDTH / 4 + 150, 100));
            fourthWaveEndpoints.Add(new Vector2(BezierCurve.getReflectedX(Game1.WIDTH / 4 + 150), 100));

            fourthWaveEndpoints.Add(new Vector2(Game1.WIDTH / 4 - 150, 250));
            fourthWaveEndpoints.Add(new Vector2(BezierCurve.getReflectedX(Game1.WIDTH / 4 - 150), 250));

            fourthWaveEndpoints.Add(new Vector2(Game1.WIDTH / 4 + 150, 250));
            fourthWaveEndpoints.Add(new Vector2(BezierCurve.getReflectedX(Game1.WIDTH / 4 + 150), 250));

            fourthWaveEndpoints.Add(new Vector2(Game1.WIDTH / 4 - 225, 175));
            fourthWaveEndpoints.Add(new Vector2(BezierCurve.getReflectedX(Game1.WIDTH / 4 - 225), 175));

            fourthWaveEndpoints.Add(new Vector2(Game1.WIDTH / 4 + 225, 175));
            fourthWaveEndpoints.Add(new Vector2(BezierCurve.getReflectedX(Game1.WIDTH / 4 + 225), 175));
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

        public Vector2 getEndpoint()
        {
            Vector2 endpoint;
            switch (wave) {
                case 1:
                    endpoint = firstWaveEndpoints.First();
                    firstWaveEndpoints.Remove(endpoint);
                    return endpoint;
                case 2:
                    endpoint = secondWaveEndpoints.First();
                    secondWaveEndpoints.Remove(endpoint);
                    return endpoint;
                case 3:
                    endpoint = thirdWaveEndpoints.First();
                    thirdWaveEndpoints.Remove(endpoint);
                    return endpoint;
                case 4:
                    endpoint = fourthWaveEndpoints.First();
                    fourthWaveEndpoints.Remove(endpoint);
                    return endpoint;
                default:
                    return new Vector2();
            }
        }

        private void spawnEnemies() {
            if (spawnCounter <= 0f && Enemies.Count() <= MAX_ENEMIES*2) {
                Enemies.Add(new Enemy(this, true));
                Enemies.Add(new Enemy(this, false));
                spawnCounter = SPAWN_RATE;
            }
        }
    }
}
