using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public List<Transform> Body = new List<Transform>();
    public float speed = 1;
    public float speedRotation = 50;
    public GameObject Head;
    public int startSize;
    public float minimumdist = 3f;

    private float dist;
    private Transform currentBody;
    private Transform PreviousBody;


    // Start is called before the first frame update
    void Start()
    {
        for (int count = 0; count < startSize; count++)
        {
            addSnakeBody();
        }

    }


    private void LateUpdate()
    {
        SnakeMove();
        if (Input.GetKey(KeyCode.Q))
        {
            addSnakeBody();
        }

    }

    void SnakeMove()
    {

        float movingspeed = speed;

        if (Input.GetKey(KeyCode.W))
        {
            movingspeed *= 5;
        }

        Body[0].Translate(Body[0].forward * movingspeed
            * Time.smoothDeltaTime, Space.World);

        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
        {
            Body[0].Rotate(Vector3.up * speedRotation * Time.deltaTime
                * Input.GetAxis("Horizontal"));
        }

        for (int counter = 1; counter < Body.Count; counter++)
        {
            currentBody = Body[counter];
            PreviousBody = Body[counter - 1];
            dist = Vector3.Distance(PreviousBody.position, currentBody.position);
            Vector3 updateposition = PreviousBody.position;
            updateposition.y = Body[0].position.y;

            float currentTime = (Time.deltaTime * dist)
            / (minimumdist * movingspeed);

            if (currentTime > 0.5f)
            {
                currentTime = 0.5f;
            }
            currentBody.rotation = Quaternion.Slerp(currentBody.rotation, PreviousBody.rotation, currentTime);
            currentBody.position = Vector3.Slerp(currentBody.position, updateposition, currentTime);
        }
    }


    void addSnakeBody()
    {
        Transform extraPart = (Instantiate(Head, Body[Body.Count - 1].position,
        Body[Body.Count - 1].rotation) as GameObject).transform;
        extraPart.SetParent(transform);
        Body.Add(extraPart);
    }

}
