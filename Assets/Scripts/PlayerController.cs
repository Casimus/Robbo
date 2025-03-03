using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 100f;
    [SerializeField] private float liftForce = 1000f;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D _rigidbody;
    private bool jumped = false;
    private bool doubleJumped = false;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (IsOnGround())
        {
            jumped = false;
            doubleJumped = false;
        }
        else
        {
            jumped = true;
        }

        if (Input.GetButtonDown("Jump") && !doubleJumped)
        {
            _rigidbody.velocity = new Vector2(0, jumpForce);

            if (!jumped)
            {
                jumped = true;
            }
            else
            {
                doubleJumped = true;
            }
        }

        if (Input.GetButton("Jump") && _rigidbody.velocity.y < 0)
        {
            _rigidbody.AddForce(new Vector2(0, liftForce * Time.deltaTime));
        }
    }

    private bool IsOnGround()
    {
        float distance = 2.7f;
        var hit = Physics2D.BoxCast(transform.position,
            GetComponent<BoxCollider2D>().bounds.size,
            0f,
            Vector2.down,
            distance,
            groundLayer);

        return hit.collider != null;
    }
}
