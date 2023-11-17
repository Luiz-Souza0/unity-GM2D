using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovemment : MonoBehaviour
{
    //fazer correr
    [SerializeField] private float Speed = 7f;
    [SerializeField] private float JumpForce = 8.5f;
    private Rigidbody2D rigidbody;
    //para ativar a animação
    private Animator animRun;

    private BoxCollider2D coll;
    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;

    //para selecionar o spriteRenderer - QUERO MUDAR DE LADO
    private SpriteRenderer sprite;


    private enum MovementState { statics, running, jump, falling }

    private void Start()
    {   //ambos para não ter q pegar o componente todo frame, só chama uma vez
        rigidbody = GetComponent<Rigidbody2D>();
        animRun = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {   //andar para os lados de forma suave

        dirX = Input.GetAxis("Horizontal");
        rigidbody.velocity = new Vector2(dirX * Speed, rigidbody.velocity.y);
        //pular com o espaço

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x, JumpForce);

        }

        //chama a nova função toda hora, mais limpo.
        UpdateAnimationUpdate();

    }

    private void UpdateAnimationUpdate()
    {
        MovementState state;

        if (Mathf.Abs(dirX) > 0f && !(Mathf.Abs(rigidbody.velocity.y) > 0.1f))
        {
            state = MovementState.running;
            sprite.flipX = dirX < 0f;
        }
        else if (Mathf.Abs(rigidbody.velocity.y) > 0.1f)
        {
            state = rigidbody.velocity.y > 0f ? MovementState.jump : MovementState.falling;
            sprite.flipX = dirX < 0f;
        }
        else
        {
            state = MovementState.statics;
        }

        animRun.SetInteger("State", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
