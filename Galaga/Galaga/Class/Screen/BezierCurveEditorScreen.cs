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
        int pointIdx = -1;
        
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
            }else if(lastMouseState.RightButton == ButtonState.Released && mstate.RightButton == ButtonState.Pressed) {
                saveToFile("D:/bezier.txt");
            }
            

            if (GamePad.GetState(PlayerOne).Buttons.B == ButtonState.Pressed || kstate.IsKeyDown(Keys.B) == true) {
                ScreenEvent.Invoke(this, new EventArgs());
            }

            lastMouseState = mstate;

            base.Update(theTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {

            spriteBatch.DrawString(Game1.textureManager.bezierCurveFont, "Point idx: " + pointIdx, new Vector2(50, 50), Color.White);

            spriteBatch.Draw(Game1.textureManager.point, new Vector2(Mouse.GetState().Position.X, Mouse.GetState().Position.Y), Color.White);

            bezierCurve.ForEach((point) => {
                String tempString = "X: " + point.X + ", Y: " + point.Y;
                spriteBatch.Draw(Game1.textureManager.point, point, Color.White);
                spriteBatch.DrawString(Game1.textureManager.bezierCurveFont, tempString, new Vector2(point.X, point.Y - 30),Color.White);
                });

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

        private void saveToFile(String filePath) {
            System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true);

            file.WriteLine("----- Curve - " + DateTime.Now.ToString("h:mm:ss tt") + " -----");
            for (int i = 0; i < bezierCurve.Count(); i++) {
                if(i == 0) {
                    file.WriteLine("Start point - X:" + bezierCurve.ElementAt(i).X + "," + bezierCurve.ElementAt(i).Y +" :Y");
                }else if(i == 1 || i == 2) {
                    file.WriteLine("Mid point - X:" + bezierCurve.ElementAt(i).X + "," + bezierCurve.ElementAt(i).Y + " :Y");
                } else {
                    file.WriteLine("End point - X:" + bezierCurve.ElementAt(i).X + "," + bezierCurve.ElementAt(i).Y + " :Y");
                }
            }
            file.WriteLine("----- Curve - " + DateTime.Now.ToString("h:mm:ss tt") + " -----");
            file.WriteLine("     ***** CODE *****     ");
            file.WriteLine(".setupCurve(0,new Vector2(" + bezierCurve.ElementAt(0).X + "," + bezierCurve.ElementAt(0).Y + " ), new Vector2(" + bezierCurve.ElementAt(1).X + "," + bezierCurve.ElementAt(1).Y + "), new Vector2(" + bezierCurve.ElementAt(2).X + "," + bezierCurve.ElementAt(2).Y +  "), new Vector2(" + bezierCurve.ElementAt(3).X + "," + bezierCurve.ElementAt(3).Y +  "));");
            file.WriteLine("     ***** CODE *****    ");
            file.Close();
        }
    }
}
