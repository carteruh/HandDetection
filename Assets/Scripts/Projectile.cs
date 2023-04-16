using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Projectile : MonoBehaviour
{
    public float moveSpeed = 3;
    public GameObject explosionPrefab;
    private Points pointManager;
    private Finish finishObj;
    public float enemiesRemaining;
    // Start is called before the first frame update
    void Start()
    {
        finishObj = GameObject.Find("Finish").GetComponent<Finish>();
        pointManager = GameObject.Find("Points").GetComponent<Points>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);

    }

    private void  OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Enemies"){
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            pointManager.UpdateScore(1);
            enemiesRemaining = finishObj.UpdateEnemyCount(1);
            Destroy(collision.gameObject);
            Destroy(gameObject);

            if (enemiesRemaining == 0){
                finishObj.CompleteLevel();
            }
        }

        if (collision.gameObject.tag == "Boundary"){
            Destroy(gameObject);
        }
    }
}
