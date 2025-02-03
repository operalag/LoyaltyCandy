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
using UnityEngine.UI;

namespace SweetSugar.Scripts.System.Orientation
{
    /// <summary>
    /// Canvas scaler depending from orientation
    /// </summary>
    public class CanvasActivator : OrientationActivator
    {
        public override void OnOrientationChanged(ScreenOrientation orientation)
        {
            if (orientation == ScreenOrientation.Portrait)
                GetComponent<CanvasScaler>().matchWidthOrHeight = 1;
            else if (orientation == ScreenOrientation.LandscapeLeft)
                GetComponent<CanvasScaler>().matchWidthOrHeight = 0;

        }
    }
}