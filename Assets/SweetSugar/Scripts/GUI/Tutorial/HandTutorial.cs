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

using System.Collections;
using SweetSugar.Scripts.Core;
using SweetSugar.Scripts.Items;
using UnityEngine;

namespace SweetSugar.Scripts.GUI
{
    public class HandTutorial : MonoBehaviour
    {
        public TutorialManager tutorialManager;
        private Item tipItem;
        private Vector3 vDirection;

        void OnEnable()
        {
            tipItem = AI.THIS.TipItem;
            tipItem.tutorialUsableItem = true;
            LevelManager.THIS.tutorialTime = true;
            vDirection = AI.THIS.vDirection;
            PrepareAnimateHand();
        }

        void PrepareAnimateHand()
        {
            var positions = tutorialManager.GetItemsPositions();
            StartCoroutine(AnimateHand(positions));
        }

        IEnumerator AnimateHand(Vector3[] positions)
        {
            float speed = 1;
            var posNum = 0;

            //		for (int i = 0; i < 2; i++) {
            /*var i = 0;
        if (AI.THIS.currentCombineType == CombineType.VShape)
            i = 1;*/
            transform.position = tipItem.transform.position;
            posNum++;
            var offset = new Vector3(0.5f, -.5f);
            Vector2 startPos = transform.position + offset;
            Vector2 endPos = transform.position + vDirection + offset;
            var distance = Vector3.Distance(startPos, endPos);
            float fracJourney = 0;
            var startTime = Time.time;

            while (fracJourney < 1)
            {
                var distCovered = (Time.time - startTime) * speed;
                fracJourney = distCovered / distance;
                transform.position = Vector2.Lerp(startPos, endPos, fracJourney);
                yield return new WaitForFixedUpdate();
            }
            yield return new WaitForFixedUpdate();
            PrepareAnimateHand();
        }
    }
}
