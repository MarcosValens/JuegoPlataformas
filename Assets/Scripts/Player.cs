using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject atack;
    public GameObject postitionAtack;

    public Animator animator;

    public AudioClip jumpClip;

    private AudioSource player_As;
    private int doubleJump;
    private int lifes;
    private bool atacking;
    private int coins;

    private bool movingRight;
    private bool movingLeft;
    public int getLifes {
        get { return lifes; }
        set { lifes = value; }
    }

    public int getCoins
    {
        get { return coins; }
        set { coins = value; }

    }

    // Start is called before the first frame update
    void Start()
    {
        doubleJump = 0;
        lifes = 3;
        coins = 0;
        player_As = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || movingLeft == true)
        {
            transform.Translate(new Vector3(-0.1f, 0.0f));
        } 
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || movingRight == true)
        {
            transform.Translate(new Vector3(0.2f, 0.0f));
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            jumpBtn();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            atackBtn();
        }
    }

    

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Platform") {
            animator.SetBool("Jumping", false);
            doubleJump = 0; }


        if (collision.gameObject.tag == "Enemy") {

            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject, 0.5f);
            lifes --;
            animator.SetTrigger("Damage");
            Debug.Log("lifes = " + lifes);
            if (lifes <= 0) {
                Debug.Log("Has Muerto");
                animator.SetBool("Died", true);
                //gameObject.SetActive(false);
                int lastRecord = PlayerPrefs.GetInt("Coins");
                if (PlayerPrefs.HasKey("Coins") == false)
                {
                    //No records on memory
                    PlayerPrefs.SetInt("Coins", coins);
                    Debug.Log("NEW RECORD!!! " + coins);
                    //TODO: Set here new record screen
                }
                else {
                    //there is a record saved
                    if (lastRecord < coins) {
                        //New record
                        PlayerPrefs.SetInt("Coins", coins);
                        Debug.Log("NEW RECORD!!! " + coins);
                    }
                }
            }
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            collision.gameObject.SetActive(false);
            Destroy(collision.gameObject, 0.5f);
            coins++;
            Debug.Log("Coins = " + coins);
        }
    }

    public void jumpBtn() {
        if (doubleJump < 2)
        {
            animator.SetBool("Jumping", true);
            doubleJump += 1;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0.0f, 300.0f));
            /*player_As.clip = jumpClip;
            player_As.Play();*/
            player_As.PlayOneShot(jumpClip);

        }
    }

    public void atackBtn() {
        if (atacking == false)
        {
            animator.SetTrigger("Atacking");
            GameObject.Instantiate(atack, postitionAtack.transform.position, postitionAtack.transform.rotation);
            atacking = true;
            Invoke("FinishAtack", 0.5f);
        }
    }
    private void FinishAtack()
    {
        atacking = false;
    }

    public void moveRight(bool _active) {
        movingRight = _active;
    }

    public void moveleft(bool _active)
    {
        movingLeft = _active;
    }
}
