using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpown : MonoBehaviour
{

 
    [SerializeField,Header("最大スポーンタイム")]
    private float m_MaxSpownInterval;
    [SerializeField,Header("最小スポーンタイム")]
    private float m_MinSpownInterval;
    [SerializeField,Header("最大スポーンタイムの元の時間")]
    private float m_OriginalInterval;
    [SerializeField]
    private float m_BounusTimeInterval;
    [SerializeField]
    private float m_OriginalBounusTime;
    [SerializeField]
    private float m_SpownTime;
    [SerializeField]
    private GameObject[] m_EnemyPrefabs;
    [SerializeField]
    private Transform m_SpownPoint;
    [SerializeField]
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
        
        if(spownManager.isBounus)
        {
            BounusTime();
         
            if(spownManager.m_BounusTime <= 0)
            {
                spownManager.m_BonusCount = 0;
                spownManager.m_BounusTime = m_OriginalBounusTime;
                spownManager.isBounus = false;
            }
        }
        if(spownManager.isBounus==false)
        {
            EndBounusTime();
        }
    }
    private void BounusTime()
    {
        m_MaxSpownInterval = m_BounusTimeInterval;
    }
    private void EndBounusTime()
    {
        m_MaxSpownInterval = m_OriginalInterval;
    }
}
