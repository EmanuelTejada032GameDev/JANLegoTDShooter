using Assets.Scripts.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private List<Transform> _firePoints;
    public bool isAutomatic;

    private float _fireForce = 70f;
    [SerializeField] private float Range = 0f;
    public float timeBetweenShots;
    private float _shotTime;

    [SerializeField] private AudioSource _shootAudioSource;


    public void Fire()
    {

        if (Time.time >= _shotTime)
        {
            _shootAudioSource.Play();
            foreach (var firePoint in _firePoints)
            {
                GameObject bullet = Instantiate(_bulletPrefab, firePoint.position, firePoint.rotation);
                bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * _fireForce, ForceMode2D.Impulse);
                Destroy(bullet, Range);
            }
            _shotTime = Time.time + timeBetweenShots;
        }
        

    }
}
