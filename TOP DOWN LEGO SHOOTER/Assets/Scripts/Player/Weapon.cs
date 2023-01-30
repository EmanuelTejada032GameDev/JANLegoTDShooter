using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private List<Transform> _firePoints;
    private float _fireForce = 70f;
    [SerializeField] private float Range = 0f;


    public void Fire()
    {
        foreach (var firePoint in _firePoints)
        {
            GameObject bullet = Instantiate(_bulletPrefab, firePoint.position, firePoint.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * _fireForce, ForceMode2D.Impulse);
            Destroy(bullet, Range);
        }

    }
}
