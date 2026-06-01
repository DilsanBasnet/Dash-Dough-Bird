using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameManager : MonoBehaviour
{
 private int Score;
 public player player;
 public TextMeshProUGUI scoretext;
 public GameObject PlayButton;
 public GameObject GameOver;
    public void Awake() {
        Application.targetFrameRate = 60;
        Pause();
    }
    public void Play() {
        Score = 0;
        scoretext.text = Score.ToString();

        PlayButton.SetActive(false);
        GameOver.SetActive(false);
        Time.timeScale = 1f;
        player.enabled = true;
        Pipes[] pipes = FindObjectsByType<Pipes>();
        for(int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }

    }
    public void Pause()
    {
       Time.timeScale = 0f; 
       player.enabled = false;
    }
    public void Gameover() {
        GameOver.SetActive(true);
        PlayButton.SetActive(true);
        Pause();

        Debug.Log("Game Over");
    }

public void ScoreIncrease()
    {
        Score++;
        scoretext.text = " SCORE : " + Score.ToString();
    }
}
