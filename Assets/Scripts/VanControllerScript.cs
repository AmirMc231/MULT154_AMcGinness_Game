using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VanControllerScript : MonoBehaviour
{
    public float speed = 20.0f;
    public float turnSpeed = 45.0f;
    public float pitchSpeed = 60.0f;
    private float horizontalInput;
    private float forwardInput;
    private bool upInput;
    private bool downInput;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        upInput = Input.GetKeyDown(KeyCode.Space);
        downInput = Input.GetKeyDown(KeyCode.LeftControl);
        
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        
        if(upInput == true)
        {
            transform.Rotate(Vector3.right, - pitchSpeed * Time.deltaTime);
        }else if (downInput == true)
        {
            transform.Rotate(Vector3.right, pitchSpeed * Time.deltaTime);
        }




    }
}
