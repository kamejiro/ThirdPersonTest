using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    
    //public float upForce=200f;

    //private bool isGround;
    //private readonly float posXClamp = 3.0f;
    //private readonly float posYClamp = 3.0f;
    //private readonly float posZClamp = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 vector3 = new Vector3(x, 0, z);
        rb.AddForce(vector3 * speed);
    }
}
