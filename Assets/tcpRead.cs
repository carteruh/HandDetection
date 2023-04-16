using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEditor;
using System.IO;


public class tcpRead : MonoBehaviour
{

    // void Start(){
    //     RunEnsureNaming();
    // }
    // [MenuItem("Python/Ensure Naming")]
    // static void RunEnsureNaming()
    // {
    //     string scriptPath = Path.Combine(Application.dataPath,"ensure_naming.py");
    //     PythonRunner.RunFile(scriptPath);
    // }
//     Thread thread;
//     public int connectionPort = 135;
//     TcpListener server;
//     TcpClient client;
//     bool running;
//     static string dataReceived = "";
//     void Start(){
//         ThreadStart ts = new ThreadStart(GetData);
//         thread = new Thread(ts);
//         thread.Start();
//     }

//     void GetData(){
//         // Create the Server
//         server = new TcpListener(IPAddress.Any, connectionPort);
//         server.Start();

//         // Create a client
//         client = server.AcceptTcpClient();

//         // Start Listening
//         running = true;
//         while (running){
//             Connection();
//         }
//         server.Stop();
//     }

//     void Connection(){

//         // Read data from the network stream
//         NetworkStream nwStream = client.GetStream();
//         byte[] buffer = new byte[client.ReceiveBufferSize];
//         int bytesRead = nwStream.Read(buffer, 0, client.ReceiveBufferSize);

//         // Decode the Bytes into string
//         dataReceived = Encoding.UTF8.GetString(buffer, 0, bytesRead);
//         Debug.Log(dataReceived);
//         // if (dataReceived != null && dataReceived != ""){

//         //     nwStream.Write(buffer, 0, bytesRead);
//         // }
//     }
//     int count = 0;
//     void Update(){
     
//     }
}
