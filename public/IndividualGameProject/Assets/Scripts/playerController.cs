using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour {

    public int maxJumps;

    int jumps;

    Rigidbody2D rb;

    bool grounded;

    public GameObject bullet;

    public Vector2 offset = new Vector2(0.1f, 0f);

    bool canShoot = true;

    public float cooldown = 0.5f;

    public AudioClip shoot;

    private AudioSource source;

    public Button resetButton;

    public int damage;

    public int playerHealth;

    public int iframes;

    public Text savedText;

    public int colonistsSaved;
	// Use this for initialization
	void Start () {
        playerHealth = 5;

        damage = 1;

        rb = GetComponent<Rigidbody2D>();

        jumps = 2;

        source = GetComponent<AudioSource>();

        resetButton.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)) {
            Jump();
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            gameObject.transform.position += Vector3.right * 2.0f * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            gameObject.transform.position += Vector3.left * 2.0f * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.X) && canShoot) {
            StartCoroutine(CanShoot());
            Shoot();
        }
    }

    void Jump() {
        if (jumps > 0) {
            rb.AddForce(new Vector2(0, 8), ForceMode2D.Impulse);
            grounded = false;
            jumps--;
        }

        if (jumps == 0) {
            return;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "ground") {
            jumps = maxJumps;
            grounded = true;
        } else if (collision.gameObject.tag == "enemy") {
            damagePlayer(1);
            Debug.Log(playerHealth);
        } else if (collision.gameObject.tag == "helper") {
            colonistsSaved++;
            savedText.text = "Colonists saved: " + colonistsSaved + "/5";
        }
    }

    private void FixedUpdate() {
        iframes--;
    }

    //I found the code for shooting (e.g. void Shoot() and IEnumerator CanShoot() from 
    //https://www.youtube.com/watch?v=SlEFoM4h3Mc this youtube video.
    void Shoot() {
        GameObject Bullet = Instantiate(bullet, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity) as GameObject;
        Bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(8f, 0f);
        source.PlayOneShot(shoot);
    }

    IEnumerator CanShoot() {
        canShoot = false;
        yield return new WaitForSeconds(cooldown);
        canShoot = true;
    }

    void damagePlayer(int damage) {
        if (iframes > 0) {
            return;
        }
        playerHealth -= damage;
        if (playerHealth <= 0) {
            Destroy(gameObject);
            resetButton.gameObject.SetActive(true);
        }
        if (playerHealth > 0) {
            iframes = 120;
        }
    }
}
