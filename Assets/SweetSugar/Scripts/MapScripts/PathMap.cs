// // ©2015 - 2023 Candy Smith
// // All rights reserved
// // Redistribution of this software is strictly not allowed.
// // Copy of this software can be obtained from unity asset store only.
// // THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// // IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// // FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT. IN NO EVENT SHALL THE
// // AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// // LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// // OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// // THE SOFTWARE.

using System.Collections.Generic;
using UnityEngine;

namespace SweetSugar.Scripts.MapScripts
{
    public class PathMap : MonoBehaviour
    {
        //    [HideInInspector]
        public List<Transform> Waypoints = new List<Transform>();

        [HideInInspector]
        public bool IsCurved;

        [HideInInspector]
        public Color GizmosColor = Color.white;

        [HideInInspector]
        public float GizmosRadius = 10.0f;

        public void OnDrawGizmos()
        {
            Gizmos.color = GizmosColor;
            for (var i = 0; i < Waypoints.Count; i++)
            {
                Gizmos.DrawSphere(Waypoints[i].transform.position, GizmosRadius);
                if (i < Waypoints.Count - 1)
                    DrawPart(i);
            }
        }

        private void DrawPart(int ind)
        {
            if (IsCurved)
            {
                var devidedPoints = GetDivededPoints(ind);
                for (var i = 0; i < devidedPoints.Length - 1; i++)
                    Gizmos.DrawLine(devidedPoints[i], devidedPoints[i + 1]);
            }
            else
            {
                Gizmos.DrawLine(Waypoints[ind].position, Waypoints[(ind + 1) % Waypoints.Count].position);
            }
        }

        private Vector2[] GetDivededPoints(int ind)
        {
            var points = new Vector2[11];
            var pointInd = 0;
            var indexes = GetSplinePointIndexes(ind, true);
            Vector2 a = Waypoints[indexes[0]].transform.position;
            Vector2 b = Waypoints[indexes[1]].transform.position;
            Vector2 c = Waypoints[indexes[2]].transform.position;
            Vector2 d = Waypoints[indexes[3]].transform.position;
            for (float t = 0; t <= 1.001f; t += 0.1f)
                points[pointInd++] = SplineCurve.GetPoint(a, b, c, d, t);
            return points;
        }

        public int[] GetSplinePointIndexes(int baseInd, bool isForwardDirection)
        {
            var dInd = isForwardDirection ? 1 : -1;
            return new[]
            {
                Mathf.Clamp(baseInd - dInd, 0, Waypoints.Count - 1),
                baseInd,
                Mathf.Clamp(baseInd + dInd, 0, Waypoints.Count - 1),
                Mathf.Clamp(baseInd + 2*dInd, 0, Waypoints.Count - 1)
            };
        }

        public float GetLength()
        {
            float length = 0;
            for (var i = 0; i < Waypoints.Count; i++)
            {
                Vector2 p1 = Waypoints[i].transform.position;
                Vector2 p2 = Waypoints[(i + 1) % Waypoints.Count].transform.position;
                length += Vector2.Distance(p1, p2);
            }
            return length;
        }

        public float GetLength(int startInd)
        {
            return Vector2.Distance(
                Waypoints[startInd].transform.position,
                Waypoints[(startInd + 1) % Waypoints.Count].transform.position);
        }

    }
}
