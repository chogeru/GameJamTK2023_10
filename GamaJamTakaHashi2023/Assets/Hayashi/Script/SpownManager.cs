using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownManager : MonoBehaviour
{
    public bool isBounus;
    public int m_BonusCount;

    private void Update()
    {
        if(m_BonusCount>=10)
        {
            isBounus = true;
        }
    }
}
