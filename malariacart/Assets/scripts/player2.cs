using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed = 0f;
    private float maxspeed = 10f;
    private float minspeed = 0f;
    private int grass = 0;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speed = 0f;
    }

    void Update()
    {
        Movement();
    }

    void Movement(){
        if(Input.GetKey("k")){
            speed -= 0.03f;
            minspeed = -5f;
        }
        else if(Input.GetKey("i")){
            speed += 0.05f;
            if(grass < 1){
                maxspeed = 10f;
            }
            if(Input.GetKey("n") && grass < 1){
                speed += 0.055f;
                maxspeed = 15f;
            }
            minspeed = 0f;
        }
        else if(speed > minspeed){
            minspeed = 0f;
            speed -= 0.01f;
        }
        else{
            minspeed = 0f;
        }
        if(Input.GetKey("l")){
            transform.Rotate(0f, 0f, -0.5f, Space.Self);
        }
        if(Input.GetKey("j")){
            transform.Rotate(0f, 0f, 0.5f, Space.Self);
        }
        if(speed < minspeed){
            speed = minspeed;
        }
        else if(speed > maxspeed){
            speed = maxspeed;
        }
        transform.position += transform.up * 0.001f * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision){
        GameManager gameManager = FindAnyObjectByType<GameManager>();
        if(collision.CompareTag("grass")){
            maxspeed = 3f;
            grass = 1;
        }
        if(collision.CompareTag("oil")){
            transform.Rotate(0f, 0f, Random.Range(-30, 30), Space.Self);
        }
        if(collision.CompareTag("border")){
            transform.position = new Vector2(1, -3.5f);
        }
        if(collision.CompareTag("cp1")){
            if(gameManager.p2cp < 1){
                gameManager.p2cp = 1;
            }
        }
        if(collision.CompareTag("cp2")){
            if(gameManager.p2cp > 0 && gameManager.p2cp < 2){
                gameManager.p2cp = 2;
            }
        }
        if(collision.CompareTag("cp3")){
            if(gameManager.p2cp > 1 && gameManager.p2cp < 3){
                gameManager.p2cp = 3;
            }
        }
        if(collision.CompareTag("finish")){
            if(gameManager.p2cp >= 3){
                gameManager.p2cp = 0;
                gameManager.p2lapcount += 1;
                gameManager.lap();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("grass")){
            maxspeed = 10f;
            grass = 0;
        }
    }
}