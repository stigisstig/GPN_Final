using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SowardHitSpwan : MonoBehaviour
{
    public GameObject sparkPoint;
    public GameObject sparktoSpawn;
    public NPCaim aim;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void HitSpark()
    {
        GameObject vfx;
        //GameObject flash;
        if (sparkPoint != null)
        {
            vfx = Instantiate(sparktoSpawn, sparkPoint.transform.position, Quaternion.identity);
        }
        else
        {
            //yes
        }
    }
}
