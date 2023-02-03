using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardPlayer : MonoBehaviour
{

    [SerializeField] private Camera camera;
    private Vector2 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = camera.ScreenToWorldPoint(Input.mousePosition);
        
        
        if (Input.GetButton("Fire1"))
        {
            
        }
 
    }
}
