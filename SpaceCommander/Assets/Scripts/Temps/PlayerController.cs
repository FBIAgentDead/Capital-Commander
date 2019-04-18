using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera playerDirection;
    private Rigidbody playerMove;
    private Animator playerAnimations;
    public float speed;
    public float jumpHeight;
    public float panicSpeed;
    public LayerMask ground;
    public float checkHeight;
    public float sensitivity;
    private float xAxisClamp = 0f;
    public int player = 0;

    void Start()
    {
        playerMove = GetComponent<Rigidbody>();
        playerAnimations = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump" + player) && Grounded())
        {
            playerMove.AddForce(transform.up * jumpHeight, ForceMode.Impulse);
            //playerAnimations.Play("Jump 1");
        }
        
        //playerAnimations.SetFloat("velY", -Input.GetAxis("Y axis" + player));
        //playerAnimations.SetFloat("velX", Input.GetAxis("X axis" + player));
        //playerAnimations.SetBool("grounded", Grounded());
        float currentSpeed = playerMove.velocity.magnitude/panicSpeed;
        //playerAnimations.SetFloat("playerSpeed", currentSpeed);
        //Debug.Log(Mathf.RoundToInt(currentSpeed));

        float xboxYAxsis = Input.GetAxis("Y axis" + player) * speed * Time.deltaTime;
        float xboxXAxsis = Input.GetAxis("X axis" + player) * speed * Time.deltaTime;

        transform.Translate(-Vector3.forward * xboxYAxsis);
        transform.Translate(Vector3.right* xboxXAxsis);

        float mouseX = Input.GetAxis("X axis2" + player) * sensitivity;
        float mouseY = Input.GetAxis("Y axis2" + player) * sensitivity;

        xAxisClamp += mouseY;

        if(xAxisClamp > 90){
            xAxisClamp = 90;
            mouseY = 0;
        }
        else if(xAxisClamp < -90){
            xAxisClamp = -90;
            mouseY = 0;
        }

        transform.Rotate(0,mouseX,0);
        playerDirection.transform.Rotate(-mouseY,0,0);

        //CheckEmotes();

    }

    private bool Grounded(){
        if(Physics.Raycast(transform.position, -transform.up, checkHeight, ground)){
            return true;
        }
        return false;
    }

    private void CheckEmotes(){
        if(Input.GetAxis("up" + player) > 0){
            //playerAnimations.Play("Emote 4");
        }
    }

}
