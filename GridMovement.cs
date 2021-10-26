using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMovement : MonoBehaviour
{
    public bool isMoving;
    public GameObject bulletPrefab;

    private Vector3 origPos, targetPos, playerPosition, lilyPosition, enemyPosition;
    private Vector3 HorizMove = new Vector3(0,0,4);
    private Vector3 VertMove = new Vector3(5, 0, 0);
    private float timeToMove = 0.5f;
    

    // Update is called once per frame
    void Update()
    {
        

        // When mouse is clicked, cast a ray to determin what was clicked
        if(Input.GetMouseButtonDown(0))
        {
            playerPosition = transform.position;
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 20.0f))
            {
                Debug.DrawLine(ray.origin, hit.point);//I can also see that the rays work, awesome.

                // If ray cast hits a lilypad
                if(hit.collider.tag == "LilyPad")
                {
                    Debug.Log(hit.collider.name);
                    lilyPosition = hit.transform.position;

                    //This if statement is making sure that movement is vertical/horizontal only
                    //It also keeps the player jumping only to adjuscent boxes
                    // Change for more dynamic code later
                    if ((lilyPosition.x -playerPosition.x) < 5.1 && !isMoving && lilyPosition.z == playerPosition.z)
                    {
                        StartCoroutine(MovePlayer(lilyPosition-playerPosition));
                    }

                    if ((lilyPosition.z -playerPosition.z)< 4.1 && !isMoving && lilyPosition.x == playerPosition.x)
                    {
                        StartCoroutine(MovePlayer(lilyPosition-playerPosition));
                    }
                }else if (hit.collider.tag == "Finish")
                {
                    Debug.Log(hit.collider.name);
                    targetPos = hit.transform.position;
                    StartCoroutine(MovePlayer(targetPos - playerPosition));
                    GameManager.FindObjectOfType<GameManager>().GameComplete();


                }
                   
            }




        }

    }


     public IEnumerator MovePlayer (Vector3 direction)
    {
        isMoving = true;

        float elapsedTime = 0 ;

        origPos = transform.position;
        targetPos = origPos + direction;

        while(elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(origPos, targetPos, (elapsedTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }


   
}
