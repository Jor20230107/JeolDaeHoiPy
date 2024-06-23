using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Update()
    {
        CheckIfOutsideCameraView();
    }

    void CheckIfOutsideCameraView()
    {
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);

        // 만약 탄환이 카메라 뷰포트 밖으로 나가면 삭제
        if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
        {
            Destroy(gameObject);
        }
    }
}
