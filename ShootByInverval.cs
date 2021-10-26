using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootByInverval : MonoBehaviour
{
    
    private float shootingInterval =3f;


    public GameObject bullet;
    public bool isShooting;


    // Update is called once per frame
    void Update()
    {
        if (!isShooting)
        {
            StartCoroutine(Shootbullet());
        }
    }


    private IEnumerator Shootbullet()
    {
        isShooting = true;
        
        GameObject shotBullet = Instantiate(bullet, transform.position , transform.rotation);
            
         
        yield return new WaitForSeconds(shootingInterval);

        isShooting = false;
    }

}
