/**
 * @file    SingletonMonoBehaviour.cs
 * @brief   シングルトンクラス
 * @date    2021/01/29
 */

using UnityEngine;

namespace MKTSingleton
{
    public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    // 1.探す
                    var t = typeof(T);
                    instance = (T)FindObjectOfType(t);

                    // 2.なければ作る
                    if (instance == null) instance = new GameObject(typeof(T).Name).AddComponent<T>();
                }

                return instance;
            }
        }

        public static T getInstance
        {
            get
            {
                if (instance) return instance;

                var t = typeof(T);
                instance = (T)FindObjectOfType(t);

                return instance;
            }
        }

        public static bool HasInstance => instance != null;

        protected virtual void Awake()
        {
            // 他のゲームオブジェクトにアタッチされているか調べる
            // アタッチされている場合は破棄する。
            CheckInstance();
        }

        private void OnDestroy()
        {
            instance = null;
        }

        protected bool CheckInstance()
        {
            if (instance == null)
            {
                instance = this as T;
                return true;
            }

            if (Instance == this)
            {
                return true;
            }

            Destroy(this);
            return false;
        }
    }
}