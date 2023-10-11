using System;
using System.Collections;
using UnityEngine;

namespace TDS.Utility
{
    public static class CoroutineExtensions
    {
        #region Public methods

        public static IEnumerator StartFrameTimer(this MonoBehaviour mono, int numberOfFrames, Action callback)
        {
            IEnumerator timer = mono.CreateFrameTimer(numberOfFrames, callback);
            mono.StartCoroutine(timer);

            return timer;
        }

        public static IEnumerator StartTimer(this MonoBehaviour mono, float time, Action callback)
        {
            IEnumerator timer = mono.CreateTimer(time, callback);
            mono.StartCoroutine(timer);

            return timer;
        }

        #endregion

        #region Private methods

        private static IEnumerator CreateFrameTimer(this MonoBehaviour mono, int numberOfFrames, Action callback)
        {
            for (int i = 0; i < numberOfFrames; i++)
            {
                yield return null;
            }
            callback?.Invoke();
        }

        private static IEnumerator CreateTimer(this MonoBehaviour mono, float time, Action callback)
        {
            yield return new WaitForSeconds(time);
            callback?.Invoke();
        }

        #endregion
    }
}