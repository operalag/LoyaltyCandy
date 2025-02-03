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

using SweetSugar.Scripts.Items._Interfaces;
using UnityEditor;
using UnityEngine;

namespace SweetSugar.Scripts.Level.ItemsPerLevel.Editor
{
    public class ItemsPerLevelEditor : EditorWindow
    {
        private static GameObject prefab;
        private static int numLevel;
        private static ParticleSystem ps;

        // Add menu item named "My Window" to the Window menu
        public static void ShowWindow(GameObject itemPrefab, int level)
        {
            ps = Resources.Load<ParticleSystem>("Prefabs/Particles/FireworkSplash");
            ItemsPerLevelEditor window = (ItemsPerLevelEditor) EditorWindow.GetWindow(typeof(ItemsPerLevelEditor), true, itemPrefab.name + " editor");

            prefab = Resources.Load<GameObject>("Items/" + itemPrefab.name);
            numLevel = level;
            //Show existing window instance. If one doesn't exist, make one.
            GetWindow(typeof(ItemsPerLevelEditor));
        }

        void OnGUI()
        {
            if (prefab)
            {
                GUILayout.BeginVertical();
                {
                    var sprs = prefab.GetComponent<IColorableComponent>().GetSpritesOrAdd(numLevel);
                    for (var index = 0; index < sprs.Length; index++)
                    {
                        var spr = sprs[index];
                        sprs[index] = (Sprite) EditorGUILayout.ObjectField(spr, typeof(Sprite),true, GUILayout.Width(50), GUILayout.Height(50));
                        if (sprs[index] != spr)
                        {
                            PrefabUtility.SavePrefabAsset(prefab);
                            ps.textureSheetAnimation.SetSprite(index, sprs[index]);
                        }
                    }
                }
                GUILayout.EndVertical();
            }
            else Close();
        }
    }
}