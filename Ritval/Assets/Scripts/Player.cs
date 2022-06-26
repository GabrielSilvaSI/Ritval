using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Transform GroundDetect;
    public LayerMask IsGround;
    public float Speed;
    public float JumpForce;
    public GameObject DeadEffect;
    public AudioClip GroundJump;
    public AudioClip Revert;
    public AudioClip Loose;

    private Player PlayerScript;
    private SpriteRenderer Sprender;
    private Animator Anim;
    private Rigidbody2D Rig;
    private AudioSource Sound;
    private bool top;
    private bool OnGround; 
    

    void Start()
    {
        Rig = GetComponent<Rigidbody2D>();
        Anim = GetComponent<Animator>();
        Sprender = GetComponent<SpriteRenderer>();
        PlayerScript = GetComponent<Player>();
        Sound = GetComponent<AudioSource>();
    }
    void Update()
    {
        RevertGravity();
        Move();
    }

    void Move(){
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * (Time.deltaTime * Speed);

        if(Input.GetAxis("Horizontal") > 0f){
            if(top){
                transform.eulerAngles = new Vector3(0f,180f,180f);
            }else{
                transform.eulerAngles = new Vector3(0f,0f,0f);
            }
            Anim.SetBool("run", true);
        }
        if(Input.GetAxis("Horizontal") < 0f){
            if(top){
                transform.eulerAngles = new Vector3(0f,0f,180f);
            }else{
                transform.eulerAngles = new Vector3(0f,180f,0f);
            }
            Anim.SetBool("run", true);
        }
        if(Input.GetAxis("Horizontal") == 0){
            Anim.SetBool("run", false);
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        Anim.SetBool("jump", false);
        if (collision.gameObject.tag == "DeadObject")
        {
            PlayerDead();
        }else{
           Sound.PlayOneShot(GroundJump, 1);
        }
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if(collider.gameObject.tag == "DeadObject"){
            PlayerDead();
        }
    }

    void RevertGravity(){
        if(Input.GetButtonDown("Jump")){
            Sound.PlayOneShot(Revert, 1);
            Rig.gravityScale *= -1;
            Anim.SetBool("jump", true);
            if(!top){
                transform.eulerAngles = new Vector3(0, 0, 180f);
                Sprender.color = new Color(0.1f, 0.1f, 0.1f, 1f);
            }else{
                transform.eulerAngles = Vector3.zero;
                Sprender.color = new Color(1f, 1f, 1f, 1f);
            }
            top =!top;
        }
    }

    void PlayerDead(){
        Sound.PlayOneShot(Loose, 1);
        Sprender.enabled = false;
        transform.eulerAngles = Vector3.zero;
        DeadEffect.SetActive(true);
        DeadEffect.GetComponent<Animator>().SetTrigger("magic");
        PlayerScript.enabled = false;
        GameController.Instance.Invoke("ShowMenuDeath", 1.5f);
    }
}
