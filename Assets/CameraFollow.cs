using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _spaceShip;

    Vector3 _spaceShipOffset;
    // Start is called before the first frame update
    private void Awake()
    {
        _spaceShipOffset = this.transform.position - _spaceShip.position;
    }

    private void LateUpdate()
    {
        this.transform.position = _spaceShip.position + _spaceShipOffset;
    }
}
