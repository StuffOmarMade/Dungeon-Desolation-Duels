using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameObjectPrefab;

    //for now
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;


    // Start is called before the first frame update
    void Start()
    {
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        PhotonNetwork.Instantiate(_gameObjectPrefab.name, randomPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
