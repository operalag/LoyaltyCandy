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

using System.Linq;
using SweetSugar.Scripts.Core;
using SweetSugar.Scripts.Level;
using SweetSugar.Scripts.System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SweetSugar.Scripts.GUI
{
    /// <summary>
    /// Target icon in the MenuPlay
    /// </summary>
    public class MenuTargetIcon : MonoBehaviour
    {
        public Image image;
        public TextMeshProUGUI description;
        private Image[] images;

        private void Awake()
        {
            images = transform.GetChildren().Select(i => i.GetComponent<Image>()).ToArray();
        }

    void OnEnable()
    {
        DisableImages();
        var levelData = new LevelData(Application.isPlaying, LevelManager.THIS.currentLevel);
        levelData = LoadingManager.LoadForPlay(PlayerPrefs.GetInt("OpenLevel"), levelData);
        var list = levelData.GetTargetSprites();
        description.text = levelData.GetTargetContainersForUI().First().targetLevel.GetDescription();
        for (int i = 0; i < list.Length; i++)
        {
            images[i].sprite = list[i];
            images[i].gameObject.SetActive(true);
        }
    }

        private void DisableImages()
        {
            foreach (var item in images)
            {
                item.gameObject.SetActive(false);
            }
        }

    }
}
