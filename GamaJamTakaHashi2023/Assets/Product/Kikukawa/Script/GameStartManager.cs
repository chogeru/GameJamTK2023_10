/**
 * @file    GameStartManager.cs
 * @brief   �Q�[���X�^�[�g���̊Ǘ��N���X
 * @date    2023/08/06
 */
using MKTSingleton;
using UnityEngine;

namespace Kikukawa {
    public class GameStartManager : SingletonMonoBehaviour<GameStartManager> {
        void Start() {
            Manager.BGMManager.Instance.FadeBGMChange("OniBaraiBGM01");
            Manager.SEManager.Instance.SEPlay("10Combo");
            Manager.FadeManager.Instance.SetFadeColor(new Color(0.0f, 0.0f, 0.0f, 1.0f));
            Manager.FadeManager.Instance.SetFadeFlag(false);
        }
    }
}