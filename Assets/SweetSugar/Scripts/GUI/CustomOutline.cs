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

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SweetSugar.Scripts.GUI {

	public class CustomOutline : Shadow {
		[Range (0, 15)]
		public float m_size = 3.0f;

		public bool glintEffect;


		[Range (0, 5)]
		public int glintVertex;
		[Range (0, 3)]
		public int glintWidth;
		public Color glintColor;

		public override void ModifyMesh (VertexHelper vh) {
			if (!IsActive ())
				return;
			var verts = new List<UIVertex> ();

			vh.GetUIVertexStream (verts);

			var neededCpacity = verts.Count * 5;
			if (verts.Capacity < neededCpacity)
				verts.Capacity = neededCpacity;


			if (glintEffect) {
				for (var i = 0; i < verts.Count; i++) {
					var item = verts [i];

					for (var j = -glintWidth; j <= glintWidth; j++) {

						if (i % 6 == Mathf.Repeat (glintVertex + j, 6))
							item.color = glintColor;
					}

					verts [i] = item;
				}
			}

			var m_effectDistance = new Vector2 (m_size, m_size);
			var start = 0;
			var end = verts.Count;
			ApplyShadowZeroAlloc (verts, effectColor, start, verts.Count, m_effectDistance.x, m_effectDistance.y);

			start = end;
			end = verts.Count;
			ApplyShadowZeroAlloc (verts, effectColor, start, verts.Count, m_effectDistance.x, -m_effectDistance.y);

			start = end;
			end = verts.Count;
			ApplyShadowZeroAlloc (verts, effectColor, start, verts.Count, -m_effectDistance.x, m_effectDistance.y);

			start = end;
			end = verts.Count;
			ApplyShadowZeroAlloc (verts, effectColor, start, verts.Count, -m_effectDistance.x, -m_effectDistance.y);

			//////////////////////////////
			start = end;
			end = verts.Count;
			ApplyShadowZeroAlloc (verts, effectColor, start, verts.Count, 0, m_effectDistance.y * 1.5f);

			start = end;
			end = verts.Count;
			ApplyShadowZeroAlloc (verts, effectColor, start, verts.Count, m_effectDistance.x * 1.5f, 0);

			start = end;
			end = verts.Count;
			ApplyShadowZeroAlloc (verts, effectColor, start, verts.Count, -m_effectDistance.x * 1.5f, 0);

			start = end;
			end = verts.Count;
			ApplyShadowZeroAlloc (verts, effectColor, start, verts.Count, 0, -m_effectDistance.y * 1.5f);

			vh.Clear ();
			vh.AddUIVertexTriangleStream (verts);

		}
	
	}
}
