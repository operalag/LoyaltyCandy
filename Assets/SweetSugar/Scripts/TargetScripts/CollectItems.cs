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
using SweetSugar.Scripts.Items;
using SweetSugar.Scripts.Items._Interfaces;
using SweetSugar.Scripts.Level;
using SweetSugar.Scripts.System;
using SweetSugar.Scripts.TargetScripts.TargetSystem;
using UnityEngine;

namespace SweetSugar.Scripts.TargetScripts
{
    /// <summary>
    /// collect items target
    /// </summary>
    public class CollectItems : Target
    {
        public override int CountTarget()
        {
            return amount;
        }

        public override int CountTargetSublevel()
        {
            return amount;
        }

        public override void InitTarget(LevelData levelData)
        {
            foreach (var item in subTargetContainers)
            {
                amount += item.GetCount();
            }

        }

        public override void DestroyEvent(GameObject obj)
        {


        }

        public override void FulfillTarget<T>(T[] _items)
        {
            if (_items.Length>0 && _items[0].GetType().BaseType != typeof(Item)) return;
            var items = _items as Item[];
            foreach (var item in subTargetContainers)
            {
                foreach (var obj in items)
                {
                    if (obj == null) continue;
                    var sprite = obj.GetComponent<IColorableComponent>().directSpriteRenderer.sprite;
                    if ((Sprite)item.extraObject == sprite && item.preCount > 0)
                    {
                        amount--;
                        item.preCount--;
                        var pos = TargetGUI.GetTargetGUIPosition(obj.GetComponent<IColorableComponent>().directSpriteRenderer.sprite.name);
                        var itemAnim = new GameObject();
                        var animComp = itemAnim.AddComponent<AnimateItems>();
                        LevelManager.THIS.animateItems.Add(animComp);
                        animComp.InitAnimation(obj.gameObject, pos, obj.transform.localScale, () => { item.changeCount(-1); });
                    }
                }
            }
        }

        public override int GetDestinationCount()
        {
            return destAmount;
        }

        public override int GetDestinationCountSublevel()
        {
            return destAmount;
        }

        public override bool IsTargetReachedSublevel()
        {
            return amount <= 0;
        }

        public override bool IsTotalTargetReached()
        {
            return amount <= 0;
        }

        public override int GetCount(string spriteName)
        {
            for (var index = 0; index < subTargetContainers.Length; index++)
            {
                var item = subTargetContainers[index];
                if (item.extraObject.name == spriteName)
                    return item.GetCount();
            }

            return CountTarget();
        }
    }
}