using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed, delay;
    public GameObject obj_effect;
    private bool isLeft;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ChangeDirection", delay, delay);
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    void EnemyMovement(){
        if(isLeft){
            transform.Translate(Vector2.left * (speed * Time.deltaTime));
            transform.localScale = new Vector3(1,1,1);
        }else{
            transform.Translate(Vector2.right *(speed * Time.deltaTime));
            transform.localScale = new Vector3(-1,1,1);
        }
    }

    void ChangeDirection(){
        isLeft = !isLeft;
    }

    //Leva dano do inimigo
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Player"){
            Player.FindObjectOfType<Player>().RestartGame();
        }
        //Player.FindObjectOfType<Player>().RestartGame();
    }

    //Pula no inimigo
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
            //obj_player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 150);
            //Instantiate(obj_effect, transform.position, transform.rotation);
            //Destroy(this.gameObject);
            var rig_other = other.GetComponent<Rigidbody2D>();
            if(rig_other.velocity.y < 0){
                rig_other.velocity = new Vector2(rig_other.velocity.x, 3);
                Instantiate(obj_effect, transform.position, transform.rotation);
                Destroy(this.gameObject);
            }
        }
    }

}
