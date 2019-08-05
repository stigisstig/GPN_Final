using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NPCaim : MonoBehaviour
{
    public Transform target;
    public Transform npc;
    public Vector3 playerPos;
    public Vector3 npcPos;
    public AvatarBuilder avatar;
    Quaternion rotation;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 delta = new Vector3(target.position.x - npc.position.x, 0.0f, target.position.z - npc.position.z);
        Vector3 left = new Vector3(1f,0f ,0f);
        rotation = Quaternion.LookRotation(delta);

        npc.rotation = rotation;
    }
    public Quaternion getRotation()
    {
        return rotation;
    }


}
