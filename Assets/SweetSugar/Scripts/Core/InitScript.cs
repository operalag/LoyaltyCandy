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
using System.Collections;
using EdjCase.ICP.Candid.Models;
using LoyaltyCandy;
using LoyaltyCandy.ClimateWallet.Models;
using SweetSugar.Scripts.AdsEvents.GoogleRewardedAds;
using SweetSugar.Scripts.GUI;
using SweetSugar.Scripts.GUI.BonusSpin;
using SweetSugar.Scripts.GUI.Boost;
using SweetSugar.Scripts.Integrations.Network;
using SweetSugar.Scripts.Level;
using SweetSugar.Scripts.MapScripts;
using SweetSugar.Scripts.System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SweetSugar.Scripts.Core
{
    /// <summary>
    /// class for main system variables, ads control and in-app purchasing
    /// </summary>
    public class InitScript : MonoBehaviour
    {
        public static InitScript Instance;

        /// opening level in Menu Play
        public static int openLevel;

        ///life gaining timer
        public static float RestLifeTimer;

        ///date of exit for life timer
        public static string DateOfExit;

        //reward which can be receive after watching rewarded ads
        public RewardsType currentReward;

        ///amount of life
        public static int lifes { get; set; }

        //EDITOR: max amount of life
        public int CapOfLife = 5;

        //EDITOR: time for rest life
        public float TotalTimeForRestLifeHours;

        //EDITOR: time for rest life
        public float TotalTimeForRestLifeMin = 15;

        //EDITOR: time for rest life
        public float TotalTimeForRestLifeSec = 60;

        //EDITOR: coins gifted in start
        public int FirstGems = 20;

        //amount of coins
        public static int Gems;

        //wait for purchasing of coins succeed
        public static int waitedPurchaseGems;

        //EDITOR: how often to show the "Rate us on the store" popup
        public int ShowRateEvery;

        //EDITOR: rate url
        public string RateURL;

        public string RateURLIOS;

        //rate popup reference
        private GameObject rate;

        //EDITOR: amount for rewarded ads
        public int rewardedGems = 5;

        //EDITOR: should player lose a life for every passed level
        public bool losingLifeEveryGame;

        //daily reward popup reference
        public GameObject DailyMenu;
        
        private ICPClient icpClient;

        // Use this for initialization
        void Awake()
        {
            Application.targetFrameRate = 60;
            Application.runInBackground = true;
            Instance = this;
            RestLifeTimer = PlayerPrefs.GetFloat("RestLifeTimer");
            DateOfExit = PlayerPrefs.GetString("DateOfExit", "");
            DebugLogKeeper.Init();

        }

        private void InitComponents()
        {
            rate = Instantiate(Resources.Load("Prefabs/Rate")) as GameObject;
            rate.SetActive(false);
            rate.transform.SetParent(MenuReference.THIS.transform);
            rate.transform.localPosition = Vector3.zero;
            rate.GetComponent<RectTransform>().offsetMin = new Vector2(-5, -5);
            rate.GetComponent<RectTransform>().offsetMax = new Vector2(5, 5);
            //        rate.GetComponent<RectTransform>().anchoredPosition = (Resources.Load("Prefabs/Rate") as GameObject).GetComponent<RectTransform>().anchoredPosition;
            rate.transform.localScale = Vector3.one;
            var g = MenuReference.THIS.Reward.gameObject;
            g.SetActive(true);
            g.SetActive(false);
            if (CrosssceneData.totalLevels == 0)
                CrosssceneData.totalLevels = LoadingManager.GetLastLevelNum();
            /*#if FACEBOOK
                        FacebookManager fbManager = new GameObject("FacebookManager").AddComponent<FacebookManager>();
            #endif*/
#if GOOGLE_MOBILE_ADS
            var obj = FindObjectOfType<RewAdmobManager>();
            if (obj == null)
            {
                GameObject gm = new GameObject("AdmobRewarded");
                gm.AddComponent<RewAdmobManager>();
            }
#endif

            currentReward = RewardsType.NONE;
        }

        void Start()
        {
            icpClient = ICPConnector.Client;

            icpClient.OnRead += UpdateUI;
            icpClient.OnSet += UpdateUI;

            Gems = PlayerPrefs.GetInt("Gems");
            lifes = PlayerPrefs.GetInt("Lifes");
            if (PlayerPrefs.GetInt("Lauched") == 0)
            {
                //First lauching
                lifes = CapOfLife;
                PlayerPrefs.SetInt("Lifes", lifes);

                SetGems(FirstGems);
                Gems = FirstGems;

                PlayerPrefs.SetInt("Music", 1);
                PlayerPrefs.SetInt("Sound", 1);

                PlayerPrefs.SetInt("Lauched", 1);
                PlayerPrefs.Save();
            }

            InitComponents();
        }

        // private void UpdateUI(bool success, object result, string message)
        // {
        //     // Gems are set via the Counter_.cs script. Not ideal but we will work with it for now
        //     // The counter script constantly updates the text based on a Timer
        //     // and reads from the PlayerPrefs value

        //     if (success && int.TryParse(result.ToString(), out Gems))
        //     {
        //         SaveGemsToPrefs(Gems);
        //     }
        //     else
        //     {
        //         if (!success)
        //         {
        //             Debug.LogError(message);
        //         }
        //         else
        //         {
        //             Debug.LogError("Error converting result to int " + result);
        //         }
        //     }
        // }
        
        private void UpdateUI(bool success, object result, string message)
        {
            // Gems are set via the Counter_.cs script. Not ideal but we will work with it for now
            // The counter script constantly updates the text based on a Timer
            // and reads from the PlayerPrefs value

            GameData gameData = (GameData) result;
            
            if (success && int.TryParse(gameData.Gem.ToString(), out Gems))
            {
                SaveGemsToPrefs(Gems);
            }
            else
            {
                if (!success)
                {
                    Debug.LogError(message);
                }
                else
                {
                    Debug.LogError("Error converting result to int " + result);
                }
            }
        }

        public void SaveLevelStarsCount(int level, int starsCount)
        {
            Debug.Log(string.Format("Stars count {0} of level {1} saved.", starsCount, level));
            PlayerPrefs.SetInt(GetLevelKey(level), starsCount);

        }

        private string GetLevelKey(int number)
        {
            return string.Format("Level.{0:000}.StarsCount", number);
        }

        public void ShowRate()
        {
            rate.SetActive(true);
        }


        public void ShowReward()
        {
            var reward = MenuReference.THIS.Reward.GetComponent<RewardIcon>();
            if (currentReward == RewardsType.GetGems)
            {
                ShowGemsReward(rewardedGems);
                MenuReference.THIS.GemsShop.GetComponent<AnimationEventManager>().CloseMenu();
            }
            else if (currentReward == RewardsType.GetLifes)
            {
                reward.SetIconSprite(1);
                reward.gameObject.SetActive(true);
                RestoreLifes();
                MenuReference.THIS.LiveShop.GetComponent<AnimationEventManager>().CloseMenu();
            }
            else if (currentReward == RewardsType.GetGoOn)
            {
                MenuReference.THIS.PreFailed.GetComponent<AnimationEventManager>().GoOnFailed();
            }
            else if(currentReward == RewardsType.FreeAction)
            {
                MenuReference.THIS.BonusSpin.GetComponent<BonusSpin>().StartSpin();
            }

            currentReward = RewardsType.NONE;
        }

        public void ShowGemsReward(int amount)
        {
            var reward = MenuReference.THIS.Reward.GetComponent<RewardIcon>();
            reward.SetIconSprite(0);
            reward.gameObject.SetActive(true);
            AddGems(amount);
        }

        private void SetGems(int count)
        {
            Gems = count;

            // Save coins to the wallet
            icpClient.SaveCoins(Gems);

            SaveGemsToPrefs(Gems);
        }

        private static void SaveGemsToPrefs(int gems)
        {
            PlayerPrefs.SetInt("Gems", gems);
            PlayerPrefs.Save();
        }

        public void AddGems(int count)
        {
            SetGems(Gems + count);
#if PLAYFAB || GAMESPARKS || EPSILON
            NetworkManager.currencyManager.IncBalance(count);
#endif

        }

        public void SpendGems(int count)
        {
            SoundBase.Instance.PlayOneShot(SoundBase.Instance.cash);
            SetGems(Gems - count);
#if PLAYFAB || GAMESPARKS || EPSILON
            NetworkManager.currencyManager.DecBalance(count);
#endif

        }


        public void RestoreLifes()
        {
            lifes = CapOfLife;
            PlayerPrefs.SetInt("Lifes", lifes);
            PlayerPrefs.Save();
            
            FindObjectOfType<LIFESAddCounter>()?.ResetTimer();
        }

        public void AddLife(int count)
        {
            lifes += count;
            if (lifes > CapOfLife)
                lifes = CapOfLife;
            PlayerPrefs.SetInt("Lifes", lifes);
            PlayerPrefs.Save();
        }

        public int GetLife()
        {
            if (lifes > CapOfLife)
            {
                lifes = CapOfLife;
                PlayerPrefs.SetInt("Lifes", lifes);
                PlayerPrefs.Save();
            }

            return lifes;
        }

        public void PurchaseSucceded()
        {
            SoundBase.Instance.PlayOneShot(SoundBase.Instance.cash);
            AddGems(waitedPurchaseGems);
            waitedPurchaseGems = 0;
        }

        public void SpendLife(int count)
        {
            if (lifes > 0)
            {
                lifes -= count;
                PlayerPrefs.SetInt("Lifes", lifes);
                PlayerPrefs.Save();
            }

            //else
            //{
            //    GameObject.Find("Canvas").transform.Find("RestoreLifes").gameObject.SetActive(true);
            //}
        }

        public void BuyBoost(BoostType boostType, int price, int count)
        {
            PlayerPrefs.SetInt("" + boostType, PlayerPrefs.GetInt("" + boostType) + count);
            PlayerPrefs.Save();
#if PLAYFAB || GAMESPARKS
            //NetworkManager.dataManager.SetBoosterData();
#endif
        }

        public void SpendBoost(BoostType boostType)
        {
            PlayerPrefs.SetInt("" + boostType, PlayerPrefs.GetInt("" + boostType) - 1);
            PlayerPrefs.Save();
#if PLAYFAB || GAMESPARKS
            //NetworkManager.dataManager.SetBoosterData();
#endif
        }

        void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                if (RestLifeTimer > 0)
                {
                    PlayerPrefs.SetFloat("RestLifeTimer", RestLifeTimer);
                }

                PlayerPrefs.SetInt("Lifes", lifes);
                PlayerPrefs.SetString("DateOfExit", ServerTime.THIS.serverTime.ToString());
                PlayerPrefs.Save();
            }
        }

        void OnApplicationQuit()
        {
            if (RestLifeTimer > 0)
            {
                PlayerPrefs.SetFloat("RestLifeTimer", RestLifeTimer);
            }

            PlayerPrefs.SetInt("Lifes", lifes);
            PlayerPrefs.SetString("DateOfExit", ServerTime.THIS.serverTime.ToString());
            PlayerPrefs.Save();
        }

        public void OnLevelClicked(object sender, LevelReachedEventArgs args)
        {
            if (EventSystem.current.IsPointerOverGameObject(-1))
                return;
            if (!GameObject.Find("CanvasGlobal").transform.Find("MenuPlay").gameObject.activeSelf &&
                !GameObject.Find("CanvasGlobal").transform.Find("GemsShop").gameObject.activeSelf &&
                !GameObject.Find("CanvasGlobal").transform.Find("LiveShop").gameObject.activeSelf)
            {
                SoundBase.Instance.PlayOneShot(SoundBase.Instance.click);
                OpenMenuPlay(args.Number);
                ShowLeadboard(args.Number);
            }
        }

        public static void OpenMenuPlay(int num)
        {
            PlayerPrefs.SetInt("OpenLevel", num);
            PlayerPrefs.Save();
            LevelManager.THIS.MenuPlayEvent();
            LevelManager.THIS.LoadLevel();
            openLevel = num;
            CrosssceneData.openNextLevel = false;
            MenuReference.THIS.MenuPlay.gameObject.SetActive(true);
        }

        static void ShowLeadboard(int levelNumber)
        {
#if EPSILON
            var leadboardList = FindObjectsOfType<LeadboardManager>();
            foreach (var obj in leadboardList)
            {
                obj.levelNumber = levelNumber;
            }
#endif
        }
        
        void OnEnable()
        {
            LevelsMap.LevelSelected += OnLevelClicked;
            LevelsMap.OnLevelReached += OnLevelReached;

        }

        void OnDisable()
        {
            LevelsMap.LevelSelected -= OnLevelClicked;
            LevelsMap.OnLevelReached -= OnLevelReached;

            PlayerPrefs.SetFloat("RestLifeTimer", RestLifeTimer);
            PlayerPrefs.SetInt("Lifes", lifes);
            PlayerPrefs.SetString("DateOfExit", ServerTime.THIS.serverTime.ToString());
            PlayerPrefs.Save();

        }

        void OnLevelReached()
        {
            var num = PlayerPrefs.GetInt("OpenLevel");
            if (CrosssceneData.openNextLevel && CrosssceneData.totalLevels >= num)
            {
                OpenMenuPlay(num);
            }
        }
        
        
    }

    /// moves or time is level limit type
    public enum LIMIT
    {
        MOVES,
        TIME
    }

    /// reward type for rewarded ads watching
    public enum RewardsType
    {
        GetLifes,
        GetGems,
        GetGoOn,
        FreeAction,
        NONE
    }
}
