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

using SweetSugar.Scripts.MapScripts;
using UnityEngine;

namespace SweetSugar.Scripts.GUI
{
    /// <summary>
    /// Level number handler on the map
    /// </summary>
    public class MapLevelNumber : MonoBehaviour
    {
        private GameObject canvasMap;
        MapLevel mapLevel;
        Transform pin;
        // Use this for initialization
        void OnEnable()
        {
            /*canvasMap = GameObject.Find("WorldCanvas");
            mapLevel = transform.parent.parent.GetComponent<MapLevel>();
            if (transform.parent.gameObject == canvasMap) return;
            int num = mapLevel.Number;
            GetComponent<TextMeshProUGUI>().text = "" + num;
            pin = transform.parent;
            transform.SetParent(canvasMap.transform, true);*/
        }

        // Update is called once per frame
        void Update()
        {
            /*if (mapLevel != null && mapLevel.IsLocked && gameObject.activeSelf) gameObject.SetActive(false);
            else gameObject.SetActive(true);*/
        }

    }
}
