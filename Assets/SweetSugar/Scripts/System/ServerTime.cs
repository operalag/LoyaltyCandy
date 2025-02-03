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
using System.Collections;
using System.Globalization;
using UnityEngine;
using UnityEngine.Networking;

namespace SweetSugar.Scripts.System
{
    public class ServerTime : UnityEngine.MonoBehaviour
    {
        public static ServerTime THIS;
        public DateTime serverTime;
        public bool dateReceived;
        public bool noConnection;
        public delegate void DateReceived();
        public static event DateReceived OnDateReceived;
        [Header("Test date example: 2019-08-27 09:12:29")]
        public string TestDate;

        private float timePassed;
        private void Awake()
        {
            if (THIS == null)
                THIS = this;
            else if(THIS != this)
                Destroy(gameObject);
            GetServerTime();
            DontDestroyOnLoad(this);
        }

        private void OnEnable()
        {
            GetServerTime();
        }

        void GetServerTime ()
        {
            StartCoroutine(getTime());
        }

        #if UNITY_ANDROID
        void OnApplicationFocus ( bool focus )
        {
            if (focus)
                GetServerTime();
            else
                dateReceived = false;
        }
        #endif

        #if UNITY_EDITOR || UNITY_IOS
        void OnApplicationPause ( bool pause )
        {
            if ( !pause )	                
                GetServerTime();
            else
                dateReceived = false;
        }
        #endif

        IEnumerator getTime()
        {
            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                // No internet connection, use UTC system time
                serverTime = DateTime.UtcNow;
                noConnection = true;
            }
            else
            {
                noConnection = false;
                #if UNITY_WEBGL
                    serverTime = DateTime.UtcNow;
                #else
                UnityWebRequest www = UnityWebRequest.Get("https://worldtimeapi.org/api/timezone/Etc/UTC");
                yield return www.SendWebRequest();

                // Start a coroutine that will abort the request after a timeout
                StartCoroutine(AbortAfterSeconds(www, 5f));

                yield return new WaitUntil(() => www.downloadHandler.isDone || www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError);
                if (www.result is UnityWebRequest.Result.ConnectionError or UnityWebRequest.Result.ProtocolError)
                {
                    // Server error, use UTC system time
                    serverTime = DateTime.UtcNow;
                }
                else if (www.downloadHandler.text != "")
                {
                    TimeResponse timeResponse = JsonUtility.FromJson<TimeResponse>(www.downloadHandler.text);
                    serverTime = DateTime.ParseExact(timeResponse.datetime, "yyyy-MM-ddTHH:mm:ss.ffffffzzz", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);
                }
                else
                    serverTime = DateTime.UtcNow;

                if (TestDate != "" &&
                    (Application.platform == RuntimePlatform.WindowsEditor || Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.LinuxEditor))
                    serverTime = DateTime.Parse(TestDate);
                #endif
                timePassed = 0;
                yield return null;
                dateReceived = true;
                OnDateReceived?.Invoke();
            }
        }

        IEnumerator AbortAfterSeconds(UnityWebRequest www, float seconds)
        {
            yield return new WaitForSeconds(seconds);
            if (!www.isDone)
            {
                www.Abort();
            }
        }

        private void Update()
        {
            timePassed += Time.deltaTime;
            serverTime = serverTime.AddSeconds(Time.deltaTime);
        }
    }
    
    [Serializable]
    public class TimeResponse
    {
        public string datetime;
    }
}