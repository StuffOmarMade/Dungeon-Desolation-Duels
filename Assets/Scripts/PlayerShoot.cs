using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;
    private GameObject _bullet;
    private Rigidbody2D _bulletRigidbody;

    [SerializeField]
    private Transform _firePointTransform;

    //for now
    private float force = 20f;

    // Update is called once per frame
    void Update()
    {
        if(IsShooting())
            ShootBullet();
    }

    private bool IsShooting() 
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            return true;
        }

        return false;
    }

    private void ShootBullet() 
    {
        _firePointTransform = FindObjectOfType<SpawnManager>()._gameObject.transform;
        _bullet = Instantiate(_bulletPrefab, (_firePointTransform.position + new Vector3(1, 0, 0)), _firePointTransform.rotation);
        _bulletRigidbody = _bullet.GetComponent<Rigidbody2D>();
        _bulletRigidbody.AddForce(_firePointTransform.right * force, ForceMode2D.Impulse);
    }
}
