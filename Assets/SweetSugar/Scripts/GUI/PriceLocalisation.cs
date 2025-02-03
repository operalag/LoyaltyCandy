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

using SweetSugar.Scripts.Core;
using TMPro;
using UnityEngine;

//1.1
namespace SweetSugar.Scripts.GUI
{
    /// <summary>
    /// Localized prices handler
    /// </summary>
    public class PriceLocalisation : MonoBehaviour
    {
        public TextMeshProUGUI[] prices;


        // Update is called once per frame
        void Update()
        {
#if UNITY_INAPPS
            if (UnityInAppsIntegration.THIS.m_StoreController == null) return;
            for (int i = 0; i < prices.Length; i++)
            {
                if (UnityInAppsIntegration.THIS.m_StoreController.products.WithID(LevelManager.THIS.InAppIDs[i]).metadata.localizedPrice > new decimal(0.01))
                    prices[i].text = UnityInAppsIntegration.THIS.m_StoreController.products.WithID(LevelManager.THIS.InAppIDs[i]).metadata.localizedPriceString;
            }
#endif
        }
    }
}
