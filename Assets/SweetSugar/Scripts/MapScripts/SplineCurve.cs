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

using UnityEngine;

namespace SweetSugar.Scripts.MapScripts
{
    public class SplineCurve
    {
        private readonly Vector2[] _points;

        public SplineCurve()
        {
            _points = new Vector2[4];
        }

        public void ApplyPoints(Vector2 p1, Vector2 p2, Vector2 p3, Vector2 p4)
        {
            _points[0] = p1;
            _points[1] = p2;
            _points[2] = p3;
            _points[3] = p4;
        }

        public Vector2 GetPoint(float t)
        {
            return GetPoint(_points[0], _points[1], _points[2], _points[3], t);
        }

        public static Vector2 GetPoint(Vector2 a, Vector2 b, Vector2 c, Vector2 d, float t)
        {
            //t==0, ret b
            //t==1, ret c
            return .5f * (
                       (-a + 3f * b - 3f * c + d) * (t * t * t)
                       + (2f * a - 5f * b + 4f * c - d) * (t * t)
                       + (-a + c) * t
                       + 2f * b
                   );
        }
    }
}
