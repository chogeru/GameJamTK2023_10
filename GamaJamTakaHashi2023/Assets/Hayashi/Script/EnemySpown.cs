using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpown : MonoBehaviour
{
    [SerializeField]
    private float m_MaxSpownInterval;
    [SerializeField]
    private float m_MinSpownInterval;
    [SerializeField]
    private float m_SpownTime;
    [SerializeField]
    private GameObject[] m_EnemyPrefabs;
    [SerializeField]
    private Transform m_SpownPoint;
    private void Update()
    {
        m_SpownTime-=Time.deltaTime;
        if (m_SpownTime <= 0)
        {
            GameObject randomEnemyPrefab = m_EnemyPrefabs[Random.Range(0, m_EnemyPrefabs.Length)];
            Instantiate(randomEnemyPrefab,transform.position,Quaternion.identity);
            m_SpownTime = Random.Range(m_MinSpownInterval,m_MaxSpownInterval);

        }

    }
}
