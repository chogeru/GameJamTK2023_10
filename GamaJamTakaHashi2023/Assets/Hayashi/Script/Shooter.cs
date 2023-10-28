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
            /*
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.x = 0f; 
            GameObject bullet = Instantiate(m_BulletPrefab, m_ShootPoint.position, Quaternion.identity);
            Vector3 shootDirection = (mousePosition - m_ShootPoint.position).normalized;
            bullet.GetComponent<Rigidbody>().AddForce(shootDirection * m_BulletForce, ForceMode.Impulse);
            Destroy(bullet, 2f);*/
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
