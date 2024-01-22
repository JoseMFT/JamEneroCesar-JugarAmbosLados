using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FondoMovimiento : MonoBehaviour
{
    private Vector3 startPosition;
    public float speed = 4.0f;

    private void Start()
    { 
        startPosition = transform.position;
    }
    private void Update()
    {
        transform.Translate(translation:Vector3.down*speed*Time.deltaTime);
        if (transform.position.y < -10.50304f)
        {
            transform.position = startPosition;
        }
    }
}
