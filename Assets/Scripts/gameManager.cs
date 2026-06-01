using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameManager : MonoBehaviour
{
 private int Score;
 private int highScore;
 private int diamonds;

//increasing speed bruh making hard
  public float Startspeed = 5f;
  public float speedincrease = 1.2f;
  public int scorestep = 3;
 public player player;
 public TextMeshProUGUI scoretext;
 public TextMeshProUGUI diamondText;
 public TextMeshProUGUI highScoreText;
 public GameObject PlayButton;
 public GameObject GameOver;
 public GameObject ExitButton;
    public void Awake() {
        Application.targetFrameRate = 60;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        updateHighscore();
        Pause();
    }
    public void Play() {
        Score = 0;
        diamonds = 0;
        Pipes.speed = Startspeed;
        scoretext.text = "SCORE : " + Score.ToString();
        diamondText.text = "DIAMOND : " + diamonds.ToString();
       updateHighscore();
        PlayButton.SetActive(false);
        GameOver.SetActive(false);
        ExitButton.SetActive(false);

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
        ExitButton.SetActive(true);
    
        Pause();

        Debug.Log("Game Over");
    }

public void ScoreIncrease()
    {
        Score++;
        scoretext.text = " SCORE : " + Score.ToString();

        if(Score > highScore)
        {
            highScore = Score;
            PlayerPrefs.SetInt("HighScore", highScore);
            PlayerPrefs.Save();
            updateHighscore();
        }

        if (Score % scorestep == 0) {
            Pipes.speed += speedincrease;
            Debug.Log("speed increased" + Pipes.speed);
            spawner levelSpawner = FindAnyObjectByType<spawner>();
            
            if(levelSpawner != null)
            {
                levelSpawner.UpdateSpawnRate();
            }
        }

    }
    private void updateHighscore()
    {
        highScoreText.text = "BEST SCORE : " + highScore.ToString();
    }
    public void IncreaseDiamond()
    {
        diamonds++;
        diamondText.text = "DIAMOND : " + diamonds.ToString();
    }
    public void QuitGame()
    {
      Application.Quit();
      Debug.Log("Game Quit");  
    }}