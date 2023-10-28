using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int m_Hp;
    EnemyMove enemyMove;
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
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
           
        }
    }
}
