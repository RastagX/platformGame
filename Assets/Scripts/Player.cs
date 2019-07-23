using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed, jumpForce;
    
    private Rigidbody2D rig;
    public Transform ground;
    public bool grounded;
    public LayerMask whatIsGround;

    private Animator ani;

    public int score = 0, life = 3;
    private float start_x, start_y;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponentInChildren<Animator>();
        start_x = transform.position.x;
        start_y = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        PlayerJump();
    }

    void PlayerMovement(){

        //Animação de walk
        ani.SetFloat("walk", Mathf.Abs(Input.GetAxis("Horizontal")));

        //Movimento para a direita
        if(Input.GetAxis("Horizontal") > 0){
            //transform.Translate(Vector2.right * (speed * Time.deltaTime));
            rig.velocity = new Vector2(speed, rig.velocity.y);
            transform.localScale = new Vector3(1,1,1);
        }

        //Movimento para a esquerda
        if(Input.GetAxis("Horizontal") < 0){
            //transform.Translate(Vector2.left * (speed * Time.deltaTime));
            rig.velocity = new Vector2(-speed, rig.velocity.y);
            transform.localScale = new Vector3(-1,1,1);
        }

        if(Input.GetAxis("Horizontal") == 0){
            rig.velocity = new Vector2(0, rig.velocity.y);
        }

    }

    void PlayerJump(){

        //Animação de jump
        ani.SetBool("jump", !grounded);

        grounded = Physics2D.OverlapCircle(ground.position, 0.02f, whatIsGround);
        if(Input.GetButtonDown("Jump") && grounded){
            rig.AddForce(Vector2.up * jumpForce);
        }
    }

    
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "coins"){
            Destroy(other.gameObject);
            score += 1;
        }
    }


    public void RestartGame(){
        transform.position = new Vector3(start_x, start_y, transform.position.z);
        life -= 1;
    }

}
