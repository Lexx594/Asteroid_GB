﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;
    public bool f;
    
    void Start()
    {
        offset = transform.position - player.transform.position;
    }
    
    
    void LateUpdate()
    {
        if (!f) transform.position = player.transform.position + offset;
        else
        {
            Rotation();
            Flay();
        }        
    }

    public void Rotation()
    {
        transform.Rotate(new Vector3(0, -10, 30) * Time.deltaTime);
    }

    public void Flay()
    {
        transform.position = new Vector3(transform.position.x,
        Mathf.Lerp(transform.position.y, transform.position.y -0.1f, Time.deltaTime *3f),
        Mathf.Lerp(transform.position.z, transform.position.z + 0.3f, Time.deltaTime * 3f));
    }


}
