using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;

    private Vector3 velocity = Vector3.zero;
    private Vector3 offset = new Vector3(1, 0, 1);
    private float smooth = 0.25f;
    

    private void Update()
    {
        Vector3 targetPosition = player.position - offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smooth);
    }
}
