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
using SweetSugar.Scripts.Localization;
using TMPro;
using UnityEngine;

namespace SweetSugar.Scripts.GUI
{
    /// <summary>
    /// Moves / Time label in the game
    /// </summary>
    public class MovesLabel : MonoBehaviour
    {
        // Use this for initialization
        void OnEnable()
        {
            if(LevelManager.THIS?.levelData == null || !LevelManager.THIS.levelLoaded)
                LevelManager.OnLevelLoaded += Reset;
            else 
                Reset();
        }

        void OnDisable()
        {
            LevelManager.OnLevelLoaded -= Reset;
        }


    void Reset()
    {
        if (LevelManager.THIS != null && LevelManager.THIS.levelLoaded)
        {
            if (LevelManager.THIS.levelData.limitType == LIMIT.MOVES)
                GetComponent<TextMeshProUGUI>().text = LocalizationManager.GetText(41, GetComponent<TextMeshProUGUI>().text);
            else
                GetComponent<TextMeshProUGUI>().text = LocalizationManager.GetText(77, GetComponent<TextMeshProUGUI>().text);
        }

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
