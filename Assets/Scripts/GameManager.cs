using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private float worldSpeed = 0.2f;
    [SerializeField] private Button resetButton;
    [SerializeField] private TextMeshProUGUI scoreText;
    
    private float score = 0;
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
