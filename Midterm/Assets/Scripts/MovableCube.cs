using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using System.IO;
using UnityEngine;
using Input = UnityEngine.Input;

public class MovableCube : MonoBehaviour
{
    const string FILE_DIR = "/SAVE_DATA/";

    string FILE_NAME = "<name>.json";

    string FILE_PATH;
    
    // Start is called before the first frame update
    void Start()
    {
        FILE_NAME = FILE_NAME.Replace("<name>", name); 
        //replaces placeholder with variable (file name)

        FILE_PATH = Application.dataPath + FILE_DIR + FILE_NAME;
        //determine where file will be saved

        if (File.Exists(FILE_PATH))
            //if file exists
        {
            string jsonStr = File.ReadAllText(FILE_PATH);
            //read all text in file

            JsonUtility.FromJson<Vector3>(jsonStr);
            //turn ddata into vector3

            transform.position = JsonUtility.FromJson<Vector3>(jsonStr);
            //set positions based on vector3 data
        }
    }

    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition();
    }

    Vector3 GetMouseWorldPosition()
    {
        Vector3 result = Input.mousePosition; 
        //pulls mouse position

        result.z = Camera.main.WorldToScreenPoint(transform.position).z;
        //where is spot on screen, prevents depth change in 3d

        result = Camera.main.ScreenToWorldPoint(result);
        //where is screen spot in world

        return result;
    }
    
    void OnApplicationQuit()
    {
        string fileContent = JsonUtility.ToJson(transform.position, true);
        //grab transform.position data
        
        Debug.Log(fileContent);
        
        File.WriteAllText(FILE_PATH, fileContent);
        //write data to specified path
    }
}
