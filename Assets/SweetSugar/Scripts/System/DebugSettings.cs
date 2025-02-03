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

using UnityEngine;

namespace SweetSugar.Scripts.System
{
    public class DebugSettings : ScriptableObject
    {
        public bool BonusCombinesShowLog;
        public bool DestroyLog;
        public bool FallingLog;
        public bool StackTrace;
        public bool ShowLogImmediately;
        [Header("AI testing options")]
        [Tooltip("Enable AI player")]
        public bool AI;
        [Tooltip("Level for testing from the map")]
        public int testLevel;
        [Tooltip("Non-gameplay UI animations speed")]
        [Range(0, 100)] public float TimeScaleUI = 1;
        [Tooltip("Gameplay animations speed")]
        [Range(0, 100)] public float TimeScaleItems = 1;

        [Header("Debug hotkeys")] public bool enableHotkeys = true;
        [Tooltip("press to win")] public KeyCode Win;
        [Tooltip("set moves to 1")] public KeyCode Lose;
        [Tooltip("restart the level")] public KeyCode Restart;
        [Tooltip("switch a sublevel")] public KeyCode SubSwitch;
        [Tooltip("android's back button")] public KeyCode Back;
        [Tooltip("regenerate items")] public KeyCode Regen;

        [Header("")] [Tooltip("Test language, only for editor")]
        public SystemLanguage TestLanguage = SystemLanguage.English;


    }
}