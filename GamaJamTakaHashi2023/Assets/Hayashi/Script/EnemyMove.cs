using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    private float m_MySpeed;
    [SerializeField]
    private int m_MyHP;
    [SerializeField]
    private int m_Attack;

    [SerializeField]
    private ParticleSystem m_HitEffect;
    [SerializeField]
    private Transform m_TargetPoint;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    EnemyState enemyState;
    void Start()
    {
        m_TargetPoint = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        Vector3 direction = (m_TargetPoint.position - transform.position).normalized;
        Vector3 targetVelocity = direction * m_MySpeed;
        rb.velocity = Vector3.ClampMagnitude(targetVelocity, m_MySpeed);
        if(m_MyHP<=0)
        {
            Die();
        }
    }
    public void TakeDamage(int damage)
    {
        m_MyHP-=damage;
    }
    private void Die()
    {
        Instantiate(m_HitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Instantiate(m_HitEffect, transform.position, Quaternion.identity);
            Player player = collision.gameObject.GetComponent<Player>();
            if(player != null)
            {
                player.TakePlayerDamage(enemyState.Attack);
            }
            Destroy(gameObject);
        }
    }
}
