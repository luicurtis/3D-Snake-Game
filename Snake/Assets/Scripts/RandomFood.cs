using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RandomFood : MonoBehaviour
{
    public GameObject Food;
    private Vector3 RandomVector;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Thread.Sleep(7000);
        float x = (Random.Range(-10, 10));
        float y = (Random.Range(1, 2));
        float z = (Random.Range(-10, 10));

        RandomVector = new Vector3(x, y, z); 
        Instantiate(Food, RandomVector, Quaternion.identity);
        
    }
}
