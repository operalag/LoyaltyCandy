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
using UnityEngine.UI;

namespace SweetSugar.Scripts.ImageCreator.Editor
{
    [InitializeOnLoad]
    public class ImageCreator : UnityEditor.Editor
    {
        static ImageCreator()
        {
            EditorApplication.hierarchyChanged += OnChanged;
        }

        private static void OnChanged()
        {
            var obj = Selection.activeGameObject;
            if (obj == null || obj.transform.parent == null) return;
            if ((obj.transform.parent.GetComponent<CanvasRenderer>() != null || obj.transform.parent.GetComponent<Canvas>() != null || obj.transform.parent.GetComponent<RectTransform>() != null) && obj.GetComponent<SpriteRenderer>() != null)
            {
                var rectTransform = obj.AddComponent<RectTransform>();
                rectTransform.anchoredPosition3D = Vector3.zero;
                rectTransform.localScale = Vector3.one;
                var spr = obj.GetComponent<SpriteRenderer>().sprite;
                var img = obj.AddComponent<Image>();
                img.sprite = spr;
                img.SetNativeSize();
                DestroyImmediate(obj.GetComponent<SpriteRenderer>());
            }
        }
    }
}