using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    // private Quaternion playerRotation;
    private GameObject player;

    public float movementSpeed = 5f;
    public float mouseSensetivityX = 5f;
    public float mouseSensetivityY = 5f;
    public float neckRange = 60.0f;
    

    private float pitch = 0;
    private float verticalV = 0;

    private CharacterController cc;
    private int M;

    [SerializeField]
    private float jumpSpeed = 20f;

    [SerializeField]
    private float gravity = 14;

    private Camera cam;


    void Start()
    {
        player = gameObject;
        Screen.lockCursor = true;
         cc = GetComponent<CharacterController>();
        cam = Camera.main;
    }

    void Update()
    {
       
        // Horizontal
        var yaw = Input.GetAxis("Mouse X") * mouseSensetivityX;
        transform.Rotate(0, yaw, 0);

        pitch -= Input.GetAxis("Mouse Y") * mouseSensetivityY;
        pitch = Mathf.Clamp(pitch, -neckRange, neckRange);
        cam.transform.localRotation = Quaternion.Euler(pitch, 0, 0);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            M = 2;
        }
        else
        {
            M = 1;
        }

         var v = Input.GetAxis("Vertical") * movementSpeed *M;
         var h = Input.GetAxis("Horizontal") * movementSpeed *M;


         if (cc.isGrounded)
         {
             verticalV = -gravity * Time.deltaTime;
             
             if (Input.GetButtonDown("Jump"))
             {
                 verticalV = jumpSpeed;
             }
         }
         else
         {
             verticalV -= gravity * Time.deltaTime;
         }

         Vector3 moveVector = Vector3.zero;
         moveVector.x = h;
         moveVector.y = verticalV;
         moveVector.z = v;
         moveVector = transform.rotation * moveVector;
         
         cc.Move(moveVector * Time.deltaTime);

    }
//        
//        if (cc.isGrounded)
//        {
//            if (Input.GetButtonDown("Jump"))
//            {
//                verticalV = jumpSpeed;
//                cc.Move(Vector3.up * jumpSpeed);
//                Debug.Log("1");
//            }
//            else
//            {
//                verticalV = 0;
//              
//                Debug.Log("2");
//            }
//        }
//        else
//        {
//            verticalV = Physics.gravity.y * Time.deltaTime;
////           cc.Move(new Vector3(0, verticalV, 0));
//
//            Debug.LogError("3");
//
//        }
//
//         
//       cc.Move(transform.forward * v + transform.right * h);
//         cc.Move(Physics.gravity*Time.smoothDeltaTime);
//        



//        cc.Move(Physics.gravity * Time.deltaTime + transform.forward * v + transform.right * h);

        
        
        
//        cc.Move(Physics.gravity);

    }

   
