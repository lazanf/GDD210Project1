using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyManagement : MonoBehaviour {

    public GameObject player;

    public int HP = 5;

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "bullet") {
            HP--;
            if (HP == 0) {
                Destroy(gameObject);
            }
        }
    }
}
