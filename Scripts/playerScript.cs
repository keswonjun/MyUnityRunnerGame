using UnityEngine;
using UnityEngine.InputSystem;
using TMPro; // подключаем TextMeshPro

public class playerScript : MonoBehaviour
{
    public float JumpForce;
    float score;

    [SerializeField]
    bool isGrounded = false;
    bool isAlive = true;

    Rigidbody2D RB;

    public TextMeshProUGUI ScoreTxt; 

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        score = 0;
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (isGrounded)
            {
                RB.AddForce(Vector2.up * JumpForce);
                isGrounded = false;
            }
        }
        if (isAlive)
        {
            score += Time.deltaTime * 4;
            ScoreTxt.text = "SCORE : " + score.ToString("F");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("Spike"))
        {
            isAlive = false;
            Time.timeScale = 0;
        }
    }

}
