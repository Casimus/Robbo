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

    public Immortality immortality;
    public Magnet magnet;


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
        immortality.isActive = false;
        magnet.isActive = false;
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

    public void ImmortalityCollected()
    {
        if (immortality.isActive)
        {
            CancelInvoke(nameof(CancelImmortality));
            CancelImmortality();
        }


        immortality.isActive = true;
        worldSpeed += immortality.GetSpeedBoost();
        Invoke(nameof(CancelImmortality), immortality.GetDuration());
    }

    private void CancelImmortality()
    {
        worldSpeed -= immortality.GetSpeedBoost();
        immortality.isActive = false;
    }

    public void MagnetCollected()
    {
        if (magnet.isActive)
        {
            CancelInvoke(nameof(CancelMagnet));
            CancelMagnet();
        }

        magnet.isActive = true;
        Invoke(nameof(CancelMagnet), magnet.GetDuration());

    }

    private void CancelMagnet()
    {
        magnet.isActive = false;
    }
}
