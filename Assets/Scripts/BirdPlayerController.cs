using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdPlayerController : MonoBehaviour
{
    private Animator anim;
    public float speed = 20.0f;
    private float flightSpeed;
    private float speedMult = 200.0f;
    public float turnSpeed = 45.0f;
    private float pitchSpeed = 45.0f;
    //private float pitchReverse = 300.0f;
    public float pitchCap = 30.0f;
    public float gravityModifier;
    private Rigidbody rbplayer;

    private float horizontalInput;
    private float forwardInput;
    private float horzRotation;
    private float vertRotation;

    public float wingsLift = 30;
    public float knockback = 20;
    private bool wingsTired = false;
    private bool tired = false;
    private bool notLevel;

    // Start is called before the first frame update
    void Start()
    {
        rbplayer = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier; 
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        flightSpeed = speed;
        anim = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        
        transform.Translate(Vector3.forward * Time.deltaTime * flightSpeed);

        shiftBoost();
        turning();
        wingAction();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            rbplayer.AddForce(Vector3.up * knockback, ForceMode.Impulse);
        }
        else if(collision.collider.CompareTag("Edge"))
        {
            rbplayer.AddForce(Vector3.forward * -knockback * 5, ForceMode.Impulse);
            StartCoroutine(EdgeKnock());
        }
    }
    private void wingAction()
    {
        bool spaceInput = Input.GetKeyDown(KeyCode.Space);

        if (spaceInput && !wingsTired) //&& forwardInput == 0)
        {
            anim.SetBool("WingLift", true);
            rbplayer.AddForce(Vector2.up * wingsLift, ForceMode.Impulse);
            wingsTired = true;
            StartCoroutine(WingCD());
        }

        //velocity.y += gravityModifier * Time.deltaTime;
    }
    private void shiftBoost()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !tired)
        {
            anim.SetBool("Fast", true);
            flightSpeed = speed * 2; //+ speedMult * Time.deltaTime;
            StartCoroutine(SpeedBoost());
            StartCoroutine(Tired());
        }
    }
    private void turning()
    {
        if (horizontalInput > 0)
        {
            horzRotation = horzRotation + turnSpeed * Time.deltaTime;
            anim.SetBool("TurnRight", true);
        }
        else if (horizontalInput < 0)
        {
            horzRotation = horzRotation - turnSpeed * Time.deltaTime;
            anim.SetBool("TurnLeft", true);
        }
        else
        {
            anim.SetBool("TurnRight", false);
            anim.SetBool("TurnLeft", false);
        }

        transform.rotation = Quaternion.Euler(pitchSpeed * forwardInput, horzRotation, horizontalInput * -30.0f);

        if(forwardInput < -0.5f)
        {
            //flightSpeed = speed * 0.5f;
            transform.Translate(Vector3.forward * Time.deltaTime * (flightSpeed - flightSpeed / 2));

        }
        else if(forwardInput > 0.5f)
        {
            //flightSpeed = speed * 1.5f;
            transform.Translate(Vector3.forward * Time.deltaTime * (flightSpeed + flightSpeed / 2));
        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime * flightSpeed);
        }

        
    }
    
    IEnumerator EdgeKnock()
    {
        flightSpeed = 0;
        yield return new WaitForSeconds(2f);
        flightSpeed = speed;
    }
    IEnumerator WingCD()
    {
        yield return new WaitForSeconds(1f);
        wingsTired = false;
        anim.SetBool("WingLift", false);
    }
    IEnumerator SpeedBoost()
    {
        
        yield return new WaitForSeconds(1.5f);
        flightSpeed = speed;
        tired = true;
        anim.SetBool("Fast", false);
    }
    IEnumerator Tired()
    {
        yield return new WaitForSeconds(3f);
        tired = false;
    }

    IEnumerator FlightEven()
    {
        yield return new WaitForSeconds(1f);
        flightSpeed = speed;
    }
}
