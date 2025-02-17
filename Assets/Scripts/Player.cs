using UnityEngine;


public class Player : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle")
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        SetGameOverUI();
        GetComponent<PlayerController>().enabled = false;
        SetGameOverRigidbody();
    }

    private void SetGameOverRigidbody()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        rb.gravityScale = 0;
    }

    private static void SetGameOverUI()
    {
        GameManager.Instance.SetWorldSpeed(0);
        GameManager.Instance.ShowButton();
        GameManager.Instance.SetAlive(false);
    }
}
