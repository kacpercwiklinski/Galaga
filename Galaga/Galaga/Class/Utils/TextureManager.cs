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

        public TextureManager(ContentManager theContent) {
            loadTextures(theContent);
        }

        private void loadTextures(ContentManager theContent) {
            // Background
            splashScreenBackground = theContent.Load<Texture2D>("Textures/Background/splashScreenBackground");

        }
    }
}
