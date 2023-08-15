using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    private Vector3 offset;
    public float cameraspeed;
    private Vector3 currentvelocity=Vector3.zero;
    private void Awake()
    {
        offset = transform.position - player.position;  
    }
    private void LateUpdate()
    {
        Vector3 desiredposition = player.position + offset;
        Vector3 smoothposition = Vector3.SmoothDamp( transform.position, desiredposition, ref currentvelocity, cameraspeed);
        transform.position = smoothposition;
       // transform.LookAt(player);
    }
}
