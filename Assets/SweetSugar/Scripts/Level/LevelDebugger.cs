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
using System.IO;
using UnityEngine;

//using UnityEditor;

namespace SweetSugar.Scripts.Level
{
    public class LevelDebugger {

        public static void SaveMap(int[] items, int maxCols, int maxRows) {
            var saveString = "";
            var filename = "levelstate.txt";


            //set map data
            for (var row = 0; row < maxRows; row++) {
                for (var col = 0; col < maxCols; col++) {
                    saveString += items[row * maxCols + col];
                    saveString += " ";
                }
            }
            //Write to file
            var activeDir = Application.dataPath + @"/SweetSugar/Resources/";
            var newPath = Path.Combine(activeDir, filename + ".txt");
            var sw = new StreamWriter(newPath);
            sw.Write(saveString);
            sw.Close();
            //AssetDatabase.Refresh();

        }

        public static int[] LoadMap(int maxCols, int maxRows) {
            var filename = "levelstate.txt";
            var items = new int[99];
            var row = 0;
            var mapText = Resources.Load(filename) as TextAsset;
            var filetext = mapText.text;
            var lines = filetext.Split(new[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var line in lines) {
                var st = line.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                for (var i = 0; i < st.Length; i++) {
                    items[row * maxCols + i] = int.Parse(st[i]);
                }
                row++;
            }
            return items;

        }
    }
}
