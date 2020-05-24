using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour
{

    public float sensitivityVert = 9.0f;
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;
    private float _rotationX = 0;

    // Инициализации нет
    void Start()
    {
    }

    // Вызывается при отрисовке каждого кадра
    void Update()
    {
        if (!Volume.pause)
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivityVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            transform.localEulerAngles = new Vector3(_rotationX, 0, 0);
        }
    }

}
