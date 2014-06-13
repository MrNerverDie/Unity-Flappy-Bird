using UnityEngine;
using System.Collections;
using System;

public class BirdController : MonoBehaviour {
    public float speed;

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
        NotificationCenter.GetInstance().PostNotification("ScoreAdd");
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        rigidbody2D.velocity = new Vector2(0, 0);
        NotificationCenter.GetInstance().PostNotification("GameOver");
        this.enabled = false;
    }

}



