using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class Score : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_ScoreText;
    [SerializeField]
    private TextMeshProUGUI m_ClearScreenText;
    [SerializeField]
    public int m_Score=0;
    void Update()
    {
        m_ScoreText.text = string.Format("â^ãC:{0}", m_Score);
        m_ClearScreenText.text = string.Format("èWÇﬂÇΩâ^ãC:{0}", m_Score);

    }
}
