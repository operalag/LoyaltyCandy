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

using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SweetSugar.Scripts.LinqConstructor.AnyFieldInspector.Editor
{
    public static class GuiList
    {
        public static void Show(IList list, Action listChanged = null)
        {
            Type typeList = list.GetType().GetElementType();
            GUILayout.BeginVertical();
            {
                for (int i = 0; i < list.Count; i++)
                {
                    var item = list[i];
                    var itemRef = item;
                    Type type = list.GetType().GetGenericArguments().FirstOrDefault();
                    if (type != typeof(Object) && type != typeof(GameObject) && itemRef != null && type != null)
                    {
                        foreach (var field in IterateFields(ref itemRef))
                        {
                            ShowField(field, ref itemRef);
                        }
                    }
                    else
                        list[i] = EditorGUILayout.ObjectField((Object)list[i], typeof(Object), true);

                    // ShowField(itemRef.GetType().GetField("gameObject"), ref itemRef);
                }
            }
            GUILayout.EndVertical();
            GUILayout.BeginHorizontal();
            {
                if (GUILayout.Button("+"))
                {
                    list.Add(null);
                    listChanged?.Invoke();
                }
                if (GUILayout.Button("-"))
                {
                    list.RemoveAt(list.Count - 1);
                    listChanged?.Invoke();
                }
            }
            GUILayout.EndHorizontal();
        }

        static FieldInfo[] IterateFields<T>(ref T obj)
        {
            Type myType = obj.GetType();
            return myType.GetFields();
        }

        static void ShowField<T>(FieldInfo myField, ref T obj)
        {
            if (obj.GetType() != typeof(GameObject))
            {
                Type fieldType = myField.FieldType;
                var fieldValue = myField.GetValue(obj);
                var fieldName = myField.Name;
                if (fieldValue.GetType() == typeof(string) || fieldValue.GetType().BaseType == typeof(string))
                {
                    GUILayout.BeginHorizontal();
                    {
                        EditorGUILayout.LabelField(fieldName, GUILayout.Width(80));
                        myField.SetValue(obj, EditorGUILayout.TextField(fieldValue.ToString()));
                    }
                    GUILayout.EndHorizontal();
                }
                if (fieldValue.GetType() == typeof(Enum) || fieldValue.GetType().BaseType == typeof(Enum))
                    myField.SetValue(obj, EditorGUILayout.EnumPopup((Enum)fieldValue));
                if (fieldValue is IList && fieldValue.GetType().IsGenericType)
                {
                    Type typeList = fieldValue.GetType().GetGenericArguments()[0];
                    GUILayout.BeginHorizontal();
                    {
                        GUILayout.Space(50);
                        GUILayout.BeginVertical();
                        {
                            Show((IList)fieldValue);

                        }
                        GUILayout.EndVertical();
                    }
                    GUILayout.EndHorizontal();
                }
            }
            // if (fieldType == typeof(GameObject))
            // myField.SetValue(EditorGUILayout.ObjectField((GameObject)fieldValue, typeof(GameObject)), (GameObject)fieldValue);


        }

    }
}