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

using SweetSugar.Scripts.AdsEvents;
using SweetSugar.Scripts.Core;
using SweetSugar.Scripts.System;
using UnityEngine;
using UnityEngine.UI;

namespace SweetSugar.Scripts.Monetization
{
    public class VideoButtonMap : MonoBehaviour
    {
        public Animator anim;
        public Button button;

        private void OnEnable()
        {
            button.interactable = false;
            button.gameObject.SetActive(false);
            Invoke("Prepare",2);
        }

        private void Prepare()
        {
            if(ServerTime.THIS.dateReceived)
            {
                ShowButton();
            }
        }

        public void ShowVideoAds()
        {
            //if (!AdsManager.THIS.GetRewardedUnityAdsReady()) return;
            InitScript.Instance.currentReward = RewardsType.GetGems;

            AdsManager.THIS.ShowRewardedAds();
        }

        private void ShowButton()
        {
            button.gameObject.SetActive(true);
            button.interactable = true;
            anim.SetTrigger("show");
        }

        public void Hide()
        {
            button.interactable = false;

        }
    }
}