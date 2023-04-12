using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounds : MonoBehaviour
{
    public Transform center;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Transform playerTransform = collision.transform;
            playerTransform.DOMove(playerTransform.position - (playerTransform.position - center.transform.position).normalized, 0.25f);
        }
    }
}
