using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    [SerializeField] private Camera Player_Cam;
    private Ray _ray;
    private RaycastHit _hitRaycast;
    [SerializeField] private float _maxDistanceRay;

    private void Update()
    {
        Ray();
        DrawRay();
    }

    private void Ray()
    {
        _ray = Player_Cam.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));


    }

    private void DrawRay()
    {
        if(Physics.Raycast(_ray, out _hitRaycast, _maxDistanceRay))
        {
            Debug.DrawRay(_ray.origin, _ray.direction *_maxDistanceRay, Color.blue);
        }
        else if(_hitRaycast.transform == null)
        {
            Debug.DrawRay(_ray.origin, _ray.direction *_maxDistanceRay, Color.red);
        }
    }

}
