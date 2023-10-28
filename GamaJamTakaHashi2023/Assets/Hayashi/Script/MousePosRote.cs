using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosRote : MonoBehaviour
{
    Plane m_Plane = new Plane();
    float m_Distance = 0;

    void Update()
    {
        // �J�����ƃ}�E�X�̈ʒu������Ray������
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // �v���C���[�̍�����Plane���X�V���āA�J�����̏������ɒn�ʔ��肵�ċ������擾
        m_Plane.SetNormalAndPosition(Vector3.up, transform.localPosition);
        if (m_Plane.Raycast(ray, out m_Distance))
        {

            // ���������Ɍ�_���Z�o���āA��_�̕�������
            var lookPoint = ray.GetPoint(m_Distance);
            transform.LookAt(lookPoint);
        }
    }
}
