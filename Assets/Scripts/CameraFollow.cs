using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Vector3 _cameraOffset;

    private float _smoothSpeed = 10f;
    private Vector3 _desiredPosition;
    private Vector3 _smoothedPosition;

    private void FixedUpdate()
    {
        _desiredPosition = _playerTransform.position + _cameraOffset;
        _smoothedPosition = Vector3.Lerp(transform.position, _desiredPosition, _smoothSpeed * Time.deltaTime);
        transform.position = _smoothedPosition;
    }
}
