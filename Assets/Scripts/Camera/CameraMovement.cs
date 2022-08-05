using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Camera _camera;
    private float _cameraOffsetZ;

    [SerializeField] GameObject bodyPart;

     void Start()
    {
        _camera = Camera.main;
        _cameraOffsetZ = _camera.transform.position.z - bodyPart.transform.position.z;
    }

    private void LateUpdate()
    {
        CameraFollow();
    }

    private void CameraFollow()
    {
        Vector3 pos = new Vector3(_camera.transform.position.x, _camera.transform.position.y, bodyPart.transform.position.z + _cameraOffsetZ);
        _camera.transform.position = pos;

    }
}
