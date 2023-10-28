using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpownManager : MonoBehaviour
{
    public bool isBounus;
    [SerializeField]
    private int m_MaxBounusCount;
    public int m_BonusCount;
    [SerializeField]
    public float m_BounusTime = 15;
    [SerializeField]
    private GameObject m_BounusTimeText;
    [SerializeField]
    private Slider m_BounusSlider;
    private void Start()
    {
        m_BounusTimeText.SetActive(false);
        m_BounusSlider.value = 1;
    }
    private void Update()
    {
        m_BounusSlider.value = (float)m_BonusCount / (float)m_MaxBounusCount;
        if(m_BonusCount>=m_MaxBounusCount)
        {
            m_BounusTimeText.SetActive(true);
            isBounus = true;
        }
        else
        {
            m_BounusTimeText.SetActive(false);
        }
        if(isBounus)
        {
           m_BounusTime -= Time.deltaTime;
        }
    }
}
