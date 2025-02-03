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
using SweetSugar.Scripts.Core;
using SweetSugar.Scripts.Localization;
using SweetSugar.Scripts.System;
using TMPro;
using UnityEngine;

namespace SweetSugar.Scripts.GUI
{
    /// <summary>
    /// Life time counter on the map
    /// </summary>
    public class LIFESAddCounter : MonoBehaviour
    {
        TextMeshProUGUI text;
        static float TimeLeft;
        float TotalTimeForRestLife = 15f * 60;  //8 minutes for restore life
        bool startTimer;
        DateTime templateTime;
        // Use this for initialization
        void Start()
        {
            text = GetComponent<TextMeshProUGUI>();
            TotalTimeForRestLife = InitScript.Instance.TotalTimeForRestLifeHours * 60 * 60 + InitScript.Instance.TotalTimeForRestLifeMin * 60 + InitScript.Instance.TotalTimeForRestLifeSec;
        }

        bool CheckPassedTime()
        {
            InitScript.DateOfExit = PlayerPrefs.GetString("DateOfExit", "");
            InitScript.RestLifeTimer = Mathf.Clamp(PlayerPrefs.GetFloat("RestLifeTimer", TotalTimeForRestLife), 0, TotalTimeForRestLife);

            if (InitScript.DateOfExit == "" || InitScript.DateOfExit == default(DateTime).ToString())
                InitScript.DateOfExit = ServerTime.THIS.serverTime.ToString();

            var dateOfExit = DateTime.Parse(InitScript.DateOfExit);
            float secondsPassedFromLastExit = MathF.Max((float)ServerTime.THIS.serverTime.Subtract(dateOfExit).TotalSeconds,0);
            if (secondsPassedFromLastExit > TotalTimeForRestLife * (InitScript.Instance.CapOfLife - InitScript.lifes))
            {
                InitScript.Instance.RestoreLifes();
                InitScript.RestLifeTimer = 0;
                return false;    ///we dont need lifes
            }

            InitScript.Instance.AddLife((int)Math.Floor(secondsPassedFromLastExit / TotalTimeForRestLife));
            InitScript.RestLifeTimer -= secondsPassedFromLastExit;
            return true;     ///we need lifes
        }

        void TimeCount(float tick)
        {
            InitScript.RestLifeTimer -= tick;
            if (InitScript.RestLifeTimer <= 1 && InitScript.lifes < InitScript.Instance.CapOfLife)
            {
                InitScript.Instance.AddLife(1);
                ResetTimer();
            }
            if (InitScript.RestLifeTimer <= 0)
                ResetTimer();
        }

        public void ResetTimer()
        {
            InitScript.RestLifeTimer += TotalTimeForRestLife;
        }

        // Update is called once per frame
        void Update()
        {
            if (!startTimer && (ServerTime.THIS.dateReceived && ServerTime.THIS.serverTime.Subtract(ServerTime.THIS.serverTime).Days == 0) || ServerTime.THIS.noConnection)
            {
                if (InitScript.lifes < InitScript.Instance.CapOfLife)
                {
                    if (CheckPassedTime())
                        startTimer = true;
                }
            }

                
            TimeCount(Time.deltaTime);

            if (gameObject.activeSelf)
            {
                if (InitScript.lifes < InitScript.Instance.CapOfLife)
                {
                    if (InitScript.Instance.TotalTimeForRestLifeHours > 0)
                    {
                        var hours = Mathf.FloorToInt(InitScript.RestLifeTimer / 3600);
                        var minutes = Mathf.FloorToInt((InitScript.RestLifeTimer - hours * 3600) / 60);
                        var seconds = Mathf.FloorToInt((InitScript.RestLifeTimer - hours * 3600) - minutes * 60);

                        text.enabled = true;
                        text.text = "" + string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
                    }
                    else
                    {
                        var minutes = Mathf.FloorToInt(InitScript.RestLifeTimer / 60F);
                        var seconds = Mathf.FloorToInt(InitScript.RestLifeTimer - minutes * 60);

                        text.enabled = true;
                        text.text = "" + string.Format("{0:00}:{1:00}", minutes, seconds);

                    }

                    //				//	text.text = "+1 in \n " + Mathf.FloorToInt( MainMenu.RestLifeTimer/60f) + ":" + Mathf.RoundToInt( (MainMenu.RestLifeTimer/60f - Mathf.FloorToInt( MainMenu.RestLifeTimer/60f))*60f);
                }
                else
                {
                    //text.text = "   Full";
                    text.text = LocalizationManager.GetText(38, "FULL");
                }
            }
        }

        void OnApplicationPause(bool pauseStatus)
        {
            SetFocus(!pauseStatus);
        }
        
        private void SetFocus(bool focus)
        {
            if (!focus)
                SaveExitTime();
            else
                startTimer = false;
        }

        private static void SaveExitTime()
        {
            InitScript.DateOfExit = ServerTime.THIS.serverTime.ToString();
            PlayerPrefs.SetString("DateOfExit", ServerTime.THIS.serverTime.ToString());
            PlayerPrefs.SetFloat("RestLifeTimer", InitScript.RestLifeTimer);
            PlayerPrefs.Save();
        }

        void OnApplicationQuit()
        {
            SaveExitTime();
        }
    }
}
