using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpown : MonoBehaviour
{

    private float m_BounusTime=10;
    [SerializeField]
    private float m_MaxSpownInterval;
    [SerializeField]
    private float m_MinSpownInterval;
    [SerializeField]
    private float m_BounusTimeInterval;
    [SerializeField]
    private float m_SpownTime;
    [SerializeField]
    private GameObject[] m_EnemyPrefabs;
    [SerializeField]
    private Transform m_SpownPoint;

    SpownManager spownManager;
    private void Update()
    {
        m_SpownTime-=Time.deltaTime;
        if (m_SpownTime <= 0)
        {
            GameObject randomEnemyPrefab = m_EnemyPrefabs[Random.Range(0, m_EnemyPrefabs.Length)];
            Instantiate(randomEnemyPrefab,transform.position,Quaternion.identity);
            m_SpownTime = Random.Range(m_MinSpownInterval,m_MaxSpownInterval);

        }
        /*
        if(spownManager.isBounus)
        {
            BounusTime();
            m_BounusTime -= Time.deltaTime;
            if(m_BounusTime <= 0)
            {
                EndBounusTime();
                spownManager.m_BonusCount = 0;
                spownManager.isBounus = false;
                m_BounusTime = 10;
            }
        }*/
    }
    private void BounusTime()
    {
        m_MaxSpownInterval -= m_BounusTimeInterval;
    }
    private void EndBounusTime()
    {
        m_MaxSpownInterval += m_BounusTimeInterval;
    }
}
