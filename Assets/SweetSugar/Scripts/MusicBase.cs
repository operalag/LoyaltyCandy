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

using SweetSugar.Scripts.Core;
using UnityEngine;
using UnityEngine.Audio;

namespace SweetSugar.Scripts
{
    /// <summary>
    /// Music manager
    /// </summary>
    public class MusicBase : MonoBehaviour
    {

        public static MusicBase Instance;
        public AudioClip[] music;
        private AudioSource audioSource;
        public AudioMixer audioMixer;

        ///MusicBase.Instance.audio.PlayOneShot(MusicBase.Instance.music[0]);


        // Use this for initialization
        void Awake()
        {
     
            audioSource = GetComponent<AudioSource>();
            audioMixer = audioSource.outputAudioMixerGroup.audioMixer;
            audioSource.loop = true;
            if (Instance == null)
                Instance = this;
            else if (Instance != this)
                Destroy(gameObject);
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            audioMixer.SetFloat("MusicVolume", PlayerPrefs.GetInt("Music"));
        }

        private void OnEnable()
        {
            LevelManager.OnMapState += OnMapState;
            LevelManager.OnEnterGame += OnGameState;
        }

        private void OnDisable()
        {
            LevelManager.OnMapState -= OnMapState;
            LevelManager.OnEnterGame -= OnGameState;
        }

        private void OnGameState()
        {
            if (audioSource.clip == music[0])
            {
                audioSource.clip = music[Random.Range(1, 3)];
            }
            if(!audioSource.isPlaying)
                audioSource.Play();
        }

        private void OnMapState()
        {
            if (audioSource.clip != music[0])
            {
                audioSource.clip = music[0];
            }
            if(!audioSource.isPlaying)
                audioSource.Play();
        }

        // Update is called once per frame
        void Update()
        {
        }
    }
}
