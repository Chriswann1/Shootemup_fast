using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameplayManager : MonoBehaviour
{
    public static GameplayManager Instance;

    public Text lifeTxt;
    public GameObject Player;
    public Text scoreTxt;
    public float Score = 0;
    public bool heal = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Player != null)
        {
            lifeTxt.text = "Life:" + Player.GetComponent<Player>().healthPts;
            scoreTxt.text = Score.ToString();
        }
        if (Score <= 0)
        {
            Score = 0;
        }
        if (Player.GetComponent<Player>().healthPts > 99)
        {
            lifeTxt.text = "Life:99+";
        }

        if (Score >= 1000 && heal == true) 
        {
            Player.GetComponent<Player>().healthPts += 5;
            heal = false;
        }    
    }
}
