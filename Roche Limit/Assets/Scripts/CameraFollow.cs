using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player; // Assign your player's Transform in the Inspector
    [SerializeField] private Vector3 cameraOffset = new Vector3(0f, 0f, -10f); // Renamed from 'offset'
    [SerializeField] private float followSpeed = 5f; // Speed of the camera movement

    void LateUpdate()
    {
        // Check if the player still exists
        if (player != null)
        {
            Vector3 targetPosition = player.position + cameraOffset;
            transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
        }
        else
        {
            Debug.LogWarning("Player has been destroyed. Camera will stop following.");
        }
    }
}
