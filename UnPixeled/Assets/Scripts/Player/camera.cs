using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class camera : MonoBehaviour
{
    // Variables //________________________________________________________________________________________________________________________________________________________________
    playerController player;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    public Volume volume;

    private void Start()//____________________________________________________________________________________________________________________________________________________________________________
    {
        player = GameManager.instance.player;
        volume = GetComponent<Volume>();
    }

    private void LateUpdate()//____________________________________________________________________________________________________________________________________________________________________________
    {
        Vector3 desiredPosition = player.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;
    }
}
