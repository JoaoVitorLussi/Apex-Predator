using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public Animator animator;

    Vector2 movementInput;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        rb.linearVelocity = movementInput * moveSpeed;

        bool isSwimming = movementInput.sqrMagnitude > 0.01f;
        animator.SetBool("Nadando", isSwimming);

        if (movementInput.x > 0.01f)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f); // Direita
        }
        else if (movementInput.x < -0.01f)
        {
            transform.eulerAngles = new Vector3(0f, 180f, 0f);  // Esquerda
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }

   private void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.CompareTag("Enemy"))
    {
        float mySize = transform.localScale.x;
        float enemySize = collision.transform.localScale.x;

        if (mySize < enemySize)
        {
            Debug.Log("Jogador é menor e morreu!");
            GameManager.GameOver();
            Destroy(gameObject); // Mata o jogador
        }
        else
        {
            Debug.Log("Jogador é maior, destruiu o inimigo e cresceu!");

            Destroy(collision.gameObject); // Mata o inimigo

            // Aumenta o tamanho do jogador em 10%
            float scaleIncrease = 0.02f;
            Vector3 newScale = transform.localScale * (1f + scaleIncrease);
            transform.localScale = newScale;
        }
    }
}
}
