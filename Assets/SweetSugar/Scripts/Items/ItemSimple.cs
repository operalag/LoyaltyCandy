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
using System.Linq;
using SweetSugar.Scripts.Core;
using UnityEngine;

namespace SweetSugar.Scripts.Items
{
    /// <summary>
    /// Simple item
    /// </summary>
    public class ItemSimple : Item, IItemInterface
    {
        public bool ActivateByExplosion;
        public bool StaticOnStart;

        public void Destroy(Item item1, Item item2)
        {
            GetParentItem().square.DestroyBlock();
            item1.DestroyBehaviour();
        }

        public override void Check(Item item1, Item item2)
        {
            if (item2.currentType != ItemsTypes.NONE)
                item2.Check(item2, item1);

        }

        public Item GetParentItem()
        {
            return transform.GetComponentInParent<Item>();
        }

        public GameObject GetGameobject()
        {
            return gameObject;
        }
        public bool IsCombinable()
        {
            return Combinable;
        }
        public bool IsExplodable()
        {
            return ActivateByExplosion;
        }
        public void SetExplodable(bool setExplodable)
        {
            ActivateByExplosion = setExplodable;
        }

        public bool IsStaticOnStart()
        {
            if (LevelManager.THIS.gameStatus != GameState.Playing)
                return StaticOnStart;
            return false;
        }

        public void SetOrder(int i)
        {
            var spriteRenderers = GetSpriteRenderers();
            var orderedEnumerable = spriteRenderers.OrderBy(x => x.sortingOrder).ToArray();
            for (int index = 0; index < orderedEnumerable.Length; index++)
            {
                var spr = orderedEnumerable[index];
                spr.sortingOrder = i + index;
            }
        }

        public void SecondPartDestroyAnimation(Action callback)
        {
            throw new NotImplementedException();
        }
    }
}