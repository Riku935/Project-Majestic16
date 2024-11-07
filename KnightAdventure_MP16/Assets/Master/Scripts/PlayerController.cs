using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidad de movimiento
    private Animator animator;
    private Rigidbody2D rb;
    private SpriteRenderer spr;
    public SpriteRenderer helmetSpr;
    private Vector2 movement;
    private bool canAttack = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = transform.GetChild(0).GetComponent<Animator>();
        spr = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("Ataque");
        }
        if (movement.x < 0)
        {
            this.transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
        else if (movement.x > 0)
        {
            this.transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), this.transform.localScale.y, this.transform.localScale.z);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }
    private IEnumerator Ataque()
    {
        canAttack = false;
        animator.SetTrigger("isAttacking");
        yield return new WaitForSeconds(0.5f);
        canAttack = true;
    }
}
