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
using System.Collections;
using System.Linq;
using SweetSugar.Scripts.Blocks;
using SweetSugar.Scripts.Core;
using SweetSugar.Scripts.System;
using UnityEngine;

namespace SweetSugar.Scripts.Items
{
    /// <summary>
    /// Item marmalade
    /// </summary>
    public class ItemMarmalade : Item, IItemInterface
    {
        // public bool Combinable;
        public bool ActivateByExplosion;
        public bool StaticOnStart;
        public bool noMarmaladeLaunch;
        public ItemMarmalade secondItem;
        public MarmaladeFly[] marmalades;
        private bool destroyStarted;

        public void Destroy(Item item1, Item item2)
        {
            if (GetParentItem().square?.type == SquareTypes.WireBlock)
            {
                GetParentItem().square.DestroyBlock();
                return;
            }

            item1.destroying = true;
            var switchItemType = item2?.currentType ?? ItemsTypes.NONE;
            if(!noMarmaladeLaunch && !destroyStarted)
            {
                destroyStarted = true;
                CreateMarmaladeWithType(switchItemType);
            }
            if (switchItemType == ItemsTypes.MARMALADE)
                item2?.GetTopItemInterface()?.Destroy(item2, null);
            else if (switchItemType != ItemsTypes.NONE && (item2?.Combinable ?? false))
                item2?.DestroyItem();
            else if( switchItemType == ItemsTypes.MULTICOLOR)
                item2?.DestroyBehaviour();
            else if(noMarmaladeLaunch) DestroyBehaviour();
            GetParentItem().square?.DestroyBlock();
        }

        private void DestroySecond(Item item1, Item item2)
        {
            secondItem?.DestroySecond(item1, item2);
            var switchItemType = item2?.currentType ?? ItemsTypes.NONE;
            if(!noMarmaladeLaunch)
            {
                CreateMarmaladeWithType(switchItemType);
            }
        }

        private void CreateMarmaladeWithType(ItemsTypes itemsType)
        {
            CreateMarmalade(itemsType);
 
        }

        private void CreateMarmalade(ItemsTypes itemsType)
        {
            foreach (var marmalade in marmalades)
            {
                marmalade.targets = GetParentItem().itemForEditor.TargetMarmaladePositions;
                if (itemsType != ItemsTypes.MARMALADE && itemsType != ItemsTypes.MULTICOLOR && itemsType != ItemsTypes.INGREDIENT)
                    marmalade.nextItemType = itemsType;
                if (GetParentItem().square?.type == SquareTypes.JellyBlock || LevelManager.THIS.lastSwitchedItem?.square?.type == SquareTypes.JellyBlock)
                    marmalade.setJelly = true;
                if (UnityEngine.Random.value>=0.5f)
                    marmalade.SetDirection(Vector2.left);
                else
                    marmalade.SetDirection(Vector2.right);
                marmalade.StartFly();
            }

            StartCoroutine(WaitForReachTarget());
        }

        IEnumerator WaitForReachTarget()
        {
            yield return new WaitWhile(()=>marmalades.Any(i=>i.gameObject.activeSelf));
            DestroyBehaviour();
        }

        private void OnDisable()
        {
            if(square?.Item == this && LevelManager.THIS.gameStatus != GameState.RegenLevel)
                square.Item = null;
        }

        public override void InitItem()
        {
            destroyStarted = false;
            noMarmaladeLaunch = false;
            marmalades.ForEachY(i => i.gameObject.SetActive(true));
            base.InitItem();
        }

        public override void Check(Item item1, Item item2)
        {
            if (item2.currentType == ItemsTypes.MULTICOLOR)
            {
                item2.Check(item2, item1);
            }
            else if (item2.currentType != ItemsTypes.NONE)
                Destroy(item1, item2);
            
            LevelManager.THIS.FindMatches();
        }

        public Item GetParentItem()
        {
            return GetComponent<Item>();
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
            return StaticOnStart;
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
        
        public void SetCallback(Action callback)
        {
            marmalades.ForEachY(i => i.SecondPartDestroyAnimation( callback));
        }

    }
}
