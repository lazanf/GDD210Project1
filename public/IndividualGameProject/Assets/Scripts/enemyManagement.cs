using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManagement : MonoBehaviour {

    public GameObject player;

    public int HP = 5;

    Rigidbody2D rb;

    public int damage;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();

        damage = 1;
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "bullet") {
            HP = HP - damage;
            if (HP == 0) {
                Destroy(gameObject);
            }
        }
    }
}
