using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int m_Hp;
    [SerializeField]
    private int m_MaxHp;
    [SerializeField]
    private Slider m_HpSlider;
    EnemyMove enemyMove;
    private void Start()
    {
        m_Hp = m_MaxHp;
        m_HpSlider.value = 1;
    }
    private void Update()
    {
        if(m_Hp<=0)
        {
            Die();
        }
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    public void TakePlayerDamage(int damage)
    {
        m_Hp -= damage;
        m_HpSlider.value = (float)m_Hp / (float)m_MaxHp;
    }
 
}
