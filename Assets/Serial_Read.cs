using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using System.IO.Ports; 
using System; 
using System.Globalization;


public class Serial_Read : MonoBehaviour
{
//     SerialPort stream = new SerialPort("COM5", 115200);
//     public static float M1_Ratio = 0.0f; 
//     public static float M2_Ratio = 0.0f; 
//     float flex_sig = 0; 

// // Start is called before the first frame update 
//     void Start() 
//     { 
//     stream.DtrEnable = true; 
//     stream.RtsEnable = true; 
//     stream.Open(); 
//     stream.ReadTimeout = 10000; 
//     } 
//     // Update is called once per frame 
//     void Update()
//     { 
//         if (stream.IsOpen)
//         { 
//             // Debug.Log(stream.ReadLine()); // flex_sig = (float) Convert.ToDouble(stream.ReadLine()); // Debug.Log(flex_sig); 
//             string data = stream.ReadLine(); 
//             // Parse Data Ex. "322 215" 
//             //Debug.Log(data);
//             int splitPos = data.IndexOf('_'); 
//             string M1 = data.Substring(0, splitPos); 
//             string M2 = data.Substring(splitPos + 1); 
//             float floatM1 = 0.0f;
//             float floatM2 = 0.0f;
//            // Debug.Log("[" + M1 + "    " + M2 + "]"); 
//             if (M1 != "" && M2 != ""){
//                 floatM1 = (float) Convert.ToDouble(M1); 
//                 floatM2 = (float) Convert.ToDouble(M2); 
//             }
//             // // float floatM1 = float.Parse(M1, CultureInfo.InvariantCulture.NumberFormat); 
//             // // float floatM2 = float.Parse(M2, CultureInfo.InvariantCulture.NumberFormat); 
//             // // // Compute Ratio 
//             M1_Ratio = floatM1 / (floatM1 + floatM2); 
//             M2_Ratio = floatM2 / (floatM1 + floatM2); 
//             Debug.Log(M1_Ratio + "   " + M2_Ratio);
//         } 
//         else{ 
//             stream.Close(); 
//         } 
//     }
}
