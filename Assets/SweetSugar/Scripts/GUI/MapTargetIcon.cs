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

using System.Collections;
using SweetSugar.Scripts.Core;
using SweetSugar.Scripts.TargetScripts.TargetSystem;
using UnityEngine;

namespace SweetSugar.Scripts.GUI
{
    /// <summary>
    /// Target icon handler on the map
    /// </summary>
    public class MapTargetIcon : MonoBehaviour
    {
        private int num;
        public Sprite[] targetSprite;
        private TargetContainer tar;
        private LIMIT limitType;
        void OnEnable()
        {
            StartCoroutine(loadTarget());
        }

        IEnumerator loadTarget()
        {
            num = int.Parse(transform.parent.name.Replace("Level", ""));
            LoadLevel(num);
            yield return new WaitForSeconds(0.1f);
            if (limitType == LIMIT.TIME)
                GetComponent<SpriteRenderer>().sprite = targetSprite[4];
            // else//TODO: check map target icon
            // GetComponent<SpriteRenderer>().sprite = LevelData.GetTargetSprites()[]

        }

        void LoadLevel(int n)
        {
            //TODO: setup preload level
            // TextAsset map = Resources.Load("Levels/" + n) as TextAsset;
            // if (map != null)
            // {
            //     string mapText = map.text;
            //     string[] lines = mapText.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            //     int mapLine = 0;
            //     foreach (string line in lines)
            //     {
            //         //check if line is game mode line
            //         if (line.StartsWith("MODE"))
            //         {
            //             //Replace GM to get mode number, 
            //             string modeString = line.Replace("MODE", string.Empty).Trim();
            //             //then parse it to interger
            //             tar = (TargetContainer)int.Parse(modeString);
            //             //Assign game mode
            //         }
            //         else if (line.StartsWith("LIMIT"))
            //         {
            //             string blocksString = line.Replace("LIMIT", string.Empty).Trim();
            //             string[] sizes = blocksString.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            //             limitType = (LIMIT)int.Parse(sizes[0]);
            //         }

            //     }
            // }

        }

        void Update()
        {

        }
    }
}
