using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerShootController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform shootPoint;
    [SerializeField] private Transform rotationPoint;
    [SerializeField] private ParticleSystem particle;
    [SerializeField] private AudioClip fireSound;

    private AudioSource audio;

    public UnityEvent OnShoot;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void Update()
    {
        RotateTowardsMouse();
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void RotateTowardsMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(mousePosition.x - rotationPoint.position.x, mousePosition.y - rotationPoint.position.y);
        //calculate angle
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //rotate
        rotationPoint.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    
    private void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, shootPoint.position, rotationPoint.rotation);
        var bulletParticle = Instantiate(particle, shootPoint.position, particle.transform.rotation);

        bulletParticle.transform.parent = bullet.transform;

        audio.PlayOneShot(fireSound);

        OnShoot.Invoke();
    }
}
