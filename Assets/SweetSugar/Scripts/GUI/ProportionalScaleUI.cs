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

using System.Linq;
using SweetSugar.Scripts.System;
using UnityEngine;
using UnityEngine.UI;

namespace SweetSugar.Scripts.GUI
{
    /// <summary>
    /// Proportional scale of icon
    /// </summary>
    [ExecuteInEditMode]
    public class ProportionalScaleUI : MonoBehaviour
    {
        float side = 200;
        public GridLayoutGroup rect;

        // Use this for initialization
        void OnEnable()
        {
            rect = GetComponent<GridLayoutGroup>();
        }

        // Update is called once per frame
        private void Update()
        {
            var count = transform.GetChildren().Where(i => i.gameObject.activeSelf).Count();
            if (count == 4) side = 150;
            else if (count > 4) side = 130;
            else if (count == 3) side = 150;
            else if (count < 3) side = 280f / count;

            rect.cellSize = Vector2.one * side;
        }
    }
}
