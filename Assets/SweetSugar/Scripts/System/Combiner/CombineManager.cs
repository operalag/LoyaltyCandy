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
using System.Collections.Generic;
using System.Linq;
using SweetSugar.Scripts.Blocks;
using SweetSugar.Scripts.Core;
using SweetSugar.Scripts.Items;
using SweetSugar.Scripts.Level;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SweetSugar.Scripts.System.Combiner
{
    /// <summary>
    /// Combine manager
    /// </summary>
    public class CombineManager
    {
        //List<Combine> combines = new List<Combine>();
        List<Combine> match3Combines = new List<Combine>();
        List<Combine> tempCombinesPredict = new List<Combine>();

        Dictionary<Item, Combine> dic = new Dictionary<Item, Combine>();
        Dictionary<Item, Combine> dicPredict = new Dictionary<Item, Combine>();

        private ItemsTypes prioritiseItem;
        private int maxCols;
        private int maxRows;
        bool vChecking; //check by vertical
        private BonusItemCombiner bonusItemCombiner;
        public Action<List<Combine>> onCombined;

        public CombineManager()
        {
            bonusItemCombiner = new BonusItemCombiner();
        }

        public List<List<Item>> GetCombinedItems(FieldBoard field, bool setNextItemType = false)
        {
            var combinedItems = new List<List<Item>>();

            var combines = GetCombines(field);
            foreach (var cmb in combines)
            {
                if (cmb.nextType != ItemsTypes.NONE)
                {
                    var item = cmb.items[Random.Range(0, cmb.items.Count)];

                    var draggedItem = LevelManager.THIS.lastDraggedItem;
                    if (draggedItem)
                    {
                        if (draggedItem.color != item.color)
                            draggedItem = LevelManager.THIS.lastSwitchedItem;
                        //check the dragged item found in this combine or not and change this type
                        if (cmb.items.IndexOf(draggedItem) >= 0)
                        {
                            item = draggedItem;
                        }
                    }
                    if (setNextItemType)
                        item.NextType = cmb.nextType;
                }
                if(cmb.items != null && cmb.items.Count > 0)    
                    combinedItems.Add(cmb.items);
            }
            return combinedItems;
        }
    
    
        public  List<Combine>  GetCombines(FieldBoard field,  ItemsTypes _prioritiseItem = ItemsTypes.NONE)
        {
            List<Combine> allFoundCombines;
            return GetCombines(field, out allFoundCombines,_prioritiseItem);
        }

        public List<Combine> GetCombines(FieldBoard field, out List<Combine> allFoundCombines, ItemsTypes _prioritiseItem = ItemsTypes.NONE)
        {
            prioritiseItem = _prioritiseItem;
            maxCols = field.fieldData.maxCols;
            maxRows = field.fieldData.maxRows;
            //combines.Clear();
            match3Combines.Clear();
            tempCombinesPredict.Clear();

            dic.Clear();
            var color = -1;
            var combine = new Combine();

            vChecking = false;
            //Horrizontal searching
            for (var row = 0; row < maxRows; row++)
            {
                color = -1;
                for (var col = 0; col < maxCols; col++)
                {
                    var square = field.GetSquare(col, row);
                    if (IsSquareNotNull(square))
                    {
                        CheckMatches(square.Item, color, ref combine);

                        color = square.Item.color;
                    }
                }
            }
            vChecking = true;
            //Vertical searching
            for (var col = 0; col < maxCols; col++)
            {
                color = -1;
                for (var row = 0; row < maxRows; row++)
                {
                    var square = field.GetSquare(col, row);
                    if (IsSquareNotNull(square) && !square.Item.falling && !square.Item.destroying)
                    {
                        CheckMatches(square.Item, color, ref combine);

                        color = square.Item.color;
                    }
                }
            }
    
            allFoundCombines = match3Combines;
            //		Debug.Log (" test combines detected " + tempCombines.Count);
            return CheckCombines(dic, match3Combines);
        }

        public List<Combine> CheckCombines(Dictionary<Item, Combine> d, List<Combine> foundCombines)
        {
            var combines = new List<Combine>();
            var countedCombines = new List<Combine>();
            prioritiseItem = ItemsTypes.NONE;
            //find and merge cross combines (+)
            foreach (var comb in foundCombines)
            {
                if (foundCombines.Count >= 2)
                {
                    foreach (var item in comb.items)
                    {
                        var newComb = FindCombineInDic(item, d);
                        if (comb != newComb && countedCombines.IndexOf(newComb) < 0 && countedCombines.IndexOf(comb) < 0 && IsCombineMatchThree(newComb))
                        {
                            countedCombines.Add(newComb);
                            countedCombines.Add(comb);
                            var mergedCombine = MergeCombines(comb, newComb);
                            if(mergedCombine.items.Count > 3 && mergedCombine.nextType == ItemsTypes.NONE) continue;
                            combines.Add(mergedCombine);
                            foreach (var item_ in comb.items)
                            {
                                d[item_] = mergedCombine;
                            }
                            foreach (var item_ in newComb.items)
                            {
                                d[item_] = mergedCombine;
                            }

                            break;
                        }
                    }
                }
            }

            //find simple combines (3,4,5) 
            foreach (var comb in foundCombines)
            {
                if (combines.IndexOf(comb) < 0 /*&& IsCombineMatchThree(comb)*/ && countedCombines.IndexOf(comb) < 0 && comb.items.Any())
                {
                    ItemTemplate[] foundBonusCombine;
                    comb.nextType = SetNextItemType(comb, out foundBonusCombine);
                    if (comb.nextType != ItemsTypes.NONE)
                    {
                        comb.items = foundBonusCombine.Where(i => i.item).Select(i => i.itemRef).ToList();
                        combines.Add(comb);
                    }
                    else if (IsCombineMatchThree(comb))
                    {
                        if (comb.hCount > comb.vCount)
                        {
                            var items = comb.items.GroupBy(i => i.square.row).OrderByDescending(i => i.Count()).First().ToList();
                            /*if (comb.nextType == ItemsTypes.NONE) */
                            comb.items = items;
                            if (items.Count < 3) return combines;
                        }

                        else if (comb.hCount < comb.vCount)
                        {
                            var items = comb.items.GroupBy(i => i.square.col).OrderByDescending(i => i.Count()).First().ToList();
                            /*if (comb.nextType == ItemsTypes.NONE)*/
                            comb.items = items;
                            if (items.Count < 3) return combines;
                        }
                        else
                        {
                            var items = comb.items.GroupBy(i => i.square.row).OrderByDescending(i => i.Count()).First().ToList();
                            /*if (comb.nextType == ItemsTypes.NONE)*/
                            comb.items = items;
                            if (items.Count < 3)
                            {
                                items = comb.items.GroupBy(i => i.square.col).OrderByDescending(i => i.Count()).First()
                                    .ToList();
                                /*if (comb.nextType == ItemsTypes.NONE)*/
                                comb.items = items;
                            }

                            if (items.Count < 3) return combines;

                        }

                        combines.Add(comb);
                    }
                }
            }

            // select only one combine from cross combines
            var sameItems = new List<Combine>();
            foreach (var combine in combines.OrderByDescending(i=>i.items.Count))
            {
                var same = sameItems.Find(i => i.items.Intersect(combine.items).Any());
                if (same != null)
                {
                    same.items.AddRange(combine.items);
                    same.items = same.items.Distinct().ToList();
                    same.itemPositions.AddRange(combine.itemPositions);
                    same.itemPositions = same.itemPositions.Distinct().ToList();
                }
                else
                {
                    sameItems.Add(combine);
                }
            }
            if (sameItems.Count > 0)
            {
                onCombined?.Invoke(sameItems);
            }
            return sameItems;
        }

        public List<Combine> FindBonusCombines(FieldBoard field, ItemsTypes itemsTypes=ItemsTypes.NONE)
        {
            return bonusItemCombiner.FindBonusCombine(field, itemsTypes);
        }

        Combine MergeCombines(Combine comb1, Combine comb2)
        {
            var combine = new Combine();
            combine.hCount = comb1.hCount + comb2.hCount - 1;
            combine.vCount = comb1.vCount + comb2.vCount - 1;
            combine.items.AddRange(comb1.items);
            combine.items.AddRange(comb2.items);
            combine.itemPositions.AddRange(combine.items.Select(i=> new Vector2(i.square.col, i.square.row)));
            ItemTemplate[] foundBonusCombine;
            combine.nextType = SetNextItemType(combine, out foundBonusCombine);
            return combine;
        }

        ItemsTypes SetNextItemType(Combine combine, out ItemTemplate[] foundBonusCombine)
        {
            foundBonusCombine = null;
            var itemTemplates = bonusItemCombiner.ConvertCombine(combine);
            return bonusItemCombiner.GetBonusCombine(bonusItemCombiner.SimplifyArray(itemTemplates).matrix.ToArray(), out foundBonusCombine, prioritiseItem);
        }

        public void CheckMatches(Item item, int color, ref Combine combine)
        {
            if(!item.destroying && !item.falling)
            {
                combine = FindCombine(item);
                AddItemToCombine(combine, item, dic, match3Combines);
            }
        }


        void AddItemToCombine(Combine combine, Item item, Dictionary<Item, Combine> d, List<Combine> lCombines)
        {
            combine.AddingItem = item;
            d[item] = d.TryGetValue(item, out Combine combine1) ? MergeCombines(combine1, combine) : combine;

            if (IsCombineMatchThree(combine))
            {
                combine.color = item.color;
                if (lCombines.IndexOf(combine) < 0)
                {
                    lCombines.Add(combine);
                    //				Debug.Log("add " + combine.GetHashCode());
                }
            }
        }

        bool IsCombineMatchThree(Combine combine)
        {
            if (combine.hCount > 2 || combine.vCount > 2)
            {
                return true;
            }
            return false;
        }

        bool IsSquareNotNull(Square square)
        {
            if (square == null)
                return false;
            if (square.Item == null)
                return false;
            return true;
        }

        public Combine FindCombine(Item item)
        {
            Combine combine = null;
            var leftItem = item.GetLeftItem();
            if (CheckColor(item, leftItem) && !vChecking)
                combine = FindCombineInDic(leftItem, dic);
            if (combine != null)
                return combine;
            var topItem = item.GetTopItem();
            if (CheckColor(item, topItem) && vChecking)
                combine = FindCombineInDic(topItem, dic);
            if (combine != null)
                return combine;

            return new Combine();
        }

        Combine FindCombineInDic(Item item, Dictionary<Item, Combine> d)
        {
            Combine combine;
            if (d.TryGetValue(item, out combine))
            {
                return combine;
            }
            return new Combine();
        }

        bool CheckColor(Item item, Item nextItem)
        {
            if (nextItem && nextItem.Combinable && item.Combinable)
            {
                if (nextItem.color == item.color && nextItem.currentType != ItemsTypes.MULTICOLOR && nextItem.currentType != ItemsTypes.INGREDIENT)
                    return true;
            }
            return false;
        }

    
    }
    [Serializable]
    public class Combine
    {
        private Item addingItem;
        public List<Item> items = new List<Item>();
        public List<Vector2> itemPositions = new List<Vector2>();
        public int vCount;
        public int hCount;
        Vector2 latestItemPositionH = new Vector2(-1, -1);
        Vector2 latestItemPositionV = new Vector2(-1, -1);
        public int color;
        public ItemsTypes nextType;
        public Item triggerItem;
        public Vector2 dir;
        public Item mainSearchItem;

        public Item AddingItem
        {
            get
            {
                return addingItem;
            }

            set
            {
                addingItem = value;
                color = addingItem.color;
                if (CompareColumns(addingItem))
                {
                    if ((int)latestItemPositionH.y != addingItem.square.row && latestItemPositionH.y > -1)
                        hCount = 0;
                    hCount++;
                    latestItemPositionH = new Vector2(addingItem.square.col, addingItem.square.row);

                }
                else if (CompareRows(addingItem))
                {
                    if ((int)latestItemPositionV.x != addingItem.square.col && latestItemPositionV.x > -1)
                        vCount = 0;
                    vCount++;
                    latestItemPositionV = new Vector2(addingItem.square.col, addingItem.square.row);

                }
                if (hCount > 0 && vCount == 0)
                {
                    vCount = 1;
                }
                items.Add(addingItem);
                itemPositions.Add(new Vector2(addingItem.square.col, addingItem.square.row));
                //			Debug.Log(" c: " + addingItem.square.col + " r: " + addingItem.square.row + " h: " + hCount + " v: " + vCount + " color: " + addingItem.color + " code: " + GetHashCode() + " " + addingItem);
            }

        }

        public void CorrectCombine()
        {
            hCount = items.GroupBy(i => i.square.col).Count();
            vCount = items.GroupBy(i => i.square.row).Count();
            if (hCount == vCount && hCount > 0)
            {
                hCount = items.GroupBy(i => i.square.row).Max(i => i.Count());
                vCount = items.GroupBy(i => i.square.col).Max(i => i.Count());
            }
        }

        public int GetHorizontalCombinedCount()
        {
            return items.GroupBy(i => i.square.row).Select(i => new { Count = i.Count(), Item = i }).Max(i => i.Count);
        }

        bool CompareRows(Item item)
        {
            if (items.Count > 0)
            {
                if (item.square.row != PreviousItem().square.row)
                    return true;
            }
            else
                return true;

            return false;
        }

        bool CompareColumns(Item item)
        {
            if (items.Count > 0)
            {
                if (item.square.col != PreviousItem().square.col)
                    return true;
            }
            else
                return true;

            return false;
        }


        Item PreviousItem()
        {
            return items[items.Count - 1];
        }

        public Combine ConvertToCombine(List<Item> list)
        {
            if(list==null) return this;
            foreach (var item in list)
            {
                AddingItem = item;
            }

            CorrectCombine();
            return this;
        }
    }
}