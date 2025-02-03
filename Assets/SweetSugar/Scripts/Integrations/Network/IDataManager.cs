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
using System.Collections.Generic;

namespace SweetSugar.Scripts.Integrations.Network
{
	public interface IDataManager {
		void SetPlayerScore (int level, int score);

		void SetPlayerLevel (int level) ;

		void GetPlayerLevel (Action<int> Callback);

		void GetPlayerScore(int level, Action<int> Callback);

		void SetStars (int Stars, int Level);

		void GetStars (Action<Dictionary<string,int>> Callback);

		void SetTotalStars ();

		void SetBoosterData (Dictionary<string, string> dic);

		void GetBoosterData (Action<Dictionary<string,int>> Callback);

		void Logout ();
	}
}


