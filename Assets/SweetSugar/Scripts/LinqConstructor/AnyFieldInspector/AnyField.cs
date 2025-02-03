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

namespace SweetSugar.Scripts.LinqConstructor.AnyFieldInspector
{
    [Serializable]
    public class AnyField
    {
        public object obj;
        public int index;
        public bool expand;
        public string nameObj;
        public List<AnyField> objectPath = new List<AnyField>();
        public object value;
        public AnyField(object obj_ = null, int index_ = 0, object _value = null)
        {
            obj = obj_;
            index = index_;
            if (obj != null)
                nameObj = obj.ToString();
            value = _value;
        }
    }
}