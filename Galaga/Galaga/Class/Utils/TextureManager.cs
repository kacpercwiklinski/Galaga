﻿using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaga.Class.Utils {
    public class TextureManager {

        // Fonts
        public SpriteFont bezierCurveFont;
        public SpriteFont stageFont;

        //Background
        public Texture2D splashScreenBackground;
        public Texture2D gameOverScreenBackground;
        public Texture2D mainMenuScreenBackground;
        public Texture2D background;
        
        //Object
        public Texture2D player;
        public Texture2D bullet;
        public Texture2D enemyBullet;

        // Enemies
        public List<Texture2D> enemy1 = new List<Texture2D>();
        public List<Texture2D> enemy2 = new List<Texture2D>();
        public List<Texture2D> enemy3 = new List<Texture2D>();

        // Debug
        public Texture2D centerLine;
        public Texture2D point;
        public Texture2D curvePoint;

        //Explosion
        public List<Texture2D> explosion = new List<Texture2D>();
        public List<Texture2D> playerExplosion = new List<Texture2D>();
        
        public TextureManager(ContentManager theContent) {
            loadTextures(theContent);
        }

        private void loadTextures(ContentManager theContent) {

            // Explosion
            explosion.Add(theContent.Load<Texture2D>("Textures/Explosion/explosion_1"));
            explosion.Add(theContent.Load<Texture2D>("Textures/Explosion/explosion_2"));
            explosion.Add(theContent.Load<Texture2D>("Textures/Explosion/explosion_3"));
            explosion.Add(theContent.Load<Texture2D>("Textures/Explosion/explosion_4"));
            explosion.Add(theContent.Load<Texture2D>("Textures/Explosion/explosion_5"));

            playerExplosion.Add(theContent.Load<Texture2D>("Textures/Explosion/player_explosion_1"));
            playerExplosion.Add(theContent.Load<Texture2D>("Textures/Explosion/player_explosion_2"));
            playerExplosion.Add(theContent.Load<Texture2D>("Textures/Explosion/player_explosion_3"));
            playerExplosion.Add(theContent.Load<Texture2D>("Textures/Explosion/player_explosion_4"));

            // Fonts 
            bezierCurveFont = theContent.Load<SpriteFont>("Font/bezierCurveFont");
            stageFont = theContent.Load<SpriteFont>("Font/stageFont");

            // Background
            splashScreenBackground = theContent.Load<Texture2D>("Textures/Background/splashScreenBackground");
            background = theContent.Load<Texture2D>("Textures/Background/backgroundWithStars");
            gameOverScreenBackground = theContent.Load<Texture2D>("Textures/Background/gameOverScreenBackground");
            mainMenuScreenBackground = theContent.Load<Texture2D>("Textures/Background/mainMenuBackround");

            //Object 
            player = theContent.Load<Texture2D>("Textures/Object/player");
            bullet = theContent.Load<Texture2D>("Textures/Object/bullet");
            enemyBullet = theContent.Load<Texture2D>("Textures/Object/enemy_bullet");

            // Enemies
            enemy1.Add(theContent.Load<Texture2D>("Textures/Enemies/Enemy1/enemy1_1"));
            enemy1.Add(theContent.Load<Texture2D>("Textures/Enemies/Enemy1/enemy1_2"));

            enemy2.Add(theContent.Load<Texture2D>("Textures/Enemies/Enemy2/enemy2_1"));
            enemy2.Add(theContent.Load<Texture2D>("Textures/Enemies/Enemy2/enemy2_2"));

            enemy3.Add(theContent.Load<Texture2D>("Textures/Enemies/Enemy3/enemy3_1"));
            enemy3.Add(theContent.Load<Texture2D>("Textures/Enemies/Enemy3/enemy3_2"));

            // Debug
            centerLine = theContent.Load<Texture2D>("Textures/DebugTextures/centerLine");
            point = theContent.Load<Texture2D>("Textures/DebugTextures/Point");
            curvePoint = theContent.Load<Texture2D>("Textures/DebugTextures/curvePoint");

        }
    }
}
