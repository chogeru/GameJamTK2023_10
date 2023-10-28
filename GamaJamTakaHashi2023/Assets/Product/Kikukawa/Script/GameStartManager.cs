/**
 * @file    GameStartManager.cs
 * @brief   ゲームスタート時の管理クラス
 * @date    2023/08/06
 */
using MKTSingleton;
using UnityEngine;

namespace Kikukawa {
    public class GameStartManager : SingletonMonoBehaviour<GameStartManager> {
        public bool Test = false;

        void Start() {
            Manager.BGMManager.Instance.FadeBGMChange("OniBaraiBGM01");
            Manager.FadeManager.Instance.SetFadeColor(new Color(0.0f, 0.0f, 0.0f, 1.0f));
            Manager.FadeManager.Instance.SetFadeFlag(false);
        }
       void Update() {
            if (Test) {
                Manager.ParticleManager.Instance.ParticlePlay("BigHeart", new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0),Quaternion.identity,2.0f);
                Manager.SEManager.Instance.SEPlay("10Combo");
                Test = false;
            }
        }
    }
}