using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public enum State
    {
        GameStart,
        NowGame,
        EndGame,
        GameClear
    }
    [SerializeField]
    public State m_CurrentState;
    [SerializeField, Header("現在の時間")]
    private float m_CurrentTime;
    [SerializeField, Header("カウントダウンの時間")]
    private float m_CountDownTime;
    [SerializeField]
    private TextMeshProUGUI M_CountDownText;
    [SerializeField]
    private string m_Text;
    [SerializeField]
    private GameObject m_PlayerShot;
    [SerializeField]
    private Animator m_TitleScreenAnimator;
    [SerializeField]
    private GameObject m_Sponer;
    [SerializeField]
    private GameObject m_Player;
    [SerializeField]
    private GameObject m_ClearScreen;
    [SerializeField]
    private float m_Time;
    [SerializeField]
    private bool isReStart;
    public bool isEnd;
    private bool isStart;
    private static readonly float overWaitMaxTime = 3.0f;
    private float overWaitTime = overWaitMaxTime;
    private static readonly float clearWaitMaxTime = 3.0f;
    private float clearWaitTime = clearWaitMaxTime;

    private void Start()
    {
        isEnd = false;
        isStart = false;
        isReStart = false;
        m_CurrentTime = m_CountDownTime;
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
                Manager.BGMManager.Instance.BGMChange("OniBaraiBGM01");

                m_Player.SetActive(false);
                m_Sponer.SetActive(false);
                if(!isStart)
                {
           
                    if (Input.GetButtonDown("Fire1") || Input.anyKeyDown)
                    {
                        m_TitleScreenAnimator.SetBool("isStert", true);
                        Manager.SEManager.Instance.SEPlay("GameStart");
                        Manager.BGMManager.Instance.BGMChange("OniBaraiBGM02");
                        m_CurrentState = State.NowGame;
                        isStart = true;
                    }
                    
                }

                break;
            case State.NowGame:
                m_Sponer.SetActive(true);
                m_Player.SetActive(true);
                m_CurrentTime -= Time.deltaTime;
                if (m_CurrentTime <= 0)
                {
                    m_CurrentTime = 0.0f;
                    m_CurrentState = State.GameClear;
                }
                M_CountDownText.text = m_Text + m_CurrentTime.ToString("F2");//F2で小数点2桁まで表示
                break;
            case State.EndGame:
                Manager.BGMManager.Instance.BGMChange("OniBaraiBGM03UnHappy");
                if (overWaitTime > 0.0f) {
                    overWaitTime -= Time.deltaTime;
                    break;
                }
                if (Input.GetButtonDown("Fire1") || Input.anyKeyDown)
                {
                    m_TitleScreenAnimator.SetBool("isReStart", true);
                   isReStart = true;
                 
                }
                break;
            case State.GameClear:
                Manager.BGMManager.Instance.BGMChange("OniBaraiBGM03Happy");
                m_ClearScreen.SetActive(true);
                m_Player.SetActive(false);
                m_Sponer.SetActive(false);

                if (clearWaitTime > 0.0f) {
                    clearWaitTime -= Time.deltaTime;
                    break;
                }

                if (Input.GetButtonDown("Fire1") || Input.anyKeyDown)
                {
                    m_TitleScreenAnimator.SetBool("isReStart", true);
                    isReStart = true;

                }
                break;
        }
     
    }
}
