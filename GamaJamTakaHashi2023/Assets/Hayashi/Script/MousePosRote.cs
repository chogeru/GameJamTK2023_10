using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosRote : MonoBehaviour
{
    Plane m_Plane = new Plane();
    float m_Distance = 0;

    void Update()
    {
        // カメラとマウスの位置を元にRayを準備
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // プレイヤーの高さにPlaneを更新して、カメラの情報を元に地面判定して距離を取得
        m_Plane.SetNormalAndPosition(Vector3.up, transform.localPosition);
        if (m_Plane.Raycast(ray, out m_Distance))
        {

            // 距離を元に交点を算出して、交点の方を向く
            var lookPoint = ray.GetPoint(m_Distance);
            transform.LookAt(lookPoint);
        }
    }
}
