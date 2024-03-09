using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    
    //file paths
        const string FILE_DIR = "/SAVE_DATA/";

        const string C1_DATA_FILE = "cube1highscores.txt";

        const string C2_DATA_FILE = "cube2highscores.txt";

        const string C3_DATA_FILE = "cube3highscores.txt";

        string FILE_C1_PATH;

        string FILE_C2_PATH;

        string FILE_C3_PATH;
    
    //these three are constrained to this script and are the main variable
        private int cube1Score; //pink cube

        private int cube2Score; //purple cube

        private int cube3Score; //blue cube

        private int totalScore; //all scores together
        
    //ints for high scores slot - constrained to this script
        public int c1highScoreSlot;

        public int c2highScoreSlot;

        public int c3highScoreSlot;

    //lists of high scores
        public List<int> c1highScores;

        public List<int> c2highScores;

        public List<int> c3highScores;

    //empty strings for high scores
        string c1highScoresString = "";

        string c2highScoresString = "";

        string c3highScoresString = "";
    
    //write high scores to files - singletons
        public List<int> c1HighScores
        {
            get
            {
                if (c1highScores == null)
                {
                    c1highScores = new List<int>(); 
                    //creates list if one does not already exist

                    c1highScoresString = File.ReadAllText(FILE_C1_PATH);
                    //pulls high scores from file

                    c1highScoresString = c1highScoresString.Trim();
                    //gets rid of extra white space

                    string[] c1highScoreArray = c1highScoresString.Split("\n");
                    //split the string at every line break

                    for (int i = 0; i < c1highScoreArray.Length; i++)
                    {
                        int c1currentScore = Int32.Parse(c1highScoreArray[i]);
                        //converts string into int

                        c1highScores.Add(c1currentScore);
                        //add cube 1 score to high scores list
                    }
                }

                return c1highScores;
            }
        }
        
        public List<int> c2HighScores
        {
            get
            {
                if (c2highScores == null)
                {
                    c2highScores = new List<int>(); 
                    //creates list if one does not already exist

                    c2highScoresString = File.ReadAllText(FILE_C2_PATH);
                    //pulls high scores from file

                    c2highScoresString = c2highScoresString.Trim();
                    //gets rid of extra white space

                    string[] c2highScoreArray = c2highScoresString.Split("\n");
                    //split the string at every line break

                    for (int i = 0; i < c2highScoreArray.Length; i++)
                    {
                        int c2currentScore = Int32.Parse(c2highScoreArray[i]);
                        //converts string into int

                        c1highScores.Add(c2currentScore);
                        //add cube 1 score to high scores list
                    }
                }

                return c2highScores;
            }
        }
        
        public List<int> c3HighScores
        {
            get
            {
                if (c3highScores == null)
                {
                    c3highScores = new List<int>(); 
                    //creates list if one does not already exist

                    c3highScoresString = File.ReadAllText(FILE_C3_PATH);
                    //pulls high scores from file

                    c3highScoresString = c3highScoresString.Trim();
                    //gets rid of extra white space

                    string[] c3highScoreArray = c3highScoresString.Split("\n");
                    //split the string at every line break

                    for (int i = 0; i < c3highScoreArray.Length; i++)
                    {
                        int c3currentScore = Int32.Parse(c3highScoreArray[i]);
                        //converts string into int

                        c3highScores.Add(c3currentScore);
                        //add cube 1 score to high scores list
                    }
                }

                return c3highScores;
            }
        }

    //these three are accessible by other scripts - gets and sets based on private equivalents here
        public int Cube1Score
        {
            get
            {
                return cube1Score;
            }
            set
            {
                cube1Score = value;
                
                if (C1isHighScore(cube1Score))
                {
                    int c1highScoreSlot = -1;

                    for (int i = 0; i < c1HighScores.Count; i++)
                    {
                        c1highScoreSlot = i;

                        break;
                    }
                }
                
                c1highScores.Insert(c1highScoreSlot, cube1Score);

                c1highScores = c1highScores.GetRange(0, 1);

                string c1highScoreText = "";

                foreach (var c1HighScore in c1highScores)
                {
                    c1highScoreText += c1HighScore;
                }

                c1highScoresString = c1highScoreText;
                
                File.WriteAllText(FILE_C1_PATH, c1highScoresString);
            }
        }

        public int Cube2Score
        {
            get
            {
                return cube2Score;
            }
            set
            {
                cube2Score = value;

                if (C2isHighScore(cube2Score))
                {
                    int c2highScoreSlot = -1;

                    for (int i = 0; i < c2HighScores.Count; i++)
                    {
                        c2highScoreSlot = i;

                        break;
                    }
                }
                
                c2highScores.Insert(c2highScoreSlot, cube2Score);

                c2highScores = c2highScores.GetRange(0, 1);

                string c2highScoreText = "";

                foreach (var c2HighScore in c2highScores)
                {
                    c2highScoreText += c2HighScore;
                }

                c2highScoresString = c2highScoreText;
                
                File.WriteAllText(FILE_C2_PATH, c2highScoresString);
            }
        }

        public int Cube3Score
        {
            get
            {
                return cube3Score;
            }
            set
            {
                cube3Score = value;

                if (C3isHighScore(cube3Score))
                {
                    int c3highScoreSlot = -1;

                    for (int i = 0; i < c3HighScores.Count; i++)
                    {
                        c3highScoreSlot = i;

                        break;
                    }
                }
                
                c3highScores.Insert(c3highScoreSlot, cube3Score);

                c3highScores = c3highScores.GetRange(0, 1);

                string c3highScoreText = "";

                foreach (var c3HighScore in c3highScores)
                {
                    c3highScoreText += c3HighScore;
                }

                c3highScoresString = c3highScoreText;
                
                File.WriteAllText(FILE_C3_PATH, c3highScoresString);
            }
        }

    //timer
        float timer = 0;
        
        float maxTime = 10;
        
        bool isInGame = true;
        
    //text
        public TextMeshProUGUI c1display;

        public TextMeshProUGUI c2display;

        public TextMeshProUGUI c3display;

        public TextMeshProUGUI timerdisplay;

    private void Awake()
    {
        if (instance == null) //singleton
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        //file locations
        FILE_C1_PATH = Application.dataPath + FILE_DIR + C1_DATA_FILE;
        FILE_C2_PATH = Application.dataPath + FILE_DIR + C2_DATA_FILE;
        FILE_C3_PATH = Application.dataPath + FILE_DIR + C3_DATA_FILE;
        
        //default cube scores
        Cube1Score = 0;
        Cube2Score = 0;
        Cube3Score = 0;
        
        //total score
        totalScore = cube1Score + cube2Score + cube3Score;

    }

    // Update is called once per frame
    void Update()
    {

        if (isInGame)
        {
            timerdisplay.text = "time: " + (maxTime - (int)timer);
            //counts down from timer + makes whole number
            
            //strings for cubes and scores
            c1display.text = "pink cubes: " + cube1Score;
            c2display.text = "purple cubes: " + cube2Score;
            c3display.text = "blue cubes: " + cube3Score;
        }
        else
        {
            timerdisplay.text = "game over!" + "\ntotal cubes: " + totalScore;
            
            c1display.text = "pink high score: " + c1highScoresString;
            c2display.text = "purple high score: " + c2highScoresString;
            c3display.text = "blue high score: " + c3highScoresString;
        }

        timer += Time.deltaTime; 
        //add fraction of second in between frame to time

        if (timer >= maxTime && isInGame) 
            //if timer finishes
        {
            isInGame = false;
            //SceneManager.LoadScene("EndScene");
        }

    }

    bool C1isHighScore(int cube1Score)
    {
        bool result = false;
        
        for (int i = 0; i < c1HighScores.Count; i++)
        {
            if (c1highScores[i] < cube1Score)
            {
                return true;
                //this is a high score
            }
        }

        return false;
        //this is not a high score
    }

    bool C2isHighScore(int cube2Score)
    {
        bool result = false;

        for (int i = 0; i < c2HighScores.Count; i++)
        {
            if (c2highScores[i] < cube2Score)
            {
                return true;
                //this is a high score
            }
        }

        return false;
        //this is not a high score
    }

    bool C3isHighScore(int cube3Score)
    {
        bool result = false;

        for (int i = 0; i < c3HighScores.Count; i++)
        {
            if (c2highScores[i] < cube3Score)
            {
                return true;
                //this is a high score
            }
        }

        return false;
        //this is not a high score
    }
}
