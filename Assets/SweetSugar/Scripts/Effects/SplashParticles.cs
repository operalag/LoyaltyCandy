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

namespace SweetSugar.Scripts.Effects
{
    /// <summary>
    /// Simple item explosion effect
    /// </summary>
    [ExecuteInEditMode]
    public class SplashParticles : MonoBehaviour
    {
        float index;
        ParticleSystem ps;
        public GameObject attached;
        public void SetColor(int index_)
        {
            ps = GetComponent<ParticleSystem>();
            index = index_+1;
            var textSheet = ps.textureSheetAnimation;
            textSheet.startFrame = index / 6f;
            ps.Play();
        }

        private void Update()
        {
            if (attached != null)
                transform.position = attached.transform.position;
        }


    }
}
