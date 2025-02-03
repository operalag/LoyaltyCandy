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
using System.Collections.Generic;
using System.Linq;
using SweetSugar.Scripts.Core;
using UnityEngine;

namespace SweetSugar.Scripts.Items
{
    /// <summary>
    /// Destroy processing. Delayed destroying items from array
    /// </summary>
    public class DestroyingPipeline : MonoBehaviour
    {
        public static DestroyingPipeline THIS;
        public List<DestroyBunch> pipeline = new List<DestroyBunch>();

        private void Start()
        {
            if (THIS == null)
                THIS = this;
            else if (THIS != this)
                Destroy(gameObject);

            StartCoroutine(DestroyingPipelineCor());
        }

        public void DestroyItems(List<Item> items, Delays delays, Action callback)
        {
            if (LevelManager.THIS.DebugSettings.DestroyLog)
            {
                foreach (var item in items)
                {
                    DebugLogKeeper.Log("Add to pipeline " + item, DebugLogKeeper.LogType.Destroying);

                }
            }
            var bunch = new DestroyBunch();
            bunch.items = items.ToList();
            bunch.callback = callback;
            bunch.delays = delays;
            pipeline.Add(bunch);
        }

        private IEnumerator DestroyingPipelineCor()
        {
            while (true)
            {
                for (var i = 0; i < pipeline.Count; i++)
                {
                    var bunch = pipeline[i];
                    if (bunch.items.Any())
                        LevelManager.THIS.levelData.GetTargetObject().CheckSquares(bunch.items.Where(i=>i!=null && i.square!=null).Select(x => x.square.GetSubSquare()).ToArray());

                    if (bunch.delays.before != null)
                        yield return bunch.delays.before;
                    for (var j = 0; j < bunch.items.Count; j++)
                    {
                        var item = bunch.items[j];
                        if (bunch.delays.beforeevery != null)
                            yield return Activator.CreateInstance(bunch.delays.beforeevery.GetType());
                        if (item != null)
                        {
                            item.combinationID = bunch.GetHashCode();
                            item.DestroyItem(true);
                        }
                        if (bunch.delays.afterevery != null)
                        {
                            yield return Activator.CreateInstance(bunch.delays.afterevery.GetType());
                        }
                    }
                    if (bunch.delays.after != null)
                        yield return bunch.delays.after;
                    pipeline.Remove(bunch);
                    if (bunch.callback != null)
                        bunch.callback();
                }
                yield return new WaitForFixedUpdate();

            }
        }

    }

    public class DestroyBunch
    {
        public List<Item> items;
        public Action callback;
        public Delays delays;
    }

    public struct Delays
    {
        public CustomYieldInstruction before, beforeevery, afterevery, after;

    }
}