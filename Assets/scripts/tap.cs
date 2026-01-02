using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tap : MonoBehaviour
{

    private void Start()
    {
      
            GameObject.Find("Score").GetComponent<Text>().text = "YOUR SCORE: " + PlayerPrefs.GetInt("score",0).ToString();
            GameObject.Find("best").GetComponent<Text>().text = "BEST SCORE: " +  PlayerPrefs.GetInt("best",0).ToString();
        
    }
}
