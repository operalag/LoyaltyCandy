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
using UnityEngine;
#if UNITY_ANALYTICS

#endif

namespace SweetSugar.Scripts.Integrations
{
    /// <summary>
    /// Game events listener.
    /// </summary>
    public class EventsListener : MonoBehaviour {

        void OnEnable() {
            LevelManager.OnMapState += OnMapState;
            LevelManager.OnEnterGame += OnEnterGame;
            LevelManager.OnLevelLoaded += OnLevelLoaded;
            LevelManager.OnMenuPlay += OnMenuPlay;
            LevelManager.OnMenuComplete += OnMenuComplete;
            LevelManager.OnStartPlay += OnStartPlay;
            LevelManager.OnWin += OnWin;
            LevelManager.OnLose += OnLose;

        }

        void OnDisable() {
            LevelManager.OnMapState -= OnMapState;
            LevelManager.OnEnterGame -= OnEnterGame;
            LevelManager.OnLevelLoaded -= OnLevelLoaded;
            LevelManager.OnMenuPlay -= OnMenuPlay;
            LevelManager.OnMenuComplete -= OnMenuComplete;
            LevelManager.OnStartPlay -= OnStartPlay;
            LevelManager.OnWin -= OnWin;
            LevelManager.OnLose -= OnLose;

        }

        #region GAME_EVENTS
        void OnMapState() {
        }
        void OnEnterGame() {
            AnalyticsEvent("OnEnterGame", LevelManager.THIS.currentLevel);
        }
        void OnLevelLoaded() {
        }
        void OnMenuPlay() {
        }
        void OnMenuComplete() {
        }
        void OnStartPlay() {
        }
        void OnWin() {
            AnalyticsEvent("OnWin", LevelManager.THIS.currentLevel);
        }
        void OnLose() {
            AnalyticsEvent("OnLose", LevelManager.THIS.currentLevel);
        }

        #endregion

        void AnalyticsEvent(string _event, int level) {
#if UNITY_ANALYTICS
            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add(_event, level);
            Analytics.CustomEvent(_event, dic);

#endif
        }


    }
}
