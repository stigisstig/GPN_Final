using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBullet : MonoBehaviour
{
    public Collider ccollider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            ccollider.enabled = true;
            
        }
        else
        {
            ccollider.enabled = false;
        }
    }
    
}
