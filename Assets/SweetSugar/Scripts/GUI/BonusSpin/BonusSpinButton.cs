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
using SweetSugar.Scripts.System;
using UnityEngine;
using UnityEngine.UI;

namespace SweetSugar.Scripts.GUI.BonusSpin
{
    /// <summary>
    /// Opens spinning wheel bonus game
    /// </summary>
    public class BonusSpinButton : MonoBehaviour {
        public GameObject spin;
        private Button button;
        private Image image;

        private void OnEnable()
        {
            button = GetComponent<Button>();
            image = GetComponent<Image>();
        }

        private void Start()
        {
            button.interactable = false;
            image.color = new Color(1,1,1,0);
            if (ServerTime.THIS.dateReceived)
                CheckSpin();
            else ServerTime.OnDateReceived += CheckSpin;
        }
        
        /// <summary>
        /// Check server to show or hide the button
        /// </summary>
        private void CheckSpin()
        {
            if (this == null)
                return;

            button.interactable = true;
            image.color = new Color(1,1,1,1);

            string latestSpinDate = PlayerPrefs.GetString("Spin");
            if (latestSpinDate == "" || latestSpinDate == default(DateTime).ToString())
            {
                latestSpinDate = ServerTime.THIS.serverTime.ToString();
                if(this != null)
                    gameObject.SetActive(true);
                return;
            }

            var latestDate = DateTime.Parse(latestSpinDate);
            if (spin != null)
            {
                var spinned = Mathf.Clamp(PlayerPrefs.GetInt("Spinned", 0), 0, spin.GetComponent<BonusSpin>().spinPrice.Length );
                if (ServerTime.THIS.serverTime.Subtract(latestDate).TotalHours < 24 && spinned >= spin.GetComponent<BonusSpin>().spinPrice.Length )
                    gameObject.SetActive(false);
                else if(ServerTime.THIS.serverTime.Subtract(latestDate).TotalHours >= 24)
                {
                    PlayerPrefs.SetInt("Spinned", 0);
                    gameObject?.SetActive(true);
                }
                else
                    gameObject?.SetActive(true);
            }
        }

        private void OnDisable()
        {
//        ServerTime.OnDateReceived -= CheckSpin;
        }

        public void OnClick()
        {
            spin.SetActive(true);
        }

        public void OnSpin()
        {
            SetDate();
            CheckSpin();
        }

        void SetDate(){
            PlayerPrefs.SetString("Spin",ServerTime.THIS.serverTime.ToString());
        }
    }
}