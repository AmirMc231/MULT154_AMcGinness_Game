using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretEnemy : MonoBehaviour
{
    //GameObject player;
    private Transform PlayerDir;
    private float distance;
    public float range;
    public Transform head;
    public Transform gun;
    public GameObject bullet;
    //public float nextFire;
    
   
    
    
    

    // Start is called before the first frame update
    void Start()
    {
        
        PlayerDir = GameObject.Find("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        //head.LookAt(PlayerDir);
        TurretPointer();
    }

    void TurretPointer()
    {
        //Vector3 turDirection = (PlayerDir.transform.position - transform.position).normalized;
        distance = Vector3.Distance(PlayerDir.position, transform.position);
        if (distance <= range)
        {
            head.LookAt(PlayerDir);
            
        }
    }

    
}
