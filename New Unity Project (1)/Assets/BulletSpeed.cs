using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpeed : MonoBehaviour
{
    public float speed;
    public float fireRate;
    public NPCaim npcaim;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (speed != 0) 
        {
            transform.position += transform.forward * (speed * Time.deltaTime);
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        
        if(collision.gameObject.name == "CasualNinjaModel")
        {
            Debug.Log(collision.gameObject.name);
            collision.gameObject.GetComponent<Movement>().PlayerGetHit();
        }
        if(collision.gameObject.name == "BlockHitBox")
        {
            collision.gameObject.GetComponent<SowardHitSpwan>().HitSpark();
        }
        
        Debug.Log(collision.gameObject.name);
        speed = 0;
        Destroy(gameObject);


    }
}
