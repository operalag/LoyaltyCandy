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
using UnityEngine.UI;

namespace SweetSugar.Scripts.GUI
{
    public class Level : MonoBehaviour {
        public int number;
        public Text label;
        public GameObject lockimage;

        // Use this for initialization
        void Start () {
            if( PlayerPrefs.GetInt( "Score" + (number-1) ) > 0  )
            {
                lockimage.gameObject.SetActive( false );
                label.text = "" + number;
            }

            var stars = PlayerPrefs.GetInt( string.Format( "Level.{0:000}.StarsCount", number ), 0 );

            if( stars > 0 )
            {
                for( var i = 1; i <= stars; i++ )
                {
                    transform.Find( "Star" + i ).gameObject.SetActive( true );
                }

            }

        }
	
        // Update is called once per frame
        void Update () {
	
        }

        public void StartLevel()
        {
//        InitScript.Instance.OnLevelClicked(number);

        }
    }
}
