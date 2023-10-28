using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public enum State
    {
        GameStart,
        NowGame,
        EndGame
    }
    [SerializeField]
    public State m_CurrentState;
    [SerializeField]
    private GameObject m_PlayerShot;
    [SerializeField]
    private Animator m_TitleScreenAnimator;
    [SerializeField]
    private GameObject m_Sponer;
    [SerializeField]
    private GameObject m_Player;
    [SerializeField]
    private float m_Time;
    [SerializeField]
    private bool isReStart;
    public bool isEnd;
    private bool isStart;
    private void Start()
    {
        isEnd = false;
        isStart = false;
        isReStart = false;
    }
    private void Update()
    {
        if(isEnd)
        {
            m_CurrentState = State.EndGame;
        }
        if(isReStart)
        {
            m_Time += Time.deltaTime;
            if (m_Time > 1.2)
            {
                SceneManager.LoadScene("GameScene");
            }
        }
        switch (m_CurrentState)
        {
            case State.GameStart:
                m_Player.SetActive(false);
                m_Sponer.SetActive(false);
                if(!isStart)
                {
                    if (Input.GetButtonDown("Fire1") || Input.anyKeyDown)
                    {
                        m_TitleScreenAnimator.SetBool("isStert", true);
                        Manager.SEManager.Instance.SEPlay("GameStart");
                        /*
                        Manager.BGMManager.Instance.FadeBGMChange("OniBaraiBGM02");
                        Manager.FadeManager.Instance.SetFadeColor(new Color(0.0f, 0.0f, 0.0f, 1.0f));
                        Manager.FadeManager.Instance.SetFadeFlag(false, () =>
                        {
                            m_CurrentState = State.NowGame;
                        });*/
                        m_CurrentState = State.NowGame;
                        isStart = true;
                    }
                    
                }

                break;
            case State.NowGame:
                m_Sponer.SetActive(true);
                m_Player.SetActive(true);
                break;
            case State.EndGame:
                if (Input.GetButtonDown("Fire1") || Input.anyKeyDown)
                {
                    m_TitleScreenAnimator.SetBool("isReStart", true);
                   isReStart = true;
                }
                break;
        }

    }
}
