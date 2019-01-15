using Galaga.Class.Utils;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaga.Class.LevelScripts {
    public class Path {
        public Vector2 startingPoint;
        public Vector2 lastPoint;
        public List<Vector2> points;
        float tOffset = 0.1f;
        List<Vector2> firstCurve;
        List<Vector2> secondCurve;
        List<Vector2> thirdCurve;
        public Vector2 currentPoint;

        public Path() {
            points = new List<Vector2>();
            firstCurve = new List<Vector2>();
            secondCurve = new List<Vector2>();
            thirdCurve = new List<Vector2>();
        }

        public void setupCurve(int curveId, Vector2 start, Vector2 controlPoint1, Vector2 controlPoint2, Vector2 end) {
            switch (curveId) {
                case 0:
                    startingPoint = start;
                    firstCurve.Add(start);
                    firstCurve.Add(controlPoint1);
                    firstCurve.Add(controlPoint2);
                    firstCurve.Add(end);
                    break;
                case 1:
                    secondCurve.Add(start);
                    secondCurve.Add(controlPoint1);
                    secondCurve.Add(controlPoint2);
                    secondCurve.Add(end);
                    break;
                case 2:
                    thirdCurve.Add(start);
                    thirdCurve.Add(controlPoint1);
                    thirdCurve.Add(controlPoint2);
                    thirdCurve.Add(end);
                    lastPoint = end;
                    break;
                default:
                    return;
            }
        }

        public void setupPointsList() {
            float tempT = 0f;
            for(int i = 0; i < (int) 3 / tOffset; i++) {
                points.Add(getPoint(tempT));
                tempT += tOffset;
            }
            points.Add(lastPoint);
        }

        public Vector2 getPoint(float t) {
            Vector2 point = new Vector2();
            if(t >= 0 && t <= 1) {
                point = BezierCurve.GetPoint(t, firstCurve.ElementAt(0), firstCurve.ElementAt(1), firstCurve.ElementAt(2), firstCurve.ElementAt(3));
            }else if(t > 1 &&  t <=  2) {
                float tempT = map(t, 1, 2, 0, 1);
                point = BezierCurve.GetPoint(tempT, secondCurve.ElementAt(0), secondCurve.ElementAt(1), secondCurve.ElementAt(2), secondCurve.ElementAt(3));
            } else if(t > 2 && t <= 3) {
                float tempT = map(t, 2, 3, 0, 1);
                point = BezierCurve.GetPoint(tempT, thirdCurve.ElementAt(0), thirdCurve.ElementAt(1), thirdCurve.ElementAt(2), thirdCurve.ElementAt(3));
            }
            return point;
        }

        public Vector2 getNextFollowedPoint(int pointIdx)
        {
            if (pointIdx > points.Count() - 1) return points.Last();
            return points.ElementAt(pointIdx);
        }

        private float map(float n, float start1, float stop1, float start2, float stop2) {
            return ((n - start1) / (stop1 - start1)) * (stop2 - start2) + start2;
        }
    }

    public static class Paths {
        public static Path path1 = new Path();
        public static Path path2 = new Path();
        public static Path path3 = new Path();
        public static Path path4 = new Path();
    }
}
