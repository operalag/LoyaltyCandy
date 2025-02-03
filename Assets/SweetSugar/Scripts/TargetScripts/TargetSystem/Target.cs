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
using SweetSugar.Scripts.Blocks;
using SweetSugar.Scripts.Core;
using SweetSugar.Scripts.Items;
using SweetSugar.Scripts.Level;
using SweetSugar.Scripts.System;
using UnityEngine;

namespace SweetSugar.Scripts.TargetScripts.TargetSystem
{
    /// <summary>
    /// Target object
    /// </summary>
    [Serializable]
    public abstract class Target
    {
        public int amount;
        public int destAmount;
        public SubTargetContainer[] subTargetContainers;

        public string description;

        public abstract int GetDestinationCount();
        public abstract int GetDestinationCountSublevel();

        public abstract void InitTarget(LevelData levelData);

        public abstract int CountTarget();
        public abstract int GetCount(string spriteName);

        public abstract int CountTargetSublevel();

        public abstract void FulfillTarget<T>(T[] items);

        public abstract void DestroyEvent(GameObject obj);

        public delegate void CheckDelegate(GameObject gameObject, Sprite spr);
        
        //public static event CheckDelegate OnCheckTarget;

        public Target()
        {
            TargetComponent.OnDestroyEvent += DestroyEvent;
        }

        public virtual bool IsTargetReachedSublevel()
        {
            return amount <= 0;
        }

        public virtual bool IsTotalTargetReached()
        {
            return amount <= 0;
        }

        public void CheckItems(Item[] items)
        {
            LevelManager.THIS.levelData.TargetCounters.ForEachY(i=>i.CheckTarget(items));
        }

        public void CheckSquare(Square[] squares)
        {
            LevelManager.THIS.levelData.TargetCounters.ForEachY(i=>i.CheckTarget(squares));
        }

        public void CheckSquares(Square[] squares)
        {
             LevelManager.THIS.levelData.TargetCounters.ForEachY(i=>i.CheckTarget(squares));
        }

        public virtual void FulfillTargets<T>(T[] items){}

        public virtual void CheckTargetItemsAfterDestroy() { }

        public virtual bool IsIngredientRequire() { return false; }

        public Target DeepCopy()
        {
            var other = (Target)MemberwiseClone();

            return other;
        }

    }
}