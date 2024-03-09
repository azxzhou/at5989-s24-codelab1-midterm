using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ASCIILevelLoader : MonoBehaviour
{
    int currentLevel = 0;

    GameObject level;

    public int CurrentLevel
    {
        get
        {
            return currentLevel;
        }
        set
        {
            currentLevel = value;

            LoadLevel();
        }
    }

    string FILE_PATH;

    public static ASCIILevelLoader instance;
    
    // Start is called before the first frame update
    void Start()
    {
        FILE_PATH = Application.dataPath + "/Levels/LevelNum.txt";

        LoadLevel();
    }

    void LoadLevel()
    {
        Destroy(level);

        level = new GameObject("Level Objects");

        string[] lines = File.ReadAllLines(FILE_PATH.Replace("Num", currentLevel + ""));
        //read all lines in specified file

        for (int yLevelPos = 0; yLevelPos < lines.Length; yLevelPos++)
        {
            string line = lines[yLevelPos].ToUpper(); 
            //make single string

            char[] characters = line.ToCharArray();

            for (int xLevelPos = 0; xLevelPos < characters.Length; xLevelPos++)
            {
                char c = characters[xLevelPos];

                GameObject newObject = null;

                switch (c) //check if any are true and if so do listed thing
                {
                    case 'P': //pink cube
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/PinkCube"));
                        break;
                    
                    case 'U': //purple cube
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/PurpleCube"));
                        break;
                    
                    case 'B': //blue cube
                        newObject = Instantiate(Resources.Load<GameObject>("Prefabs/BlueCube"));
                        break;

                    default:
                        break;
                }

                if (newObject != null)
                {
                    newObject.transform.parent = level.transform;

                    newObject.transform.position = new Vector3(xLevelPos, -yLevelPos, 0);
                }
            }
        }
    }
}
