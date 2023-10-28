using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyState : ScriptableObject
{
    private int m_HP;
    private int m_Attack;
    private float m_Speed;

    public int HP
    {
        get { return m_HP; }
        set { m_HP = value; }
    }
    public int Attack
    {
        get { return m_Attack; }
        set { m_Attack = value; }
    }

    public float Speed
    {
        get { return m_Speed; }
        set { m_Speed = value; }
    }
}
