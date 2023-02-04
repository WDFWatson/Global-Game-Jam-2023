using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private Camera cam;
    private void Start()
    {
        if (cam == null)
        {
            cam = FindObjectOfType<Camera>();
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetButton("Fire1"))
        {
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos;
        }

    }
}
