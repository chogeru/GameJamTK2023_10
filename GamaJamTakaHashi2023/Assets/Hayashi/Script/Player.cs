using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int m_Hp;
    [SerializeField]
    private int m_MaxHp;
    private float m_AnimeEndTime;
    private bool isEndAnime = false;
    [SerializeField]
    private Animator m_MyAnimator;
    [SerializeField]
    private GameObject m_SceneManager;
    [SerializeField]
    private GameObject m_Spawner;
    [SerializeField]
    private GameObject m_GameOverText;
    [SerializeField]
    private Slider m_HpSlider;
    EnemyMove enemyMove;
    GameManager sceneManager;
    private void Start()
    {
        m_Hp = m_MaxHp;
        m_HpSlider.value = 1;
        sceneManager=m_SceneManager.GetComponent<GameManager>();
        m_GameOverText.SetActive(false);
    }
    private void Update()
    {
        if(m_Hp<=0)
        {
            sceneManager.isEnd = true;
            m_Spawner.SetActive(false);
            m_GameOverText.SetActive(true);
            Die();
        }
        if(isEndAnime)
        {
            m_AnimeEndTime += Time.deltaTime;
            if(m_AnimeEndTime>0.2)
            {
                m_MyAnimator.SetBool("isShake", false);
                m_AnimeEndTime = 0;
            }
        }
    }
    private void Die()
    {
        Manager.SEManager.Instance.SEPlay("se_mero_gameover2_01");
        Destroy(gameObject);
    }
    public void TakePlayerDamage(int damage)
    {
        m_MyAnimator.SetBool("isShake", true);
        isEndAnime=true;
        m_Hp -= damage;
        m_HpSlider.value = (float)m_Hp / (float)m_MaxHp;
    }
 
}
