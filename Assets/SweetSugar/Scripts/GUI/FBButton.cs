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

using SweetSugar.Scripts.Integrations.Network;
using UnityEngine;
#if FACEBOOK
using Facebook.Unity;

#endif

namespace SweetSugar.Scripts.GUI
{
	/// <summary>
	/// Hides or shows Facebook login button
	/// </summary>
	public class FBButton : MonoBehaviour {
		public bool showIfLogged;
		public GameObject button;
#if FACEBOOK
		void OnEnable () {
			if (button == null)
				button = gameObject;
#if PLAYFAB || GAMESPARKS || EPSILON
			NetworkManager.OnLoginEvent += Login;
			NetworkManager.OnLogoutEvent += LogOut;
#endif
			SwitchButton ();
		}

		void OnDisable () {
#if PLAYFAB || GAMESPARKS || EPSILON
			NetworkManager.OnLoginEvent -= Login;
			NetworkManager.OnLogoutEvent -= LogOut;
#endif
		}

		void SwitchButton () {
			if (FB.IsLoggedIn)
				button.SetActive (showIfLogged);
			else
				button.SetActive (!showIfLogged);
		
		}

		void Login () {
			SwitchButton ();
		}

		void LogOut () {
			SwitchButton ();
		}
#else
	void OnEnable () {
		gameObject.SetActive(false);
	}
#endif

	}
}
