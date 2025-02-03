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
using UnityEditor;
using UnityEngine;

namespace SweetSugar.Scripts.Items.Editor
{
    [CustomPropertyDrawer(typeof(SpawnAmountObj))]
    public class SpawnAmountDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, label, property);
            var count = property.FindPropertyRelative("SpawnAmount");
            Item item = PropertyUtils.GetParent(property) as Item;
            Rect r1 = position;
            r1.height = EditorGUIUtility.singleLineHeight;
            if (item.currentType == ItemsTypes.INGREDIENT)
            {
                EditorGUI.LabelField(r1, "How many ingredients can be spawned at the same time");
                r1.y+= EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                EditorGUI.PropertyField(r1, count, new GUIContent("Spawn amount"));
            }
            else if (item.currentType == ItemsTypes.NONE)
            {
                EditorGUI.LabelField(r1, "How many time bonuses can be spawned at the same time");
                r1.y+= EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing;
                EditorGUI.PropertyField(r1, count, new GUIContent("Spawn amount"));
            }
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return base.GetPropertyHeight(property, label) + EditorGUIUtility.singleLineHeight + EditorGUIUtility.standardVerticalSpacing * 2;
        }
    }
}