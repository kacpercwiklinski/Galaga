using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Galaga.Class.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;



namespace Galaga.Class.LevelScripts
{
    public class Explosion
    {
        public Texture2D texture;
        public Vector2 position;
        public Vector2 texturePos;
        public float timer;
        public float interval;

        public bool isVisible;

        float counter = 0f;

        public Explosion(Vector2 pos) {
            texture = Game1.textureManager.explosion.First();
            Game1.audioManager.boom.Play(0.1f, -1.0f, 0.0f);
            position = pos;
            isVisible = true;
        }

        public void Update(GameTime gameTime)
        {
            texturePos = new Vector2(position.X, position.Y);

            Animator.animate(gameTime, ref texture, Game1.textureManager.explosion, 0.08f, ref counter,true);
            counter += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (texture.Equals(Game1.textureManager.explosion.Last())) {
                isVisible = false;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible){
                spriteBatch.Draw(texture, new Vector2(this.position.X - this.texture.Width/2,this.position.Y- this.texture.Height/2), Color.White);
            }
        }

    }
}
