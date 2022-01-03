using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemController : MonoBehaviour
{
    public float speed = 3.0f;
    public float changeTime = 3.0f;

    Rigidbody2D rb2d;
    float timer;
    int direction = -1;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        timer = changeTime;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }

        Vector2 position = transform.position;

        position.x = position.x + Time.deltaTime * speed * direction;
        anim.SetFloat("Move X En", direction);

        transform.position = position;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        CharController player = other.gameObject.GetComponent<CharController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }
}
