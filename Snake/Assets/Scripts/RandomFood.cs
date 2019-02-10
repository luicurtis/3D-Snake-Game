using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RandomFood : MonoBehaviour
{
    public GameObject Food;
    private Vector3 RandomVector;
    private float time;
    private float SpawnInterval = 3f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (time >= SpawnInterval)
        {
            this.Spawn();
            time = 0;
        }
        else
        {
            time += Time.deltaTime;
        }

    }

    void Spawn()
    {
        float x = (Random.Range(-10, 10));
        float y = 2;
        float z = (Random.Range(-10, 10));

        RandomVector = new Vector3(x, y, z);
        Food = Instantiate(Food, RandomVector, Quaternion.identity) as GameObject;
    }

}
