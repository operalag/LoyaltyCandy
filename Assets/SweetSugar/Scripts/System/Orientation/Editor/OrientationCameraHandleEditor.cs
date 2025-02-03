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

namespace SweetSugar.Scripts.System.Orientation.Editor
{
    [CustomEditor(typeof(OrientationCameraHandle))]

    public class OrientationCameraHandleEditor : UnityEditor.Editor
    {
        OrientationCameraHandle myTarget;

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
//        myTarget = (OrientationCameraHandle)target;
//        var objectsList = myTarget.list;
//        for (int j = 0; j < objectsList.Count; j++)
//        {
//            var orientationObject = objectsList[j];
//            GUILayout.BeginHorizontal();
//            {
//                orientationObject.ratio = EditorGUILayout.Vector2Field("", orientationObject.ratio, GUILayout.Width(150));
//                orientationObject.cameraSize = EditorGUILayout.FloatField(orientationObject.cameraSize, GUILayout.Width(50));
//                orientationObject.cameraPosition = EditorGUILayout.Vector2Field("", orientationObject.cameraPosition, GUILayout.Width(150));
//
//            }
//            GUILayout.EndHorizontal();

//        }
//        if (GUILayout.Button("+"))
//        {
//            objectsList.Add(new OrientationCameraHandle.OrientationRatio());
//        }
//
//        if (GUILayout.Button("-"))
//        {
//            objectsList.Remove(objectsList.LastOrDefault());
//        }
        }

    }
}
