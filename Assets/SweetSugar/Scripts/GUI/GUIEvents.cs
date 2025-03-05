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

using SweetSugar.Scripts.Core;
using SweetSugar.Scripts.Integrations;
using SweetSugar.Scripts.MapScripts.StaticMap.Editor;
using SweetSugar.Scripts.System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SweetSugar.Scripts.GUI
{
	/// <summary>
	/// GUI events for Facebook, Settings and main scene
	/// </summary>
	public class GUIEvents : MonoBehaviour {
		public GameObject loading;
		void Update () {
			if (name == "FaceBook" || name == "Share" || name == "FaceBookLogout") {
				if (!LevelManager.THIS.FacebookEnable)
					gameObject.SetActive (false);
			}
		}

		public void Settings () {
			SoundBase.Instance.GetComponent<AudioSource> ().PlayOneShot (SoundBase.Instance.click);

			MenuReference.THIS.Settings.gameObject.SetActive (true);

		}

		public void Play () {
			SoundBase.Instance.GetComponent<AudioSource> ().PlayOneShot (SoundBase.Instance.click);
			LeanTween.Framework.LeanTween.delayedCall(4, ()=>SceneManager.LoadScene(Resources.Load<MapSwitcher>("Scriptable/MapSwitcher").GetSceneName()));
		}

		public void Pause () {
			SoundBase.Instance.GetComponent<AudioSource> ().PlayOneShot (SoundBase.Instance.click);

			if (LevelManager.THIS.gameStatus == GameState.Playing)
				GameObject.Find ("CanvasGlobal").transform.Find ("MenuPause").gameObject.SetActive (true);

		}

		public void FaceBookLogin () {
#if FACEBOOK

			FacebookManager.THIS.CallFBLogin ();
#endif
		}

		public void FaceBookLogout () {
#if FACEBOOK
			FacebookManager.THIS.CallFBLogout ();

#endif
		}

		public void Share () {
#if FACEBOOK

			FacebookManager.THIS.Share ();
#endif
		}

	}
}
