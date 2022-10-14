using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPlayerController : MonoBehaviour
{
    public float speed = 20.0f;
    public float turnSpeed = 45.0f;
    public float pitchSpeed = 60.0f;
    //private float pitchReverse = 300.0f;
    public float pitchCap = 30.0f;
    public float gravityModifier;
    private Rigidbody rbplayer;

    private float horizontalInput;
    private float forwardInput;
    
    Vector3 velocity;
    public float wingsLift = 30;
    private bool wingsTired = false;
    private bool tired = false;

    // Start is called before the first frame update
    void Start()
    {
        rbplayer = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier; 
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        
        //downInput = Input.GetKeyDown(KeyCode.LeftControl);
        
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (Input.GetKey(KeyCode.LeftShift) && !tired)
        {
            speed = 40.0f;
            StartCoroutine(SpeedBoost());
            StartCoroutine(Tired());
        }

        //transform.localRotation = Quaternion.Euler(pitchSpeed * forwardInput, turnSpeed * horizontalInput, 0);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        //transform.Rotate(Vector3.right, pitchSpeed * forwardInput * Time.deltaTime);

        //if(transform.rotation.x > 30)
        //{
        //    transform.rotation = new Vector3(30f, transform.rotation.y);
        //}
        
        
        
        //if (transform.rotation.x < 0 && forwardInput == 0)
        //{
        //    transform.Rotate(Vector3.right, pitchReverse * Time.deltaTime);
        //}
        //else if (transform.rotation.x > 0 && forwardInput == 0)
        //{
        //    transform.Rotate(Vector3.right, -pitchReverse * Time.deltaTime);
        //}
        wingAction();
    }

    private void wingAction()
    {
        bool spaceInput = Input.GetKeyDown(KeyCode.Space);

        if (spaceInput && !wingsTired) //&& forwardInput == 0)
        {
            rbplayer.AddForce(Vector2.up * wingsLift, ForceMode.Impulse);
            //velocity.y = Mathf.Sqrt(wingsLift * -2f * gravityModifier);
            wingsTired = true;
            StartCoroutine(WingCD());
        }

        //velocity.y += gravityModifier * Time.deltaTime;
    }

    IEnumerator WingCD()
    {
        yield return new WaitForSeconds(1);
        wingsTired = false;
    }
    IEnumerator SpeedBoost()
    {
        yield return new WaitForSeconds(1.5f);
        speed = 20.0f;
        tired = true;
    }
    IEnumerator Tired()
    {
        yield return new WaitForSeconds(3f);
        tired = false;
    }
}
