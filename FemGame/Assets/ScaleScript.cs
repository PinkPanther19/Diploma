using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleScript : MonoBehaviour
{
    public Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        // �������� ������� �������� �������
        scale = transform.localScale;
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    public void increaseScale()
    {
        // ����������� ������� �� 50%
        scale.x *= 1.5f;
        scale.y *= 1.5f;

        // ��������� ����� ������� � �������
        transform.localScale = scale;
    }
}
