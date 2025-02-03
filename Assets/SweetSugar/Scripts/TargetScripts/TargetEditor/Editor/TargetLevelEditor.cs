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

using SweetSugar.Scripts.Level;
using SweetSugar.Scripts.TargetScripts.TargetSystem;
using UnityEditor;
using UnityEngine;

namespace SweetSugar.Scripts.TargetScripts.TargetEditor.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(TargetLevel))]
    public class TargetLevelEditor : UnityEditor.Editor
    {
        private TargetLevel targetLevel;
        private LevelData levelData;
        private TargetEditorScriptable targetsEditor;

        private void OnEnable()
        {
            var currentLevel = int.Parse(serializedObject.targetObject.name.Replace("TargetLevel", ""));
            targetsEditor = TargetEditorUtils.TargetEditorScriptable;
            levelData = LoadingManager.LoadlLevel(currentLevel, levelData);
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            serializedObject.Update();
            targetLevel = (TargetLevel)target;
            if (GUILayout.Button("Show all targets"))
            {
                SweetSugar.Scripts.Editor.TargetEditor.Init();
            }

            EditorGUI.BeginChangeCheck();
            if (GUILayout.Button("Load old target from level"))
            {
                targetLevel.LoadFromLevel(levelData, targetsEditor);
            }

            serializedObject.ApplyModifiedProperties();
            if (EditorGUI.EndChangeCheck())
                targetLevel.saveData();
        }

        






    }
}