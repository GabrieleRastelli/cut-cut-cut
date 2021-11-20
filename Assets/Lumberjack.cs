using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Lumberjack : MonoBehaviour
{
    public Animator animator;
    public string position;
    public Vector2 dxPosition, sxPosition;
    public Rigidbody2D rb;


    void Start()
    {
        position = "dx";
        dxPosition = transform.position;
        sxPosition = new Vector2 (transform.position.x * -1, transform.position.y);
    }

    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        die();
        GameController.gameover = true;
    }

    public void die()
    {
        animator.Play("lumberjack_die");
    }
}
