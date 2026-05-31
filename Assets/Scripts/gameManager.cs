using UnityEngine;

public class gameManager : MonoBehaviour
{
 private int Score;
 public void Gameover()
    {
       Debug.Log("Game Over");
    }

public void ScoreIncrease()
    {
        Score++;
    }
}
