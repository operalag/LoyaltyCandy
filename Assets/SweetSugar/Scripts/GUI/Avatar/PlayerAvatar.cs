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
using SweetSugar.Scripts.MapScripts;
using UnityEngine;
using UnityEngine.UI;

namespace SweetSugar.Scripts.GUI.Avatar
{
    /// <summary>
    /// Player avatar. Loading picture and restore it after back to map scene
    /// </summary>
    public class PlayerAvatar : MonoBehaviour, IAvatarLoader
    {

        public Image image;
#if PLAYFAB || GAMESPARKS || EPSILON

        void Start()
        {
            image.enabled = false;
        }

        void OnEnable () {
            image = transform.Find("Character (1)/Canvas/Image").GetComponent<Image>();
      
            LevelsMap.LevelReached += OnLevelReached;
#if PLAYFAB || GAMESPARKS || EPSILON
            NetworkManager.OnPlayerPictureLoaded += ShowPicture;
            if(NetworkManager.profilePic != null) ShowPicture();
#endif
        }

        void OnDisable () {
#if PLAYFAB || GAMESPARKS || EPSILON
            NetworkManager.OnPlayerPictureLoaded -= ShowPicture;
            LevelsMap.LevelReached -= OnLevelReached;
#endif

        }
#endif

        public void ShowPicture()
        {
#if PLAYFAB || GAMESPARKS || EPSILON
            image.sprite = NetworkManager.profilePic;
#endif
            image.enabled = true;
        }

        private void OnLevelReached(object sender, LevelReachedEventArgs e)
        {
            Debug.Log(string.Format("Level {0} reached.", e.Number));
        }
    }
}
