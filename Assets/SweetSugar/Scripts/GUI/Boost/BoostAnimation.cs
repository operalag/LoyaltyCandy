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
using SweetSugar.Scripts.Blocks;
using SweetSugar.Scripts.Core;
using SweetSugar.Scripts.Items;
using SweetSugar.Scripts.TargetScripts.TargetSystem;
using UnityEngine;

namespace SweetSugar.Scripts.GUI.Boost
{
    /// <summary>
    /// Boost animation events and effects
    /// </summary>
    public class BoostAnimation : MonoBehaviour
    {
        public Square square;

        public void ShowEffect()
        {
            var partcl = Instantiate(Resources.Load("Prefabs/Effects/Firework"), transform.position, Quaternion.identity) as GameObject;
            var main = partcl.GetComponent<ParticleSystem>().main;
//        main.startColor = LevelManager.THIS.scoresColors[square.Item.color];
            if (name.Contains("area_explosion"))
                main.startColor = Color.white;
            Destroy(partcl, 1f);

            if (name.Contains("area_explosion"))
            {
                var p = Instantiate(Resources.Load("Prefabs/Effects/CircleExpl"), transform.position, Quaternion.identity) as GameObject;
                Destroy(p, 0.4f);

            }
        }

        public void OnFinished(BoostType boostType)
        {
            SoundBase.Instance.PlayOneShot(SoundBase.Instance.destroyPackage);

            bool spreadTarget = LevelManager.THIS.levelData.TargetCounters.Any(i=>i.collectingAction == CollectingTypes.Spread);
            if (boostType == BoostType.ExplodeArea)
            {
                var list = LevelManager.THIS.GetItemsAround9(square);
                if (!LevelManager.THIS.AdditionalSettings.MulticolorDestroyByBoostAndMarmalade)
                    list = list.Where(i => i.currentType != ItemsTypes.MULTICOLOR).ToList();                   
                var squares = list.Select(i => i.square);
                if(spreadTarget) 
                    LevelManager.THIS.levelData.GetTargetObject().CheckSquares(squares.ToArray());

                foreach (var item in list)
                {
                    if (item != null && item.Explodable)
                    {
                        // if(spreadTarget) item.square.SetType(SquareTypes.JellyBlock, 1, SquareTypes.NONE, 1);
                        item.DestroyItem(true);
                    }
                }
            }
            if (boostType == BoostType.Bomb)
            {
                if(spreadTarget) square.SetType(SquareTypes.JellyBlock, 1, SquareTypes.NONE, 1);
                square.Item.DestroyItem(true);
            }
            LevelManager.THIS.StartCoroutine(LevelManager.THIS.FindMatchDelay());

            Destroy(gameObject);
        }
    }
}
