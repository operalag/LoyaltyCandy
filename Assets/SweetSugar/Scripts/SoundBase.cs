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
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace SweetSugar.Scripts
{
    /// <summary>
    /// Sound manager
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class SoundBase : MonoBehaviour
    {
        public static SoundBase Instance;
        public AudioClip click;
        public AudioClip[] swish;
        public AudioClip[] drop;
        public AudioClip alert;
        public AudioClip timeOut;
        public AudioClip[] star;
        public AudioClip[] gameOver;
        public AudioClip cash;

        public AudioClip[] destroy;
        public AudioClip boostBomb;
        public AudioClip boostColorReplace;
        public AudioClip explosion;
        public AudioClip explosion2;
        public AudioClip getStarIngr;
        public AudioClip strippedExplosion;
        public AudioClip[] complete;
        public AudioClip block_destroy;
        public AudioClip wrongMatch;
        public AudioClip noMatch;
        public AudioClip appearStipedColorBomb;
        public AudioClip appearPackage;
        public AudioClip destroyPackage;
        public AudioClip colorBombExpl;
        private AudioSource _audioSource;
        public AudioMixer audioMixer;
        List<AudioClip> clipsPlaying = new List<AudioClip>();

        ///SoundBase.Instance.audio.PlayOneShot( SoundBase.Instance.kreakWheel );

        // Use this for initialization
        void Awake()
        {

            _audioSource = GetComponent<AudioSource>();
            audioMixer = _audioSource.outputAudioMixerGroup?.audioMixer;
            if (transform.parent == null)
            {
                transform.parent = Camera.main?.transform;
                transform.localPosition = Vector3.zero;
            }
            // DontDestroyOnLoad(gameObject);
            if (Instance == null)
                Instance = this;
            else if (Instance != this)
                Destroy(gameObject);

        }

        private void Start()
        {
            audioMixer?.SetFloat("SoundVolume", PlayerPrefs.GetInt("Sound"));
        }

        public void PlayOneShot(AudioClip audioClip)
        {
            _audioSource.PlayOneShot(audioClip);
        }
    
        public void PlaySoundsRandom(AudioClip[] clip)
        {
            if (clip.Length > 0)
                PlayOneShot(clip[Random.Range(0, clip.Length)]);
        }

        public void PlayLimitSound(AudioClip clip)
        {
            if (clipsPlaying.IndexOf(clip) < 0)
            {
                clipsPlaying.Add(clip);
                PlayOneShot(clip);
                StartCoroutine(WaitForCompleteSound(clip));
            }
        }

        IEnumerator WaitForCompleteSound(AudioClip clip)
        {
            yield return new WaitForSeconds(0.2f);
            clipsPlaying.Remove(clipsPlaying.Find(x => clip));
        }
    }
}
