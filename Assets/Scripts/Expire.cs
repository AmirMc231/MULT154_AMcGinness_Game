using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 20.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
