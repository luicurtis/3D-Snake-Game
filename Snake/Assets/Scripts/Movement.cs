using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    private float speed = 10f;
    private float jump = 25f;
    private float gravity = 30f;
    public int length = 1;
    private Vector3 Direction = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {

    }

    // 
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Food")
        {
            Destroy(col.gameObject);
            length++;
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        CharacterController control = gameObject.GetComponent<CharacterController>();
        if (control.isGrounded)
        {
            Direction = new Vector3 (Input.GetAxis("Horizontal"), 0, 
            Input.GetAxis("Vertical"));

            Direction = transform.TransformDirection(Direction);
            Direction *= speed;

            if (Input.GetButtonDown("Jump"))
            {
                Direction.y = jump;
            }
        }

        Direction.y -= gravity * Time.deltaTime;

        control.Move(Direction * Time.deltaTime);

    }
}
