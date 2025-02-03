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

#if EPSILON
using EpsilonServer;
#endif

#if PLAYFAB || GAMESPARKS || EPSILON
#if GAMESPARKS
#endif

using SweetSugar.Scripts.Core;
using SweetSugar.Scripts.Integrations.Network;
using UnityEngine;
#if PLAYFAB
using PlayFab.ClientModels;
using PlayFab;
#endif

namespace SweetSugar.Scripts.Integrations.Network
{
    /// <summary>
    /// Currency manager
    /// </summary>
    public class NetworkCurrencyManager
    {
        public static int currentBalance;
        ICurrencyManager currencyMananager;

        public NetworkCurrencyManager()
        {
            NetworkManager.OnLoginEvent += GetBalance;
            NetworkManager.OnLogoutEvent += Logout;
#if PLAYFAB
		currencyMananager = new PlayFabCurrencyManager ();
#elif GAMESPARKS
			currencyMananager = new GamesparksCurrencyManager ();
#elif EPSILON
            currencyMananager = new EpsilonCurrencyManager();
#endif
        }

        void Logout()
        {
            NetworkManager.OnLoginEvent -= GetBalance;
            NetworkManager.OnLogoutEvent -= Logout;
        }

        /// <summary>
        /// Increment the balance
        /// </summary>
        /// <param name="amount"></param>
        public void IncBalance(int amount)
        {
            if (!NetworkManager.THIS.IsLoggedIn)
                return;


            if (currencyMananager != null)
                currencyMananager.IncBalance(amount);
        }

        /// <summary>
        /// Decrement the balance
        /// </summary>
        /// <param name="amount"></param>
        public void DecBalance(int amount)
        {
            if (!NetworkManager.THIS.IsLoggedIn)
                return;


            if (currencyMananager != null)
                currencyMananager.DecBalance(amount);
        }

        /// <summary>
        /// define the balance
        /// </summary>
        /// <param name="newbalance"></param>
        public void SetBalance(int newbalance)
        {
            if (!NetworkManager.THIS.IsLoggedIn)
                return;

            //		GetBalance ();

            if (currencyMananager != null)
                currencyMananager.SetBalance(newbalance);
        }

        /// <summary>
        /// Get the balance
        /// </summary>
        public void GetBalance()
        {
            if (!NetworkManager.THIS.IsLoggedIn)
                return;

            if (currencyMananager != null)
            {
                currencyMananager.GetBalance(balance =>
                {
                    Debug.Log(balance);
                    currentBalance = balance;
                    if (currentBalance >= InitScript.Gems)
                        InitScript.Instance.SetGems(balance);
                    else
                        SetBalance(InitScript.Gems);
                });
            }
        }
    }
}

#endif