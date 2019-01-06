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

        // Debug
        public Texture2D centerLine;

        public TextureManager(ContentManager theContent) {
            loadTextures(theContent);
        }

        private void loadTextures(ContentManager theContent) {
            // Background
            splashScreenBackground = theContent.Load<Texture2D>("Textures/Background/splashScreenBackground");

            //Object 
            player = theContent.Load<Texture2D>("Textures/Object/player");
            bullet = theContent.Load<Texture2D>("Textures/Object/bullet");

            // Debug
            centerLine = theContent.Load<Texture2D>("Textures/DebugTextures/centerLine");

        }
    }
}
