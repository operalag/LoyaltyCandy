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
using SweetSugar.Scripts.Blocks;
using SweetSugar.Scripts.Core;
using SweetSugar.Scripts.Items._Interfaces;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SweetSugar.Scripts.System
{
    /// <summary>
    /// Blocks and ingredients animation, fly up to GUI
    /// </summary>
    public class AnimateItems : MonoBehaviour
    {
        public GameObject linkObject;
        public int linkObjectHash;
        public bool target;
        public void InitAnimation(GameObject obj, Vector2 pos, Vector2 scale, Action callBack, Sprite sprite=null)
        {
            // item = CopyComp.Copy(obj.GetComponent<ISpriteRenderer>().GetSpriteRenderer(), item);
            var colorableComponent = obj.GetComponent<IColorableComponent>();
            SpriteRenderer spr = null;
            if(!sprite)
            {
                if (!colorableComponent) spr = obj.GetComponent<SpriteRenderer>();
                else spr = obj.GetComponent<IColorableComponent>().directSpriteRenderer;
                if (spr == null) spr = obj.GetComponentInChildren<SpriteRenderer>(); 
                sprite = spr.sprite;
            }
            var sprRenderer = gameObject.AddComponent<SpriteRenderer>();
            sprRenderer.sprite = sprite;
            sprRenderer.sortingLayerName = "UI";
            sprRenderer.sortingOrder = 10;
            gameObject.transform.position = obj.transform.position;
            gameObject.transform.localScale = scale;
            StartCoroutine(StartAnimateIngredient(gameObject, pos, () => { if (callBack != null) callBack(); }));
        }

        void OnFinish(GameObject item)
        {
            LevelManager.Destroy(item);
        }

        IEnumerator StartAnimateIngredient(GameObject item, Vector2 pos, Action callBack)
        {
            var curveX = new AnimationCurve(new Keyframe(0, item.transform.localPosition.x), new Keyframe(0.4f, pos.x));
            var curveY = new AnimationCurve(new Keyframe(0, item.transform.localPosition.y), new Keyframe(0.5f, pos.y));
            curveY.AddKey(0.2f, item.transform.localPosition.y + Random.Range(-2, 0.5f));
            var startTime = Time.time;
            var speed = Random.Range(0.4f, 0.6f);
            float distCovered = 0;
            var startScale = item.transform.localScale;
            if (linkObject != null && linkObject.GetComponent<Square>()?.sizeInSquares.magnitude >= 2) startScale /= 2;
            while (distCovered < 0.5f)
            {
                distCovered = (Time.time - startTime) * speed;
                item.transform.localPosition = new Vector3(curveX.Evaluate(distCovered), curveY.Evaluate(distCovered), 0);
                item.transform.Rotate(Vector3.back, Time.deltaTime * 1000);
                item.transform.localScale = Vector3.Lerp(startScale, startScale / 2f, distCovered*2);
                yield return new WaitForFixedUpdate();
            }
            //     SoundBase.Instance.audio.PlayOneShot(SoundBase.Instance.getStarIngr);
            LevelManager.Destroy(item);
            if (callBack != null)
                callBack();
            LevelManager.THIS.animateItems.Remove(this);
            Destroy(gameObject);

        }
    }
}