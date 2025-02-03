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
using Malee;
using SweetSugar.Scripts.Localization;
using SweetSugar.Scripts.TargetScripts.TargetEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace SweetSugar.Scripts.TargetScripts.TargetSystem
{
    /// <summary>
    /// target container keeps the object should be collected, its count, sprite, color
    /// </summary>
    [Serializable]
    public class TargetContainer
    {
        public string name = "";

        public LocalizationIndexFolder localization;
        public CollectingTypes collectAction;
        public SetCount setCount;
        [Tooltip("Can switch sublevel if target not complete")]
        public bool CanSwithSublevel;
        [Reorderable]
        public SprArrays defaultSprites;
        public List<GameObject> prefabs = new List<GameObject>();
        public TargetContainer DeepCopy()
        {
            var other = (TargetContainer) MemberwiseClone();

            return other;
        }

        public string GetDescription()
        {
            return LocalizationManager.GetText(localization.description.index, localization.description.text);
        }

        public string GetFailedDescription()
        {
            return LocalizationManager.GetText(localization.failed.index, localization.failed.text);
        }
    }

    [Serializable]
    public class LocalizationIndexFolder
    {
        [Tooltip("Default text")]
        public LocalizationIndex description;
        public LocalizationIndex failed;
    }
    
    public enum CollectingTypes
    {
        Destroy,
        ReachBottom,
        Spread,
        Clear
    }

    public enum SetCount
    {
        Manually,
        FromLevel
    }

    [Serializable]
    public class SprArrays : ReorderableArray<SprArray>
    {
    }
    
    [Serializable]
    public class SprArray
    {
        [FormerlySerializedAs("sprites0")] [Reorderable]
        public SpriteList sprites;

        public SprArray Clone()
        {
            return (SprArray)MemberwiseClone();
        }
    }
}