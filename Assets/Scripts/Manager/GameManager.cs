using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float life = 1;
    public int point;
    private int pointToLife;
    public bool inPause = false;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject shield;
    [SerializeField] private GameObject gameScreen;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject dieScreen;
    [SerializeField] private TextMeshProUGUI scoreTextInGame;
    [SerializeField] private TextMeshProUGUI scoreTextInPause;
    [SerializeField] private TextMeshProUGUI scoreTextInDie;

    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
    }
    
    private void Start()
    {
        dieScreen.SetActive(false);
        pauseScreen.SetActive(false);
        gameScreen.SetActive(true);
    }
    
    public void AddPoint(int i = 50)
    {
        point += i;
        pointToLife += i;
        if (pointToLife >= 2000)
        {
            pointToLife -= 2000;
            life += 1;
        }
        scoreTextInGame.text = "Score : " + point + "\n" + "Life : " + life;
    }
    
    public void LoseLife()
    {
        life -= 1;
        if (life == 0)
        {
            scoreTextInGame.text = "Score : " + point + "\n" + "Life : " + life;
            scoreTextInDie.text = "Score : " + point;
            Destroy(player);
            gameScreen.SetActive(false);
            dieScreen.SetActive(true);
        }
        else
        {
            scoreTextInGame.text = "Score : " + point + "\n" + "Life : " + life;
        }
    }

    public void GoNextLevel()
    {
        int n = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(n + 1);
    }
    
    public void RestartLevel()
    {
        Time.timeScale = 1;
        int n = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(n);
    }
    
    public void MenuLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    
    public void PauseGame()
    {
        scoreTextInPause.text = "Score : " + point;
        inPause = true;
        Time.timeScale = 0;
        gameScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }
    
    public void UnPauseGame()
    {
        inPause = false;
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        gameScreen.SetActive(true);
    }
}