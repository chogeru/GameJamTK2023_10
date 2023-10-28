using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private GameObject m_BulletPrefab;
    [SerializeField]
    private Transform m_ShootPoint;
    [SerializeField]
    private float m_BulletForce = 10f; 

    void Update()
    {
      
        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(m_BulletPrefab, m_ShootPoint.position, m_ShootPoint.rotation);
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

            if (bulletRigidbody != null)
            {
                // ‹…‚ð‚Ü‚Á‚·‚®‘O‚É”­ŽË‚·‚é—Í‚ð‰Á‚¦‚é
                bulletRigidbody.velocity = m_ShootPoint.forward * m_BulletForce;
            }
        }
    }
}
