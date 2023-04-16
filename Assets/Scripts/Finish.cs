using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public float enemies = 6;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float UpdateEnemyCount(float loss){
        enemies -= loss;
        return enemies;
    }
    public void CompleteLevel(){
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene("Main_Menu");
    }
}
