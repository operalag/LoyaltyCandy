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
using UnityEngine.SceneManagement;

namespace SweetSugar.Scripts.MapScripts
{
	public class TestLevelGUI : MonoBehaviour {
		public int LevelNumber;

		public void OnGUI () {
			GUILayout.BeginVertical ();

			if (GUILayout.Button ("Complete with 1 star")) {
				LevelsMap.CompleteLevel (LevelNumber, 1);
				GoBack ();
			}

			if (GUILayout.Button ("Complete with 2 star")) {
				LevelsMap.CompleteLevel (LevelNumber, 2);
				GoBack ();
			}

			if (GUILayout.Button ("Complete with 3 star")) {
				LevelsMap.CompleteLevel (LevelNumber, 3);
				GoBack ();
			}

			if (GUILayout.Button ("Back")) {
				GoBack ();
			}

			GUILayout.EndVertical ();
		}

		private void GoBack () {
			SceneManager.LoadScene ("demo");
		}
	}
}
