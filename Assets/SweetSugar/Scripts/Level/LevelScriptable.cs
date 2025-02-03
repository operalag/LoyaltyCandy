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
using SweetSugar.Scripts.Core;
using SweetSugar.Scripts.TargetScripts.TargetSystem;
using UnityEngine;

namespace SweetSugar.Scripts.Level
{
    public class LevelScriptable : ScriptableObject
    {
        public List<LevelData> levels = new List<LevelData>();

        [Serializable]
        public class LevelKeeper
        {
            public int levelNum;
            public List<FieldData> fields = new List<FieldData>();
            [SerializeField]        public TargetContainer target;
            [SerializeField]        public Target targetObject;
            public LIMIT limitType;
            public int limit = 25;
            public int colorLimit = 5;
            public int star1 = 100;
            public int star2 = 300;
            public int star3 = 500;
            public bool enableMarmalade;
            public int maxRows;
            public int maxCols;
            public int currentSublevelIndex;
            public List<SubTargetContainer> subTargetsContainers = new List<SubTargetContainer>();


        }
    }
}