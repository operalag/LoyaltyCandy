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

namespace SweetSugar.Scripts.Items
{
    /// <summary>
    /// Sorting order handler for time bomb
    /// </summary>
    public class BindSortingOrder : UnityEngine.MonoBehaviour
    {
        public SpriteRenderer sourceObject;
        public Canvas destObject;
        public SpriteRenderer destObjectSR;
        public int offset;
        private void Update()
        {
            if(destObject){
            destObject.sortingLayerID = sourceObject.sortingLayerID;
            destObject.sortingOrder = sourceObject.sortingOrder + offset;}
            if(destObjectSR){
            destObjectSR.sortingLayerID = sourceObject.sortingLayerID;
            destObjectSR.sortingOrder = sourceObject.sortingOrder + offset;}
        }
    }
}