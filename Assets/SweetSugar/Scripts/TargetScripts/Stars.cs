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
using SweetSugar.Scripts.Level;
using SweetSugar.Scripts.TargetScripts.TargetSystem;
using UnityEngine;

namespace SweetSugar.Scripts.TargetScripts
{
    /// <summary>
    /// Stars target
    /// </summary>
    public class Stars : Target
    {
        public override int GetDestinationCountSublevel()
        {
            var count = 0;
            count += LevelData.THIS.star1;
            return count;
        }

        public override int GetDestinationCount()
        {
            var count = 0;
            count += LevelData.THIS.star1;
            return count;
        }
        public override void InitTarget(LevelData levelData)
        {

        }

        public override int CountTarget()
        {
            return GetDestinationCount();
        }

        public override int CountTargetSublevel()
        {
            return GetDestinationCountSublevel();
        }


        public override void FulfillTarget<T>(T[] items)
        {
        }

        public override void DestroyEvent(GameObject obj)
        {
            Debug.Log(obj);
        }

        public override int GetCount(string spriteName)
        {
            return CountTarget();
        }

        public override bool IsTotalTargetReached()
        {
            return LevelManager.Score >= LevelManager.THIS.levelData.star3;
        }

        public override bool IsTargetReachedSublevel()
        {
            return LevelManager.Score >= LevelManager.THIS.levelData.star3;
        }
    }
}