using Galaga.Class.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Galaga.Class.Screen {
    class BezierCurveEditorScreen : Screen {

        List<Vector2> bezierCurve;
        float precision = 0.005f;
        MouseState lastMouseState = Mouse.GetState();
        int pointIdx = 0;
        
        public BezierCurveEditorScreen(ContentManager theContent,EventHandler theScreenEvent) : base(theScreenEvent) {
            bezierCurve = new List<Vector2>();
            bezierCurve.Add(new Vector2(0, 0));
            bezierCurve.Add(new Vector2(0, 0));
            bezierCurve.Add(new Vector2(0, 0));
            bezierCurve.Add(new Vector2(0, 0));
            
        }

        public override void Update(GameTime theTime) {
            var kstate = Keyboard.GetState();
            var mstate = Mouse.GetState();
            
            if (lastMouseState.LeftButton == ButtonState.Released &&  mstate.LeftButton == ButtonState.Pressed) {
                Debug.WriteLine("Kliknieto... idx: " + pointIdx);
                pointIdx = pointIdx < 3 ? pointIdx + 1 : 0;
                bezierCurve.RemoveAt(pointIdx);
                bezierCurve.Insert(pointIdx, new Vector2(mstate.Position.X, mstate.Position.Y));
            }
            

            if (GamePad.GetState(PlayerOne).Buttons.B == ButtonState.Pressed || kstate.IsKeyDown(Keys.B) == true) {
                ScreenEvent.Invoke(this, new EventArgs());
            }

            lastMouseState = mstate;

            base.Update(theTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {

            spriteBatch.Draw(Game1.textureManager.point, new Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y), Color.White);

            bezierCurve.ForEach((point) => spriteBatch.Draw(Game1.textureManager.point, point, Color.White));

            drawBezierCurve(spriteBatch);

            base.Draw(spriteBatch);
        }

        private void drawBezierCurve(SpriteBatch spriteBatch) {
            List<Vector2> points = new List<Vector2>();
            float temp = 0;
            float n_points = 1 / precision;
            
            for(int i = 0; i < n_points; i++) {
                points.Add(BezierCurve.GetPoint(temp, bezierCurve.ElementAt(0), bezierCurve.ElementAt(1), bezierCurve.ElementAt(2), bezierCurve.ElementAt(3)));
                temp += precision;
            }

            points.ForEach((point) => {
                spriteBatch.Draw(Game1.textureManager.curvePoint, point, Color.White);
            });
        }
    }
}
