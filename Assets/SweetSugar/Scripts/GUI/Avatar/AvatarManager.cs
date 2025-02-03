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
using SweetSugar.Scripts.Integrations;
using SweetSugar.Scripts.Integrations.Network;
using UnityEngine;

namespace SweetSugar.Scripts.GUI.Avatar
{
	/// <summary>
	/// Handles friend avatars on the map
	/// </summary>
	public class AvatarManager : MonoBehaviour {
		[SerializeField] private GameObject avatarPrefab;
		public List<GameObject> avatars = new List<GameObject> ();

		void OnEnable () {//1.3.3
#if PLAYFAB || GAMESPARKS || EPSILON
			NetworkManager.OnFriendsOnMapLoaded += CheckFriendsList;

			NetworkManager.friendsManager?.PlaceFriendsPositionsOnMap();
#endif
		}

		void OnDisable () {//1.3.3
#if PLAYFAB || GAMESPARKS || EPSILON
			NetworkManager.OnFriendsOnMapLoaded -= CheckFriendsList;
#endif
		}

		void CheckFriendsList () {
#if GAMESPARKS || PLAYFAB
            var Friends = FacebookManager.THIS.Friends;

            for (var i = 0; i < Friends.Count; i++)
            {
                CreateAvatar(Friends[i]);
            }
#elif EPSILON
			var Friends = FacebookManager.THIS.Friends.Where(i => i.id != FacebookManager.userID).ToArray();

			for (var i = 0; i < Friends.Length; i++)
			{
				CreateAvatar(Friends[i]);
			}
#endif
		}

		/// <summary>
		/// Creates the friend's avatar.
		/// </summary>
		void CreateAvatar (FriendData friendData) {
			var friendAvatar = friendData.avatar;
			if (friendAvatar == null) {
				friendAvatar = Instantiate (Resources.Load ("Prefabs/FriendAvatar")) as GameObject;
				avatars.Add (friendAvatar);
				friendData.avatar = friendAvatar;
				friendAvatar.transform.SetParent (transform);
			}
			friendAvatar.GetComponent<FriendAvatar> ().FriendData = friendData;
		}

	}
}
