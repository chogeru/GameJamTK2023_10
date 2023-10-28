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
    private GameObject m_Sponer;
    [SerializeField]
    private GameObject m_Player;
    public bool isEnd;
    private void Start()
    {
        isEnd = false;
    }
    private void Update()
    {
        if(isEnd)
        {
            m_CurrentState = State.EndGame;
        }
        switch (m_CurrentState)
        {
            case State.GameStart:
                m_Player.SetActive(false);
                m_Sponer.SetActive(false);
                if (Input.GetButtonDown("Fire1") || Input.anyKeyDown)
                {
                    m_CurrentState = State.NowGame;

                }
                break;
            case State.NowGame:
                m_Sponer.SetActive(true);
                m_Player.SetActive(true);
                break;
            case State.EndGame:
                SceneManager.LoadScene("GameScene");
                break;
        }

    }
}
