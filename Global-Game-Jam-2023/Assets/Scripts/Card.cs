using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    private Hand hand;
    private Camera cam;
    private bool isHeld = false;

    public Vector2 originalPosition;
    private void Start()
    {
        transform.position = originalPosition;
        if (cam == null)
        {
            cam = FindObjectOfType<Camera>();
        }

        if (hand == null)
        {
            hand = FindObjectOfType<Hand>();
        }
    }
    

    private void OnMouseOver()
    {
        if (Input.GetButton("Fire1"))
        {
            isHeld = true;
            Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0;
            transform.position = mousePos;
        }
        else if (isHeld)
        {
            if (transform.position.y < hand.handTopHeight)
            {
                transform.position = originalPosition;
            }
            else
            {
                Play();
            }
            isHeld = false;
        }


    }

    private void OnMouseExit()
    {
        
    }

    public void Play()
    {
        Destroy(gameObject);
    }
    
    
}
