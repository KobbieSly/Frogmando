using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoward : MonoBehaviour
{
    private float speed = 3f;
    private bool rightside;

    private void Start()
    {
        if (transform.position.z < -7)
        {

            rightside = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        GoFoward();

        if (transform.position.z < -15 || transform.position.z > 15)
        {
            Destroy(gameObject);
        }
    }

    void GoFoward()
    {
        if (!rightside)
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        } else
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        


        
    }
}
