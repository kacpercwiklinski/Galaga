﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaga.Class.Screen {
    class Screen {
        protected static PlayerIndex PlayerOne;
        protected EventHandler ScreenEvent;

        public Screen(EventHandler theScreenEvent) {
            ScreenEvent = theScreenEvent;
        }

        public virtual void Update(GameTime gameTime) {

        }

        public virtual void Draw(SpriteBatch spriteBatch) {

        }
    }
}
