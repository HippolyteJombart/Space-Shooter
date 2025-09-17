using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float life = 1;
    private int point;
    private int pointToLife;
    public bool inPause = false;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject gameScreen;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private GameObject dieScreen;
    [SerializeField] TextMeshProUGUI scoreTextInGame;
    [SerializeField] TextMeshProUGUI scoreTextInPause;
    [SerializeField] TextMeshProUGUI scoreTextInDie;

    void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
    }
    void Start()
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
        scoreTextInGame.text = "Score : " + point.ToString() + "\n" + "Life : " + life.ToString();
    }
    public void LoseLife()
    {
        life -= 1;
        if (life == 0)
        {
            scoreTextInDie.text = "Score : " + point.ToString();
            Destroy(player);
            dieScreen.SetActive(true);
        }
        else
        {
            scoreTextInGame.text = "Score : " + point.ToString() + "\n" + "Life : " + life.ToString();            
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
        scoreTextInPause.text = "Score : " + point.ToString();
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