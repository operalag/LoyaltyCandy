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

using SweetSugar.Scripts.System;
using SweetSugar.Scripts.TargetScripts.TargetSystem;
using UnityEditor;

namespace SweetSugar.Scripts.TargetScripts.TargetEditor.Editor
{
    public static class TargetEditorUtils
    {
        private static TargetEditorScriptable target;

        public static TargetEditorScriptable TargetEditorScriptable
        {
            get
            {
                if (target == null)
                {
                    target = AssetDatabase.LoadAssetAtPath<TargetEditorScriptable>("Assets/SweetSugar/Resources/Levels/TargetEditorScriptable.asset");
                }

                return target;
            }
        }

        public static TargetContainer GetTargetContainer(SerializedProperty property)
        {
            var propertyParent = PropertyUtils.GetParent(property) as TargetObject;
            return TargetEditorScriptable.GetTargetbyName(propertyParent.targetType.GetTarget().name);
        }
    }
}