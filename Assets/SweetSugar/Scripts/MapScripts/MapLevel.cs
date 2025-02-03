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

using SweetSugar.Scripts.GUI;
using SweetSugar.Scripts.System;
using UnityEngine;

namespace SweetSugar.Scripts.MapScripts
{
    public class MapLevel : MonoBehaviour
    {
        private Vector3 _originalScale;
        private bool _isScaled;
        public float OverScale = 1.05f;
        public float ClickScale = 0.95f;

        public int Number;
        public bool IsLocked;
        public Transform Lock;
        public Transform PathPivot;
        public Object LevelScene;
        public string SceneName;

        public int StarsCount;
        public Transform StarsHoster;
        public Transform Star1;
        public Transform Star2;
        public Transform Star3;

        public Transform SolidStarsHoster;
        public Transform SolidStars0;
        public Transform SolidStars1;
        public Transform SolidStars2;
        public Transform SolidStars3;
        public GameObject idleEffect;

        public void Awake()
        {
            _originalScale = transform.localScale;
        }

        #region Enable click

        public void OnMouseEnter()
        {
            if (LevelsMap.GetIsClickEnabled())
                Scale(OverScale);
        }

        public void OnMouseDown()
        {
            if (LevelsMap.GetIsClickEnabled())
                Scale(ClickScale);
        }

        public void OnMouseExit()
        {
            if (LevelsMap.GetIsClickEnabled())
                ResetScale();
        }

        private void Scale(float scaleValue)
        {
            transform.localScale = _originalScale * scaleValue;
            _isScaled = true;
        }

        public void OnDisable()
        {
            if (LevelsMap.GetIsClickEnabled())
                ResetScale();
        }

        public void OnMouseUpAsButton()
        {
            if (LevelsMap.GetIsClickEnabled())
            {
                ResetScale();
                LevelsMap.OnLevelSelected(Number);
            }
        }

        private void ResetScale()
        {
            if (_isScaled)
                transform.localScale = _originalScale;
        }

        #endregion

        public void UpdateState(int starsCount, bool isLocked)
        {
            StarsCount = starsCount;
            UpdateStars(isLocked ? 0 : starsCount);
            IsLocked = isLocked;
            Lock.gameObject.SetActive(isLocked);
        }

        public void UpdateStars(int starsCount)
        {
            Star1?.gameObject.SetActive(starsCount >= 1);
            Star2?.gameObject.SetActive(starsCount >= 2);
            Star3?.gameObject.SetActive(starsCount >= 3);

            /*SolidStars0?.gameObject.SetActive(starsCount == 0);
            SolidStars1?.gameObject.SetActive(starsCount == 1);
            SolidStars2?.gameObject.SetActive(starsCount == 2);
            SolidStars3?.gameObject.SetActive(starsCount == 3);*/
        }

        public void UpdateStarsType(StarsType starsType)
        {
            StarsHoster.gameObject.SetActive(starsType == StarsType.Separated);
            //SolidStarsHoster.gameObject.SetActive(starsType == StarsType.Solid);
        }
        public void SetEffect()
        {
            FindObjectsOfType<IdleCircleMapEffect>().ForEachY(x=>Destroy(x.gameObject));
            var i = Instantiate(idleEffect, transform.position, Quaternion.identity, transform);
            i.transform.localScale = new Vector3(1.24f,1,1);
        }
    }
}
