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

using UnityEngine;

namespace SweetSugar.Scripts.Integrations
{
[CreateAssetMenu(fileName = "UnityAdsID", menuName = "UnityAdsID", order = 1)]
    public class UnityAdsID : ScriptableObject
    {
        public bool enable;
        public string androidID;
        public string iOSID;
        [Space(20)]
        public string unityRewardedAndroid;
        public string unityRewardediOS;
        public string unityInterstitialAndroid;
        public string unityInterstitialiOS;
        
        // private void OnValidate()
        // {
        //     #if UNITY_EDITOR
        //     if(enable) DefineSymbolsUtils.AddSymbol("UNITY_ADS");
        //     else DefineSymbolsUtils.DeleteSymbol("UNITY_ADS");
        //     #endif
        // }
    }
}