using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaga.Class.Utils {
    public class TextureManager {

        //Background
        public Texture2D splashScreenBackground;
        
        //Object
        public Texture2D player;
        public Texture2D bullet;

        // Enemies
        public List<Texture2D> enemy1 = new List<Texture2D>();
        public List<Texture2D> enemy2 = new List<Texture2D>();

        // Debug
        public Texture2D centerLine;
        public Texture2D point;
        public Texture2D curvePoint;

        public TextureManager(ContentManager theContent) {
            loadTextures(theContent);
        }

        private void loadTextures(ContentManager theContent) {
            // Background
            splashScreenBackground = theContent.Load<Texture2D>("Textures/Background/splashScreenBackground");

            //Object 
            player = theContent.Load<Texture2D>("Textures/Object/player");
            bullet = theContent.Load<Texture2D>("Textures/Object/bullet");

            // Enemies
            enemy1.Add(theContent.Load<Texture2D>("Textures/Enemies/Enemy1/enemy1_1"));
            enemy1.Add(theContent.Load<Texture2D>("Textures/Enemies/Enemy1/enemy1_2"));

            enemy2.Add(theContent.Load<Texture2D>("Textures/Enemies/Enemy2/enemy2_1"));
            enemy2.Add(theContent.Load<Texture2D>("Textures/Enemies/Enemy2/enemy2_2"));
            
            // Debug
            centerLine = theContent.Load<Texture2D>("Textures/DebugTextures/centerLine");
            point = theContent.Load<Texture2D>("Textures/DebugTextures/Point");
            curvePoint = theContent.Load<Texture2D>("Textures/DebugTextures/curvePoint");

        }
    }
}
