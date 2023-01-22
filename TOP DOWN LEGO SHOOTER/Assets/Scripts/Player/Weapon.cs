using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab; 
    [SerializeField] private Transform _firePoint;
    private float _fireForce = 70f;

    public void Fire()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().AddForce(_firePoint.up * _fireForce, ForceMode2D.Impulse);
        Destroy(bullet,0.8f);
    }
}
