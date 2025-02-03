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

using System;
using System.Collections.Generic;
using SweetSugar.Scripts.Core;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SweetSugar.Scripts.System.Orientation
{
    /// <summary>
    /// Activates object from the array depending from orientation
    /// </summary>
    [ExecuteInEditMode]
    public class OrientationActivator : MonoBehaviour
    {

        public List<Object> horrizontalObjects;
        public List<Object> horrizontalObjectsHD;
        public List<Object> verticalObjects;
        private RectTransform[] currentPanels;
        public static GameObject ActiveOrientationCanvas;
        public RectTransform[] GetCurrentPanels()
        {
            return currentPanels;
        }

        void OnEnable()
        {
            OnOrientationChanged(OrientationListener.previousOrientation);
            OrientationListener.OnOrientationChanged += OnOrientationChanged;
        }

        void OnDisable()
        {
            OrientationListener.OnOrientationChanged -= OnOrientationChanged;
        }
        public virtual void OnOrientationChanged(ScreenOrientation orientation)
        {
            if (orientation == ScreenOrientation.Portrait)
            {
                var aspect = Screen.height / (float)Screen.width;
                aspect = (float)Math.Round(aspect, 2);

                SetActiveList(horrizontalObjects, false);
                SetActiveList(verticalObjects, true);
                SetActiveList(horrizontalObjectsHD, false);

            }

            else if (orientation == ScreenOrientation.LandscapeLeft)
            {
                var aspect = Screen.width / (float)Screen.height;
                aspect = (float)Math.Round(aspect, 2);
                if (aspect >= 1.6f)
                {
                    SetActiveList(horrizontalObjects, false);
                    SetActiveList(horrizontalObjectsHD, true);
                }
                if (aspect < 1.6f)
                {
                    SetActiveList(horrizontalObjectsHD, false);
                    SetActiveList(horrizontalObjects, true);
                }
                SetActiveList(verticalObjects, false);
            }
        }

        private void SetActiveList(List<Object> list, bool activate)
        {
            foreach (var item in list)
            {
                if (item.GetType() == typeof(GameObject))
                {
                    var gameObj = (GameObject)item;
                    gameObj.SetActive(activate);
                    if (activate)
                    {
                        OrientationPanels orientationPanels = gameObj.GetComponent<OrientationPanels>();
                        currentPanels = orientationPanels?.panels;
                        if (orientationPanels)
                            LevelManager.THIS.movesTransform = orientationPanels.movesTransform;
                    }
                }
                else
                {
                    var gameObj = (MonoBehaviour)item;
                    gameObj.enabled = activate;
                }

                if (activate) ActiveOrientationCanvas = (GameObject)item;
            }
        }
    }
}
