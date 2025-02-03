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
using System.Linq;
using SweetSugar.Scripts.Items;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;

namespace SweetSugar.Scripts.Effects
{
    /// <summary>
    /// Teleport effect
    /// </summary>
    public class TeleportDirector : MonoBehaviour
    {
        public PlayableDirector director;
        public TimelineAsset timelineStartTeleport;
        public float endKey = 0.22f;
        public GameObject teleportEvent;
        private TrackAsset key;
        public GameObject mask;
        public Sprite[] sprites;
        private double _directorDuration;

        // Use this for initialization
        void OnEnable()
        {
            _directorDuration = director.duration;
            var tracks = timelineStartTeleport.GetOutputTracks();
            key = tracks.First(x => x.name == "Item");
        }

        public void SetTeleport(bool enter)
        {
            if (enter) gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
            else gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];

        }

        public void EnableMask(bool enable)
        {
            mask.SetActive(enable);
        }

        public void StartTeleport(Item item, Action callback)
        {
            // director.SetGenericBinding(key, item.itemAnimTransform.gameObject);
            // if (item.itemAnimTransform.gameObject.GetComponent<Animator>() == null)
            //     item.itemAnimTransform.gameObject.AddComponent<Animator>();
            // item.anim.enabled = false;
            // teleportEvent.SetActive(true);
            director.Play();
            StartCoroutine(Wait(item, callback));
        }

        IEnumerator Wait(Item item, Action callback)
        {
            yield return new WaitUntil(() => director.time >= endKey);
            if (item?.anim != null)
                item.anim.enabled = true;
            if (callback != null) callback();
            yield return new WaitUntil(() => director.time >= _directorDuration || director.time == 0);
            // teleportEvent.SetActive(false);
        }
    }
}
