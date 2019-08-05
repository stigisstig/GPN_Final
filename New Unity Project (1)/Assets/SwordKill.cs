using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordKill : MonoBehaviour
{
    public Collider killCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J) && !(Input.GetKey(KeyCode.K)))
        {
            killCollider.enabled = true;
        }
        else
        {
            killCollider.enabled = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name.Contains("CasualNinjaModel"))
        {
            collision.gameObject.GetComponent<shootPlayer>().NpcGetHit();
        }
    }
    
}
