using UnityEngine;

public class gameManager : MonoBehaviour
{
 private int Score;
 private void Gameover()
    {
       Debug.Log("Game Over");
    }

private void ScoreIncrease()
    {
        Score++;
    }
}
