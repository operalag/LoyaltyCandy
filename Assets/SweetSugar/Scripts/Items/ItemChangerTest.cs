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

using SweetSugar.Scripts.Core;
using SweetSugar.Scripts.System;
using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR
#endif

namespace SweetSugar.Scripts.Items
{
    /// <summary>
    /// Debug item menu by right mouse button. Works only in Unity editor
    /// </summary>
    public class ItemChangerTest : MonoBehaviour
    {
        private Item item;
        public void ShowMenuItems(Item _item)
        {
            item = _item;
        }

#if UNITY_EDITOR
        private void OnGUI()
        {
            if (item != null)
            {
                if (GUILayout.Button("Select item"))
                {
                    Selection.objects = new Object[] { item.gameObject };
                }       
//            if (GUILayout.Button("Show in console"))
//            {
//                Debug.Log("\nCPAPI:{\"cmd\":\"Search\" \"text\":\"" + item.instanceID + "\"}");
//            }
                if (GUILayout.Button("Select square"))
                {
                    Selection.objects = new Object[] { item.square.gameObject };
                }
                foreach (var itemType in EnumUtil.GetValues<ItemsTypes>())
                {
                    if (GUILayout.Button(itemType.ToString()))
                    {
                        item.SetType(itemType, null);
                        item = null;
                        // item.debugType = itemType;
                    }
                }
                if (GUILayout.Button("Destroy"))
                {
                    item.DestroyItem(true);
                    LevelManager.THIS.FindMatches();
                    item = null;
                }
            }
        }
#endif
    }
}