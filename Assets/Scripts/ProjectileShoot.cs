using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShoot : MonoBehaviour
{
    public GameObject projectileObj;
    public float shootingrate = 1000;
    private float timestamp = 0.0f;
    public float waitTime = .4f;
    public float destroyAfter = 5f;
    bool readyToShoot = false;
    // Start is called before the first frame update
    void Start()
    {
        waitTime = .5f;
        StartCoroutine(WaitBetweenShots());
    }

    private IEnumerator Spawn(){
        while (true)
        {
            projectileObj = Instantiate(projectileObj, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(waitTime);
        }
    }

    private IEnumerator WaitBetweenShots(){
        while (true){
            if (readyToShoot){
                Instantiate(projectileObj, transform.position, Quaternion.identity);
                readyToShoot = false;
            }
            yield return new WaitForSeconds(waitTime);
            readyToShoot = true;
        }
    }




    // Update is called once per frame
    void Update()
    {
        // timestamp += Time.deltaTime;
        // while (readyToShoot == true){
        //     Instantiate(projectileObj, transform.position, Quaternion.identity);
        //     readyToShoot = false;
        //  }
        
    }
}
