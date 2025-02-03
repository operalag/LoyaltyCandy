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
using SweetSugar.Scripts.Level;
using SweetSugar.Scripts.System;
using SweetSugar.Scripts.TargetScripts.TargetSystem;
using UnityEngine;

namespace SweetSugar.Scripts.TargetScripts
{
    /// <summary>
    /// Solid blocks target
    /// </summary>
    public class SolidBlock : Target
    {
        public override int CountTarget()
        {
            return GetDestinationCount();
        }

        public override int CountTargetSublevel()
        {
            return GetDestinationCountSublevel();
        }
        public override void InitTarget(LevelData levelData)
        {
            subTargetContainers[0].count = levelData.fields.Sum(x => x.levelSquares.Count(i =>  i.block == SquareTypes.SolidBlock ||  i.obstacle == SquareTypes.SolidBlock));
        }
        public override int GetDestinationCountSublevel()
        {
            var count = 0;
            var field = LevelManager.THIS.field;
            count += field.CountSquaresByType(GetType().Name.ToString());
            return count;
        }

        public override int GetDestinationCount()
        {
            var count = 0;
            var fieldBoards = LevelManager.THIS.fieldBoards;
            foreach (var item in fieldBoards)
            {
                // count += item.CountSquaresByType(this.GetType().ToString());
                count += item.GetTargetObjects().Count();
            }
            return count;
        }

        public override void FulfillTarget<T>(T[] _items)
        {
            if (_items.TryGetElement(0)?.GetType() != typeof(Square)) return;
            var items = _items as Square[];
            var sugarList = items?.Where(i => i.type.ToString() == GetType().Name.ToString());
            var pos = TargetGUI.GetTargetGUIPosition(LevelData.THIS.GetFirstTarget(true).name);
            foreach (var sugarBlock in sugarList)
            {
                Square sugarBlockSubSquare = sugarBlock.GetSubSquare();
                Vector2 scale = sugarBlockSubSquare.transform.localScale;
                var targetContainer = subTargetContainers.Where(i => sugarBlock.type.ToString().Contains(i.targetPrefab.name)).FirstOrDefault();
                amount++;
                var itemAnim = new GameObject();
                var animComp = itemAnim.AddComponent<AnimateItems>();
                LevelManager.THIS.animateItems.Add(animComp);
                animComp.InitAnimation(sugarBlockSubSquare.gameObject, pos, scale, () => { targetContainer.changeCount(-1); });
                // square.DestroyBlock();
            }
        }

        public override void DestroyEvent(GameObject obj)
        {
            // Debug.Log(obj);
        }

        public override int GetCount(string spriteName)
        {
            // foreach (var item in subTargetContainers)
            // {
            //     if (item.targetPrefab.GetComponent<SpriteRenderer>()?.sprite.name == spriteName)
            //         return item.GetCount();
            // }

            return CountTarget();
        }

        public override bool IsTotalTargetReached()
        {
            return CountTarget() <= 0;
        }

        public override bool IsTargetReachedSublevel()
        {
            return CountTargetSublevel() <= 0;
        }
    }
}