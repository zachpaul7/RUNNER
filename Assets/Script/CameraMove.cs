using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    private Transform lookAt;
    private Vector3 startOffset;

    private void Start()
    {
        lookAt = GameObject.FindGameObjectWithTag("Player").transform;
        startOffset = transform.position - lookAt.position;
    }

    private void Update()
    {
        transform.position = lookAt.position + startOffset; 
    }
}
