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

using System.Linq;
using SweetSugar.Scripts.System;
using SweetSugar.Scripts.TargetScripts.TargetEditor;
using SweetSugar.Scripts.TargetScripts.TargetEditor.Editor;
using UnityEditor;
using UnityEngine;

namespace Sweet_sugar.Assets.SweetSugar.Scripts.TargetScripts.TargetEditor
{
    [CustomPropertyDrawer(typeof(TargetType))]
    public class TargetTypeDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            EditorGUI.BeginChangeCheck();
            var targetType = property.FindPropertyRelative("type");
            targetType.intValue = EditorGUI.Popup(position, targetType.intValue, GetTargetsNames());
            if (EditorGUI.EndChangeCheck())
            {
                var targetsEditor = TargetEditorUtils.TargetEditorScriptable;
                var targetObject = PropertyUtils.GetParent(property) as TargetObject;
                SpriteList sprites = targetsEditor.GetTargetbyName(GetTargetsNames()[targetType.intValue]).defaultSprites.FirstOrDefault()?.sprites.Copy();
                targetObject.sprites = sprites;
                var targetLevel = property.serializedObject.targetObject as TargetLevel;
                targetObject.targetType.type = targetType.intValue;
                targetLevel.saveData();
                property.serializedObject.Update();
            }
            EditorGUI.EndProperty();
        }

        public string[] GetTargetsNames()
        {
            return TargetEditorUtils.TargetEditorScriptable.targets.Select(i => i.name).ToArray();
        }
    }
}