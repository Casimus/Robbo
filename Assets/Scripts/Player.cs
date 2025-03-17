using UnityEngine;


public class Player : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle" &&
            !GameManager.Instance.immortality.isActive)
        {
            GameOver();
        }
        else if (collision.gameObject.tag == "Coin")
        {
            GameManager.Instance.AddCoin();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Immortal")
        {
            GameManager.Instance.ImmortalityCollected();
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.tag == "Magnet")
        {
            GameManager.Instance.MagnetCollected();
            Destroy(collision.gameObject);
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
