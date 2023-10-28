using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulet : MonoBehaviour
{
    [SerializeField]
    private int m_Damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyMove enemyMove = other.gameObject.GetComponent<EnemyMove>();
            if (enemyMove != null)
            {
                enemyMove.TakeDamage(m_Damage);
            }
            Destroy(gameObject);
        }
    }
}
