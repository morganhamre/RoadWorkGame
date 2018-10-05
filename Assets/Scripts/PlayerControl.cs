using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rigidbod;
    public float step;
    private UIHealthPanel hpanel;
    public int hp;
    public int maxHP = 3;

    public Sprite spriteLeftA;
    public Sprite spriteLeftB;
    public Sprite spriteRightA;
    public Sprite spriteRightB;
    public Sprite forwardL;
    public Sprite forwardR;
    public Sprite stand;
    public AudioSource waterSound;
    private SpriteRenderer sprRend;


    // Use this for initialization
    void Start()
    {
        hpanel = Object.FindObjectOfType<UIHealthPanel>();
        hp = maxHP;
        rigidbod = GetComponent<Rigidbody2D>();
        sprRend = GetComponent<SpriteRenderer>();
        sprRend.sprite = stand;
    }

    // Update is called once per frame
    // player movements adapted from DIS Game Development Lab 2, author Benno Lueders
    void Update()
    {
        Vector2 pos = rigidbod.position;
        Vector2 normalizedDir = rigidbod.velocity.normalized;
        transform.up = normalizedDir;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            pos.y += step;
            if (sprRend.sprite == forwardL)
            {
                sprRend.sprite = forwardR;
            }
            else
            {
                sprRend.sprite = forwardL;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)){
            pos.x -= step;
            if(sprRend.sprite == spriteLeftA){
                sprRend.sprite = spriteLeftB;
            } else{
                sprRend.sprite = spriteLeftA;
            }
        }
        if(Input.GetKeyDown(KeyCode.RightArrow)){
            pos.x += step;
            if (sprRend.sprite == spriteRightA)
            {
                sprRend.sprite = spriteRightB;
            }
            else
            {
                sprRend.sprite = spriteRightA;
            }
        }
        if(Input.GetKeyDown(KeyCode.DownArrow)){
            pos.y -= step;
            sprRend.sprite = stand;
        }

        rigidbod.position = pos;
    }

    void Hurt(){
        Vector2 pos = rigidbod.position;
        pos.y = (float) -4.5;
        pos.x = (float) -3.5;
        rigidbod.position = pos;
        hp--;
        //hpanel.SetLives(maxHP, hp);
        hpanel.UpdateHearts(hp);
        if (hp <= 0){
            Die();
        }
    }

    void Die(){
        Destroy(gameObject);
        SceneManager.LoadScene("Game Over");
        //Maybe load main menu? Text saying game over, play again?
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Vehicle"))
        {
            Hurt();
        }

        if(col.gameObject.CompareTag("Police")){
            Vector2 pos = rigidbod.position;
            pos.x -= (float) 2;
            rigidbod.position = pos;
        }

        if(col.gameObject.CompareTag("Water")){
            Hurt();
            waterSound = GetComponent<AudioSource>();
            waterSound.Play();
        }

    }
}
