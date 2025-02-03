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

using UnityEditor;
using UnityEngine;

namespace SweetSugar.Scripts.System.Orientation.Editor
{
    [CustomEditor(typeof(OrientationHandle))]
    public class OrientationHandleEditor : UnityEditor.Editor
    {
        OrientationHandle myTarget;
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            myTarget = (OrientationHandle)target;
            var objectsList = myTarget.list;
            for (int j = 0; j < objectsList.Count; j++)
            {
                var orientationObject = objectsList[j];
                for (int k = 0; k < orientationObject.obj.Length; k++)
                    orientationObject.obj[k] = (GameObject)EditorGUILayout.ObjectField(orientationObject.obj[k], typeof(GameObject), true);
                for (int i = 0; i < orientationObject.list.Count; i++)
                {
                    var list = orientationObject.list;
                    var objectPosition = list[i];
                    objectPosition.orientation = (ScreenOrientation)EditorGUILayout.EnumPopup(objectPosition.orientation);
                    list[i].rectTransform = EditorGUILayout.RectField(list[i].rectTransform);
                    if (GUILayout.Button("Get transform"))
                    {
                        objectPosition.rectTransform = orientationObject.obj[0].GetComponent<RectTransform>().rect;
                        objectPosition.rectTransform.x = orientationObject.obj[0].GetComponent<RectTransform>().anchoredPosition.x;
                        objectPosition.rectTransform.y = orientationObject.obj[0].GetComponent<RectTransform>().anchoredPosition.y;

                    }
                }
                GUILayout.Space(30);
            }

        }
    }
}