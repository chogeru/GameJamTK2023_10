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
            Manager.ParticleManager.Instance.ParticlePlay("EnemyHitEfffect", transform.position, Quaternion.identity, 0.4f);
            Manager.ParticleManager.Instance.ParticlePlay("MKTEffect/赤白いヒットエフェクト", transform.position, Quaternion.identity, 0.4f);
            EnemyMove enemyMove = other.gameObject.GetComponent<EnemyMove>();
            if (enemyMove != null)
            {
                enemyMove.TakeDamage(m_Damage);
            }
            Destroy(gameObject);
        }
    }
}
