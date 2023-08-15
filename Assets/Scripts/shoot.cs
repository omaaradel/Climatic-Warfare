using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    [SerializeField]
    private GameObject _bulletPrefab;

    [SerializeField]
    private float _bulletSpeed;

    [SerializeField]
    private Transform _gunOffset;

    [SerializeField]
    private float _timeBetweenShots;

    private bool ingreen;
    private bool _fireContinuously;
    private bool _fireSingle;
    private float _lastFireTime = 0;
    public AudioSource shootsound;
    private gamemanager manager;
    private GameObject theplayer;


    void Start()
    {
        manager = GameObject.Find("gamemanager").GetComponent<gamemanager>();
        theplayer  = GameObject.Find("Player");
    }

    void Update()
    { 
        //if (theplayer.transform.position.z<26f && theplayer.transform.position.z >-26f && theplayer.transform.position.x > -74.4f && theplayer.transform.position.x <74.4f)
        //{
        //    ingreen = true;
        //}
        //else
        //{
        //    ingreen = false;
        //}
            if (Input.GetKeyDown(KeyCode.Space) && manager.active)
        {
            _fireContinuously = true;
            shootsound.Play();

            FireBullet();
        }
        



    }

    private void FireBullet()
    {
        
        GameObject bullet = Instantiate(_bulletPrefab, _gunOffset.position, _bulletPrefab.transform.rotation);
        Rigidbody rigidbody = bullet.GetComponent<Rigidbody>();

        rigidbody.velocity = _bulletSpeed * transform.forward;
    }

}

//////////////////////////////////////////////////////////////////////////////////////////////////////////////
