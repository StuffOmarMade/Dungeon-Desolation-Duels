using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _gameObjectPrefab;

    public GameObject _gameObject;

    //for now
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private Vector2 randomPosition;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        RespawnPlayer();
    }

    private void SpawnPlayer() 
    {
        randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        _gameObject = PhotonNetwork.Instantiate(_gameObjectPrefab.name, randomPosition, Quaternion.identity);
    }

    private void RespawnPlayer() 
    {
        if (_gameObject.GetComponent<PlayerHealth>().IsDead == true)
        {
            _gameObject.GetComponent<Player>().CurrentHealthPoints = _gameObject.GetComponent<Player>().MaximumHealthPoints;
            _gameObject.GetComponent<PlayerHealth>().IsDead = false;
            randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            _gameObject.transform.position = randomPosition;
        }
    }

}
