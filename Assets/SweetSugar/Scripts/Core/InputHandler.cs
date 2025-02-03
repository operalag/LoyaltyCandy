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

using SweetSugar.Scripts.System;
using UnityEngine;

namespace SweetSugar.Scripts.Core
{
    public class InputHandler : Singleton<InputHandler>
    {
        private Vector2 mousePos;
        private Vector2 _delta;
        private bool down;
        private Camera _camera;

        public delegate void MouseEvents(Vector2 pos);

        public static event MouseEvents OnDown, OnMove, OnUp, OnDownRight;

        private void Start()
        {
            _camera = Camera.main;
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                MouseDown(GetMouseWorldPos());
                down = true;
            }
            if (Input.GetMouseButtonUp(0))
            {
                MouseUp(GetMouseWorldPos());
                down = false;
            }
            if (Input.GetMouseButtonDown(1))
                MouseDownRight(GetMouseWorldPos());
            if (Input.GetMouseButton(0) && down)
            {
                MouseMove(GetMouseWorldPos());
            }
        }

        private Vector3 GetMouseWorldPos()
        {
            return _camera.ScreenToWorldPoint(Input.mousePosition);
        }

        public void MouseDown(Vector2 pos)
        {
            mousePos = pos;
            OnDown?.Invoke(mousePos);
        }
        
        public void MouseUp(Vector2 pos)
        {
            mousePos = pos;
            OnUp?.Invoke(mousePos);
        }

        public void MouseMove(Vector2 pos)
        {
            _delta = mousePos - pos;
            mousePos = pos;
            OnMove?.Invoke(mousePos);
        }
        
        public void MouseDownRight(Vector2 pos)
        {
            mousePos = pos;
            OnDownRight?.Invoke(mousePos);
        }

        public Vector2 GetMousePosition() => mousePos;
        public Vector2 GetMouseDelta() => _delta;
    }
}