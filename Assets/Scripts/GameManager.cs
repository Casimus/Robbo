using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private const string COIN_KEY = "Coins";

    [SerializeField] private float worldSpeed = 0.2f;
    [SerializeField] private Button resetButton;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI coinText;

    private float score = 0;
    private int coins = 0;
    bool isAlive = true;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("There is more than one GameManager in the scene");
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        resetButton.gameObject.SetActive(false);
        score = 0;
        coins = PlayerPrefs.GetInt(COIN_KEY, 0);
        CoinsUpdate();
        isAlive = true;
    }

    private void Update()
    {
        if (isAlive)
        {
            score += Time.deltaTime;
            scoreText.text = $"Score: {score:F0}";
        }
    }

    private void CoinsUpdate()
    {
        coinText.text = coins.ToString();
    }

    public void AddCoin()
    {
        coins++;
        PlayerPrefs.SetInt(COIN_KEY, coins);
        CoinsUpdate();
    }

    public void SetAlive(bool alive)
    {
        isAlive = alive;
    }

    public void ShowButton()
    {
        resetButton.gameObject.SetActive(true);
    }

    public float GetWorldSpeed() => worldSpeed;
    
    public void SetWorldSpeed(float speed)
    {
        worldSpeed = speed;
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
