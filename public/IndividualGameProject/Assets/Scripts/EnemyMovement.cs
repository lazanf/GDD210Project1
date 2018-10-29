using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public Transform originPoint;
    private Vector2 dir = new Vector2(-1, 0);
    public float range;
    public float speed;

    Rigidbody2D rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
    //I got the Update, FixedUpdate, and Flip code from 
    //https://www.youtube.com/watch?v=umpmRxA6CnY this youtube video.
	void Update () {
        Debug.DrawRay(originPoint.position, dir * range);
        RaycastHit2D hit = Physics2D.Raycast(originPoint.position, dir, range);
        if (hit == false) {
            Flip();
            speed *= -1;
            dir *= -1;
        }
	}

    private void FixedUpdate() {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void Flip() {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
