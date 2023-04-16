using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class PlayerLives : MonoBehaviour
{
    public int lives = 3;
    public Image[] livesUI;
    public GameObject explosionPrefab;
    private Finish finishObj;
    public float enemiesRemaining;
    // Start is called before the first frame update
    void Start()
    {
        finishObj = GameObject.Find("Finish").GetComponent<Finish>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.collider.gameObject.tag == "Enemies"){
            lives --;
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(collision.collider.gameObject);
            for (int i = 0; i < livesUI.Length; i++){
                if (i < lives){
                    livesUI[i].enabled = true;
                }
                else{
                    livesUI[i].enabled = false;
                }
            }
            if (lives <= 0){
                string filePath = "C:/Unity_Project/Galaga_EMG/Assets/output.csv";
                StreamWriter writer = new StreamWriter(filePath);
                writer.WriteLine("Flexor Activation Time, Extensor Activation Time, Flexor Average Time, Extensor Average Time");
                writer.Write(Movement.leftTime + "," + Movement.rightTime + ","  + (Movement.leftTime / Movement.LeftKeyCount) + "," + (Movement.rightTime / Movement.RightKeyCount));
                writer.Close();
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Enemy_Projectile"){
            lives --;
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            for (int i = 0; i < livesUI.Length; i++){
                if (i < lives){
                    livesUI[i].enabled = true;
                }
                else{
                    livesUI[i].enabled = false;
                }
            }
            if (lives <= 0){
                Destroy(gameObject);

                string filePath = "C:/Unity_Project/Galaga_EMG/Assets/output.csv";
                StreamWriter writer = new StreamWriter(filePath);
                writer.WriteLine("Flexor Activation Time, Extensor Activation Time, Flexor Average Time, Extensor Average Time");
                writer.Write(Movement.leftTime + "," + Movement.rightTime + ","  + (Movement.leftTime / Movement.LeftKeyCount) + "," + (Movement.rightTime / Movement.RightKeyCount));
                writer.Close();
                SceneManager.LoadScene("Main_Menu");
            }
        }

        if (collision.gameObject.tag == "Enemies"){
            lives --;
            enemiesRemaining = finishObj.UpdateEnemyCount(1);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            for (int i = 0; i < livesUI.Length; i++){
                if (i < lives){
                    livesUI[i].enabled = true;
                }
                else{
                    livesUI[i].enabled = false;
                }
            }

            if (enemiesRemaining == 0){
                finishObj.CompleteLevel();
            }
            if (lives <= 0){
                Destroy(gameObject);

                string filePath = "C:/Unity_Project/Galaga_EMG/Assets/output.csv";
                StreamWriter writer = new StreamWriter(filePath);
                writer.WriteLine("Flexor Activation Time, Extensor Activation Time, Flexor Average Time, Extensor Average Time");
                writer.Write(Movement.leftTime + "," + Movement.rightTime + ","  + (Movement.leftTime / Movement.LeftKeyCount) + "," + (Movement.rightTime / Movement.RightKeyCount));
                writer.Close();
                SceneManager.LoadScene("Main_Menu");
            }
        }
    }
    
}
