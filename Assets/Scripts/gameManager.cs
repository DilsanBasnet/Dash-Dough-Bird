using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour
{
 private int Score;
 public player player;
 public Text scoretext;
 public GameObject PlayButton;
 public GameObject GameOver;
 public void Gameover()
    {
       Debug.Log("Game Over");
    }

public void ScoreIncrease()
    {
        Score++;
    }
}
