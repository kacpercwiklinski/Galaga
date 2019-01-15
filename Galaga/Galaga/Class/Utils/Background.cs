using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;



namespace Galaga.Class.Utils
{
    public class Background
    {
        public Texture2D texture;
        public Vector2 bgPos1, bgPos2;
        public int speed;

        public Background()
        {
            texture = Game1.textureManager.background;
            bgPos1 = new Vector2(0, 0);
            bgPos2 = new Vector2(0, -720);
            speed = 5;
        }

       

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, bgPos1, Color.White);
            spriteBatch.Draw(texture, bgPos2, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            bgPos1.Y = bgPos1.Y + speed;
            bgPos2.Y = bgPos2.Y + speed;

            //scrolowanie mapy
            if (bgPos1.Y >= 720)
            {
                bgPos1.Y = 0;
                bgPos2.Y = -720;
            }
        }
    }
}
