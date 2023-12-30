using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Transform _playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _playerTransform = FindObjectOfType<SpawnManager>()._gameObject.transform;
        transform.position = _playerTransform.transform.position + new Vector3(0, 1, -5);
    }
}
