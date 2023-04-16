using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;




public class Movement : MonoBehaviour
{
    public float MoveSpeed = 3;
    public float hInput;
    public float shipBoundaryRadius = 0.5f;
    static public float LeftKeyCount = 0.0f;
    static public float RightKeyCount = 0.0f;
    static public float leftTime = 0f; // track time when left arrow key is pressed
    static public float rightTime = 0f; // track time when right arrow key is pressed
    // Start is called before the first frame update

    // Serial_Read EMG_Sig;
    static float leftTimeDown = 0.0f;
    static float rightTimeDown = 0.0f;
    float count = 0.0f;
    bool LeftActivate = false;
    bool rightActivate = false;
    // static float duration = 0.0f;
    public float activate = 0.0f;
    void Start()
    {
        // EMG_Sig = GameObject.Find("Serial_Read").GetComponent<Serial_Read>();
    }

    // Update is called once per frame
    void Update()
    {
        // Establish Ratio
        // float M2 = Serial_Read.M1_Ratio;
        // float M1 = Serial_Read.M2_Ratio;

        // if (M1 > 0.5 && M2 < 0.5){
        //     activate = -1;
        // } 
        // else if (M1 < 0.5 && M2 > 0.5){
        //     activate = 1;
        // }
        // else {
        //     activate = 0;
        // }
        // count += 1;
        // if (count % 5 != 0){
        //     string filePath = "C:/CV_Development/Pose_estimation_Hand/yolov5/lm_hand.txt";
        //     StreamReader reader = new StreamReader(filePath);
        //     string data = reader.ReadLine();
        //     Debug.Log(data);
        //     reader.Close();
        // }

         // Establishing Horizontal player ship movement

        MoveSpeed = SliderValue.moveSpeedVal;
        Vector3 pos = transform.position;
        //pos.x += activate * MoveSpeed * Time.deltaTime;
        pos.x += Input.GetAxis("Horizontal") * MoveSpeed * Time.deltaTime;
        transform.position = pos;
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float widthOrtho = Camera.main.orthographicSize * screenRatio;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            leftTimeDown = Time.time; // add start time of left key press to the list
            LeftActivate = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) && LeftActivate)
        {
            float duration = Time.time - leftTimeDown; // calculate duration of the last left key press
            Debug.Log("Duration of last left press: " + duration);
            leftTime += duration;
            LeftKeyCount += 1;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rightActivate =true;
            rightTimeDown = Time.time; // add start time of right key press to the list
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) && rightActivate)
        {
            float duration = Time.time - rightTimeDown; // calculate duration of the last right key press
            Debug.Log("Duration of last right press: " + duration);
            rightTime += duration;
            RightKeyCount += 1;
        }

        //  if (activate == -1)
        // {
        //     leftTimeDown = Time.time; // add start time of left key press to the list
        //     LeftActivate = true;
        // }

        // if (activate != -1 && LeftActivate)
        // {
        //     float duration = Time.time - leftTimeDown; // calculate duration of the last left key press
        //     Debug.Log("Duration of last left press: " + duration);
        //     leftTime += duration;
        //     LeftActivate = false;
        //     LeftKeyCount += 1;
        // }
        // if (activate == 1)
        // {
        //     rightActivate =true;
        //     rightTimeDown = Time.time; // add start time of right key press to the list
        // }
        // if (activate != 1 && rightActivate)
        // {
        //     float duration = Time.time - rightTimeDown; // calculate duration of the last right key press
        //     Debug.Log("Duration of last right press: " + duration);
        //     rightActivate = false;
        //     rightTime += duration;
        //     RightKeyCount += 1;
        // }

        // If player moves past horizontal screen bounds, the player ship position will reset to the center    
        if(pos.x + shipBoundaryRadius > widthOrtho) {
        pos.x = 0;
    
        }
        if(pos.x - shipBoundaryRadius < -widthOrtho) {
        pos.x = 0;
        }

        transform.position = pos;


        // For Rotation
       // transform.Translate(Vector2.up * Input.GetAxisRaw("Vertical") * MoveSpeed * Time.deltaTime);

        // Rotation
        // Quaternion pos = transform.rotation;
        // float z = pos.eulerAngles.z;
        // z -= hInput * MoveSpeed * Time.deltaTime;
        // pos = Quaternion.Euler(0,0,z);
        // transform.rotation = pos;

        

        
    }
}
