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

using SweetSugar.Scripts.Items;
using UnityEditor;
using UnityEngine;

namespace SweetSugar.Scripts.Editor
{
    [CustomEditor(typeof(ItemDebugInspector))]
    public class ItemDebugInspectorEditor : UnityEditor.Editor
    {
        private string log;
        private string logDesrt;

        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Print falling log"))
            {
                DebugLogKeeper.GetLog(((ItemDebugInspector)target).GetComponent<Item>().instanceID.ToString(), DebugLogKeeper.LogType.Falling);
            }
            if (GUILayout.Button("Print destroying log"))
            {
                DebugLogKeeper.GetLog(((ItemDebugInspector)target).GetComponent<Item>().instanceID.ToString(), DebugLogKeeper.LogType.Destroying);
            }
            if (GUILayout.Button("Print bonus log"))
            {
                DebugLogKeeper.GetLog(((ItemDebugInspector)target).GetComponent<Item>().instanceID.ToString(), DebugLogKeeper.LogType.BonusAppearance);
            }
            base.OnInspectorGUI();

        }

    }
}