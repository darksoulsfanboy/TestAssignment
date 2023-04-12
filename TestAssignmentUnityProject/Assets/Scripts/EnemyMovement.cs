using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG;
using DG.Tweening;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public float moveTimer = 0;
    public float moveInterval = 2f;

    private Vector2 direction;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        moveTimer += Time.deltaTime;

        if (moveTimer >= moveInterval)
        {
            Move();
            moveTimer = 0f;
        }

    }

    private void Move()
    {
        direction = new Vector2(Random.Range(-4f, 4f), Random.Range(-4f, 4f));
        transform.DOMove(direction, 1f);
    }
}
