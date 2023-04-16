using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightShip_Movement : MonoBehaviour
{
    public float moveSpeed = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Boundary"){
            transform.position = new Vector3 (transform.position.x, transform.position.y - 1, transform.position.z);
            moveSpeed *= - 1;
        }

        if (collision.gameObject.tag == "Respawn"){
            transform.position = new Vector3 (transform.position.x, transform.position.y + 8, transform.position.z);

        }
    }
}
