using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleScript : MonoBehaviour
{
    public Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        // Получаем масштаб текущего объекта
        scale = transform.localScale;
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}

    public void increaseScale()
    {
        // Увеличиваем масштаб на 50%
        scale.x *= 1.5f;
        scale.y *= 1.5f;

        // Применяем новый масштаб к объекту
        transform.localScale = scale;
    }
}
