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
using SweetSugar.Scripts.AdsEvents;
using SweetSugar.Scripts.Core;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace SweetSugar.Scripts.Integrations
{
    public class ShowAdsByButton : MonoBehaviour
    {
        public UnityEvent OnRewaredeShown;
        public bool checkRewardedAvailable;
        private CanvasGroup canvasGroup;
        public RewardsType placement;
        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();

        }

        private void OnEnable()
        {
            if (canvasGroup != null)
            {
                
                canvasGroup.alpha = 1;
                canvasGroup.blocksRaycasts = true;
                if (checkRewardedAvailable && GetComponent<Button>().onClick.GetPersistentMethodName(0) == "ShowRewardedAd" /*&& !AdManager.Instance.IsRewardedAvailable()*/)
                {
                    canvasGroup.alpha = 0;
                    canvasGroup.blocksRaycasts = false;
                    StartCoroutine(WaitForAds());
                }
            }

        }

        private IEnumerator WaitForAds()
        {
            yield return new WaitUntil(()=>AdsManager.THIS.GetRewardedUnityAdsReady());
            canvasGroup.alpha = 1;
            canvasGroup.blocksRaycasts = true;
 

        }

        private void OnDisable()
        {

        }

        private void OnRewardedShown()
        {
            OnRewaredeShown?.Invoke();

        }

        // public void ShowInterstitial(AdEvents placement)
        // {
        //     if (PlayerPrefs.GetInt("tutorialShown", 0) == 0) return;
        //     AdsManager.THIS.ShowVideo(placement);
        //     EventsListener.CustomEvent("Show ads " +placement);
        // }

        public void ShowRewardedAd()
        {
            AdsManager.OnRewardedShown += OnRewardedShown;
            AdsManager.THIS.ShowRewardedAds();
        }
    }
}