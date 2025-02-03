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
#if PLAYFAB
using PlayFab;
#endif
using UnityEngine;

namespace SweetSugar.Scripts.Integrations.Network
{
	public class PlayFabCurrencyManager : ICurrencyManager {

		public PlayFabCurrencyManager () {
		}


		public  void IncBalance (int amount) {
			#if PLAYFAB
		PlayFab.ClientModels.AddUserVirtualCurrencyRequest request = new PlayFab.ClientModels.AddUserVirtualCurrencyRequest () {
			VirtualCurrency = "GC",
			Amount = amount
		};

		PlayFabClientAPI.AddUserVirtualCurrency (request, (result) => {
			Debug.Log (result.Balance);
		},
			(error) => {
				Debug.Log (error.ErrorMessage);
			});
			#endif
		}

		public  void DecBalance (int amount) {
			#if PLAYFAB
		PlayFab.ClientModels.SubtractUserVirtualCurrencyRequest request = new PlayFab.ClientModels.SubtractUserVirtualCurrencyRequest () {
			VirtualCurrency = "GC",
			Amount = amount
		};

		PlayFabClientAPI.SubtractUserVirtualCurrency (request, (result) => {
			Debug.Log (result.Balance);
		},
			(error) => {
				Debug.Log (error.ErrorMessage);
			});
			#endif
		}

		public  void SetBalance (int newbalance) {
			#if PLAYFAB
		PlayFab.ClientModels.AddUserVirtualCurrencyRequest request = new PlayFab.ClientModels.AddUserVirtualCurrencyRequest () {
			VirtualCurrency = "GC",
			Amount = newbalance - NetworkCurrencyManager.currentBalance
		};

		PlayFabClientAPI.AddUserVirtualCurrency (request, (result) => {
			Debug.Log (result.Balance);
		},
			(error) => {
				Debug.Log (error.ErrorMessage);
			});

			#endif
		}

		public  void GetBalance (Action<int> Callback) {
			#if PLAYFAB
		PlayFab.ClientModels.AddUserVirtualCurrencyRequest request = new PlayFab.ClientModels.AddUserVirtualCurrencyRequest () {
			VirtualCurrency = "GC"
		};

		PlayFabClientAPI.AddUserVirtualCurrency (request, (result) => {
			Callback (result.Balance);
		},
			(error) => {
				Debug.Log (error.ErrorMessage);
				//GetCurrencyList();
			});

			#endif
		}

	}
}

