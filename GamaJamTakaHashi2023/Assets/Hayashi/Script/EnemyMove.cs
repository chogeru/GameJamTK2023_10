using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    enum Type
    {
        Oni,
        Kami,
        fakeKami,
    }
    [SerializeField]
    private float m_MySpeed;
    [SerializeField]
    private int m_MyHP;
    [SerializeField]
    private int m_Attack;
    [SerializeField]
    private int m_ScorePoint;
    [SerializeField]
    private int m_ScoreDownPoint;

    private GameObject m_ScoreText;
    private GameObject m_Manager;
    [SerializeField]
    private Transform m_TargetPoint;
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    EnemyState enemyState;
    Score score;
    EnemySpown enemySpown;
    SpownManager spownManager;
    [SerializeField]
    private Type m_CurrentType;
    void Start()
    {

        m_TargetPoint = GameObject.FindGameObjectWithTag("Player").transform;
        m_Manager = GameObject.Find("SpownManager");
        m_ScoreText = GameObject.Find("ScoreText");
        spownManager = m_Manager.GetComponent<SpownManager>();
        score = m_ScoreText.GetComponent<Score>();
    }

    void Update()
    {
        if (m_TargetPoint != null)
        {
            Vector3 direction = (m_TargetPoint.position - transform.position).normalized;
            Vector3 targetVelocity = direction * m_MySpeed;
            rb.velocity = Vector3.ClampMagnitude(targetVelocity, m_MySpeed);
            if (m_MyHP <= 0)
            {
                Die();
            }
        }
    }
    public void TakeDamage(int damage)
    {
        m_MyHP -= damage;
    }
    private void Die()
    {
        switch (m_CurrentType)
        {
            case Type.Oni:
                spownManager.m_BonusCount++;
                break;
            case Type.Kami:
                score.m_Score -= m_ScoreDownPoint;
                break;
            case Type.fakeKami:
                score.m_Score += m_ScorePoint;
                break;
        }

        Manager.SEManager.Instance.SEPlay("EnemyDestroy");
        Destroy(gameObject);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Manager.ParticleManager.Instance.ParticlePlay("HitEfffect", transform.position, Quaternion.identity, 1f);
            switch (m_CurrentType)
            {
                case Type.Oni:
                    Player player = collision.gameObject.GetComponent<Player>();
                    if (player != null)
                    {
                        Manager.SEManager.Instance.SEPlay("CollisionHouse");
                        player.TakePlayerDamage(m_Attack);
                    }
                    break;
                case Type.Kami:
                    score.m_Score += m_ScorePoint;
                    Manager.SEManager.Instance.SEPlay("CollisionKami");
                    break;
                case Type.fakeKami:
                    score.m_Score -= m_ScorePoint;
                    Manager.SEManager.Instance.SEPlay("CollisionDammyKami");
                    break;
            }


            Destroy(gameObject);
        }
    }
}
