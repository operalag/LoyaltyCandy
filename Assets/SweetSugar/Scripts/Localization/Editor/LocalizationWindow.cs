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

using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace SweetSugar.Scripts.Localization.Editor
{
    public class LocalizationWindow : EditorWindow
    {
        //string myString = "Hello World";
        //bool groupEnabled;
        //bool myBool = true;
        //float myFloat = 1.23f;
        private static List<MyStruct> array;
        private static LocalizationWindow window;
        private Vector2 scrollPos;
        private SystemLanguage lang;
        private Dictionary<int, string> _dic;
        private IOrderedEnumerable<LocalizeText> _findObjectsOfLocalizeText;
        private List<MyStruct> _list;

        // Add menu item named "My Window" to the Window menu
        public static void ShowWindow()
        {
            //Show existing window instance. If one doesn't exist, make one.
            window = (LocalizationWindow)GetWindow(typeof(LocalizationWindow));
            window.Show();
        }

        private void OnEnable()
        {
            lang = SystemLanguage.English;
        }

        struct MyStruct
        {
            public GameObject obj;
            public int id;
            public string text;
        }
        
        public void OnFocus()
        {
            _findObjectsOfLocalizeText = Resources.FindObjectsOfTypeAll<LocalizeText>().OrderBy(i=>i.instanceID);
            LocalizationManager.LoadLanguage(lang.ToString());
            _dic = LocalizationManager._dic;
        }

        void OnGUI()
        {
            lang = (SystemLanguage) EditorGUILayout.EnumPopup(lang);
            _list = GetList();
            if (GUILayout.Button("Save"))
            {
                
            }

            EditorGUILayout.BeginVertical();
            scrollPos =
                EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Width(position.width), GUILayout.Height(position.height-100));
            foreach (var langLine in _list)
            {
                GUILayout.BeginHorizontal();
                {
                    
                    
                }
                GUILayout.EndHorizontal();

            }

            EditorGUILayout.EndScrollView();
            EditorGUILayout.EndVertical();

        }

        List<MyStruct> GetList()
        {
            List<MyStruct> list = new List<MyStruct>();
            foreach (var langLine in _dic)
            {
                var l = _findObjectsOfLocalizeText.Where(i => i.instanceID == langLine.Key);
                list.AddRange(l.Select(localizeText => new MyStruct {obj = localizeText.gameObject, id = localizeText.instanceID, text = langLine.Value}));
            }
            return list;
        }
    }
}

