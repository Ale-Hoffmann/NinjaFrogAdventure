using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
   public int totalScore;
   public static GameController insta;
   public Text scoreText;
   public Text EndScore;
   public GameObject gameOver;
   public GameObject nextLevel;


   
    void Start()
    {
        insta = this;
    }

     void Update()
    {
        
    }

public void UpdateScoreText()
{
    scoreText.text = totalScore.ToString();
    EndScore.text = totalScore.ToString();
}
public void ShowGameOver()
{
    gameOver.SetActive(true);
    
}
public void RestartGame (string LvlName)
{
    SceneManager.LoadScene(LvlName);
}
public void NextLevel()
{
nextLevel.SetActive(true);
}
public void NextScene(string nxScene)
{
    SceneManager.LoadScene(nxScene);
}

}
