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

using System.Collections;
using SweetSugar.Scripts.Integrations;
using SweetSugar.Scripts.Integrations.Network;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SweetSugar.Scripts.Leadboard
{
	/// <summary>
	/// Player icon with score and name on the leadboard
	/// </summary>
	public class LeadboardObject : MonoBehaviour
	{
		public Image icon;
		public TextMeshProUGUI place;
		public TextMeshProUGUI playerName;
		public TextMeshProUGUI score;
#if PLAYFAB || GAMESPARKS || EPSILON
		public LeadboardPlayerData playerData;

		public LeadboardPlayerData PlayerData {
			get {
				return playerData;
			}

			set {
				playerData = value;
				this.gameObject.SetActive(true);
				SetupIcon ();
			}
		}

		void SetupIcon () {
			StartCoroutine (WaitForPicture ());
		}

		 IEnumerator WaitForPicture()
        {
            print("wait for picture");
            yield return new WaitUntil(() => PlayerData != null);
            yield return new WaitUntil(() => PlayerData.friendData != null);
            transform.GetChild(0).gameObject.SetActive(true);
            #if FACEBOOK
#if GAMESPARKS || PLAYFAB
			if (PlayerData.friendData.picture == null) {
				FacebookManager.THIS.LoggedSuccefull ();
				FacebookManager.THIS.GetFriendsPicture ();
			}
			yield return new WaitUntil (() => PlayerData.friendData.picture != null);
			PlayerData.picture = PlayerData.friendData.picture;
			icon.sprite = PlayerData.picture;
			place.text = "" + PlayerData.position;
			playerName.text = PlayerData.Name;
			score.text = "" + PlayerData.score;
			if (NetworkManager.THIS.IsYou (PlayerData.userID)) {
				playerName.text = "YOU";
				playerName.color = Color.red;
				//if (LevelManager.This.gameStatus == GameState.Win) {
				//    score.text = "" + PlayerPrefs.GetInt("Score" + LevelManager.This.currentLevel);
				//   }
			}

#elif EPSILON
            if (PlayerData.friendData.pictureSprite == null)
            {
                FacebookManager.THIS.LoggedSuccefull();
                FacebookManager.THIS.GetFriendsPicture();
            }

            yield return new WaitUntil(() => PlayerData.friendData.pictureSprite != null);
            PlayerData.picture = PlayerData.friendData.pictureSprite;
            icon.sprite = PlayerData.picture;
            place.text = "" + PlayerData.position;
            playerName.text = PlayerData.Name;
            score.text = "" + PlayerData.score;
            if (NetworkManager.THIS.IsYou(PlayerData.userID))
            {
                playerName.text = "YOU";
                playerName.color = new Color(255f/255, 202f/255, 76f/255);
                //if (LevelManager.This.gameStatus == GameState.Win) {
                //    score.text = "" + PlayerPrefs.GetInt("Score" + LevelManager.This.currentLevel);
                //   }
            }
#endif
#endif
        }

#endif

	}
}
