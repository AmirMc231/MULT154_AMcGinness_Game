using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerEnemy : MonoBehaviour
{
    //GameObject player;
    private Transform PlayerDir;
    private float distance;
    public float range;
    public Transform head;
    public float speed = 40.0f;
    //public float nextFire;


    // Start is called before the first frame update
    void Start()
    {

        PlayerDir = GameObject.Find("Bird_Rig").transform;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerProjectile"))
        {
            Destroy(gameObject);
        }
    }
}
