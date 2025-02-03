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

namespace SweetSugar.Scripts.GUI
{
    /// <summary>
    /// Tutorial popup from the settings info button
    /// </summary>
    public class Tutorial : MonoBehaviour
    {
        public GameObject[] tutorials;
        int i;

        private void OnEnable()
        {
            foreach (var item in tutorials)
            {
                item.SetActive(false);
            }
            SetTutorial();
        }

        public void Next()
        {
            tutorials[i].SetActive(false);
            i++;
            i = Mathf.Clamp(i, 0, tutorials.Length - 1);
            SetTutorial();
        }
        public void Back()
        {
            tutorials[i].SetActive(false);
            i--;
            i = Mathf.Clamp(i, 0, tutorials.Length - 1);
            SetTutorial();
        }

        void SetTutorial()
        {
            tutorials[i].SetActive(true);
        }
    }
}
