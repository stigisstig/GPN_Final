using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootPlayer : MonoBehaviour
{
    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    public GameObject bulletToSpawn;
    public GameObject playerPostition;
    public GameObject npc;
    public NPCaim aim;
    public GameObject muzzle_flash;
    private float timeToFire;
    public int magazine;
    // Start is called before the first frame update
    void Start()
    {
        magazine = 15;
        bulletToSpawn = vfx[0];
    }

    // Update is called once per frame
    void Update()
    {
        if ((Math.Abs(firePoint.transform.position.x - playerPostition.transform.position.x) < 5f) && Time.time >= timeToFire && magazine > 0)
        {
            magazine -= 1;
            timeToFire = Time.time + 1 / bulletToSpawn.GetComponent<BulletSpeed>().fireRate;
            BulletSpawn();
        }
        if(magazine == 0)
        {
        }
    }
    void BulletSpawn()
    {
        GameObject vfx;
        GameObject flash;
        if(firePoint != null)
        {
            vfx = Instantiate(bulletToSpawn, firePoint.transform.position, Quaternion.identity);
            
            flash = Instantiate(muzzle_flash, firePoint.transform.position, Quaternion.identity);
            vfx.transform.localRotation = aim.getRotation();
            Destroy(flash, 0.09f);
            
        }
        else
        {
            //yes
        }
    }
    public void NpcGetHit()
    {
        Destroy(npc);
    }
}
