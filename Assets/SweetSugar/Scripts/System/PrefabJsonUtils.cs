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

namespace SweetSugar.Scripts.System
{
    public static class PrefabJsonUtils
    {
#if UNITY_EDITOR
        public static string GetFullPath(GameObject targetPrefab)
        {
            string prefabAssetPathOfNearestInstanceRoot = UnityEditor.PrefabUtility.GetPrefabAssetPathOfNearestInstanceRoot(targetPrefab);
            string prefabStructure = targetPrefab.transform.parent != null ? "@" + targetPrefab.name : "";
            var prefabPath = prefabAssetPathOfNearestInstanceRoot.Replace("/Resources/", "").Replace(".prefab", "").Substring(prefabAssetPathOfNearestInstanceRoot.IndexOf("/Resources/"));
            return prefabPath + prefabStructure;
        }
#endif
    
        public static GameObject LoadPrefab(string prefabPath)
        {
            var indexOf = prefabPath.IndexOf("@");
            string subPrefab = "";
            if (indexOf > 0)
            {
                subPrefab = prefabPath.Substring(indexOf + 1);
                prefabPath = prefabPath.Substring(0, indexOf);
            }

            var gameObject = Resources.Load<GameObject>(prefabPath);
            if (subPrefab != "") gameObject = gameObject.transform.Find(subPrefab).gameObject;
            var targetPrefab = gameObject;
            return targetPrefab;
        }
    }
}