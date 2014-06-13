using UnityEngine;
using System.Collections;
using System;

public class ScoreFactory : MonoBehaviour {

    public Sprite[] scores;
    public SpriteRenderer scoreRenderer_0;
    public SpriteRenderer scoreRenderer_1;

    private int currentScore;

    void Start()
    {
        GameObject.Find("bird").GetComponent<BirdController>().ScoreAdd += OnScoreAdd;
        currentScore = 10;
        scoreRenderer_1.sprite = scores[0];
        scoreRenderer_0.enabled = false;
    }

    void OnDestroy()
    {
        if (GameObject.Find("bird"))
            GameObject.Find("bird").GetComponent<BirdController>().ScoreAdd -= OnScoreAdd;
    }

    void OnScoreAdd(object sender, EventArgs e) {
        currentScore++;
        scoreRenderer_1.sprite = scores[currentScore % 10];
        scoreRenderer_0.sprite = scores[currentScore / 10];
        if (currentScore >= 10)
            scoreRenderer_0.enabled = true;
    }
}
