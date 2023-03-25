using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{

    
    public float Sensitivity;
    public float speed;

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

  

    // Update is called once per frame

    GameObject BuildingBlock;
    void Update()
    {
        float dt = Time.deltaTime;

        Vector3 forward = transform.forward;
        forward.y = 0f;
        Vector3 right = transform.right;
        right.y = 0f;

        float AirTime = 1;


        Vector3 Vel = (forward * Input.GetAxis("Vertical") + right * Input.GetAxis("Horizontal"));
        Vel.Normalize();
        
        if (rb.velocity.y != 0)
        {
            AirTime = 0.5f;
        }
        Vel *= speed * AirTime;
        Vel.y = rb.velocity.y;
        rb.velocity = Vel;


        
       
        if (Input.GetKeyDown(KeyCode.Space) && rb.velocity.y < 0.1 && rb.velocity.y > -0.1)
        {
            rb.AddForce(transform.up * 300);
        }

      
    }
}
