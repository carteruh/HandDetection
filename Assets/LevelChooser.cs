using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class LevelChooser : MonoBehaviour
{
    public void PlayLevelOne(){
        SceneManager.LoadScene("Level_1");
    }
    
    public void PlayLevelTwo(){
        SceneManager.LoadScene("Level_2");
    }

    public void PlayLevelThree(){
        SceneManager.LoadScene("Level_3");
    }

    public void Quit(){
        Debug.Log("Exiting Game!");
        string filePath = "C:/Unity_Project/Galaga_EMG/Assets/output.csv";
        StreamWriter writer = new StreamWriter(filePath);
        writer.WriteLine("Flexor Activation Time, Extensor Activation Time, Flexor Average Time, Extensor Average Time");
        writer.Write(Movement.leftTime + "," + Movement.rightTime + ","  + (Movement.leftTime / Movement.LeftKeyCount) + "," + (Movement.rightTime / Movement.RightKeyCount));
        writer.Close();
        Application.Quit();
    }
}
