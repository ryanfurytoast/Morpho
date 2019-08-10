using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreBoard : MonoBehaviour
{
    public int score;
    public Text scoreText;

    // Use this for initialization
    void Start()
    {
        scoreText = GetComponent<Text>();
    }

    public void ScoreHit(int scorePerHit)
    {
        score = score + scorePerHit;
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

}
