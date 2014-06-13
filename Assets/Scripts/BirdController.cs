using UnityEngine;
using System.Collections;
using System;

public class BirdController : MonoBehaviour {
    public float speed;

    public event EventHandler GameOver;
    public event EventHandler ScoreAdd;

	// Use this for initialization

	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Jump")){
            rigidbody2D.velocity = new Vector2(0, speed);
            Animator animator = GetComponent<Animator>();
            animator.SetTrigger("jump");
        }
	}

    void OnTriggerExit2D(Collider2D col) {
        if (col.gameObject.name.Equals("empty")) {
            if (ScoreAdd != null)
                ScoreAdd(this, EventArgs.Empty);
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        rigidbody2D.velocity = new Vector2(0, 0);
        if (GameOver != null)
            GameOver(this, EventArgs.Empty);
        this.enabled = false;
    }

}



