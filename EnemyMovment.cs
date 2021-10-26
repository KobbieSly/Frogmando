using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    private bool leftSide;
    private bool rightSide;
    private float travelTime;
    private float speed = 5;

    private Vector3 direction;
    private float elapsedTime ;

    private void Start()
    {
        travelTime = Random.Range(0.3f, 1.5f);
        rightSide = true;
        leftSide = false;
        elapsedTime = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (rightSide)
        {

            Patrole(Vector3.right, rightSide);

        }
        else if (leftSide)
        {

            Patrole (Vector3.left , leftSide);

        }
    }


    private void Patrole(Vector3 direction, bool turn)
    {

        
        transform.Translate(direction * speed * Time.deltaTime);
        elapsedTime += Time.deltaTime;

        if (elapsedTime > travelTime)
        {
            if (turn = rightSide)
            {
                rightSide = false;
                leftSide = true;
                elapsedTime = 0;
            }
            else
            {
                rightSide = true;
                leftSide = false;
                elapsedTime = 0;
            }
        }
    }

}