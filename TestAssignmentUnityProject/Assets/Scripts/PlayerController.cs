using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    [SerializeField] 
    private float speed = 5f;

    public AudioClip hitSound;

    private Animator anim;
    private AudioSource audio;
    private Health health;

    public UnityEvent OnMoveStart;
    public UnityEvent OnMoveEnd;
    public bool IsMoving { get; private set; }

    private void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        health = GetComponent<Health>();
    }

    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        
        var direction = new Vector3(horizontal, vertical, 0);
        if(direction.sqrMagnitude > 1f) direction.Normalize();

        var lastMoving = IsMoving;
        IsMoving = direction.sqrMagnitude > 0f;

        anim.SetBool("isWalk", IsMoving);
        
        if(IsMoving && lastMoving != IsMoving) OnMoveStart?.Invoke();
        if(!IsMoving && lastMoving != IsMoving) OnMoveEnd?.Invoke();
        
        transform.Translate(direction * (speed * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 10)
        {
            health.TakeDamage(10);
            audio.PlayOneShot(hitSound);

            transform.DOMove(transform.position - (transform.position - collision.transform.position).normalized, 0.25f);
        }
    }
}
