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
using UnityEngine;
using Object = UnityEngine.Object;

namespace SweetSugar.Scripts.TargetScripts.TargetSystem
{
    /// <summary>
    /// target container keeps the object should be collected, its count, sprite, color
    /// </summary>
    [Serializable]
    public class SubTargetContainer
    {
        ///using to keep count of targets
        public GameObject targetPrefab;

        public int count;
        int Savecount;
        public int preCount;
        public Object extraObject;
        public Object[] extraObjects;
        public int color;
        public TargetGUI TargetGui;
        public TargetContainer targetLevel;
        public CollectingTypes collectingAction;

        public SubTargetContainer(GameObject _target, int _count, Object _extraObject)
        {
            targetPrefab = _target;
            count = _count;
            preCount = count;
            extraObject = _extraObject;
        }

        public void changeCount(int i)
        {
            count += i;
            if (count < 0) count = 0;
            preCount = count;
        }

        public int GetCount()
        {
            return count;
        }

        public SubTargetContainer DeepCopy()
        {
            // SubTargetContainer other = (SubTargetContainer)this.MemberwiseClone();
            var other = new SubTargetContainer(targetPrefab, count, extraObject);
            return other;
        }

    }
}