using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemLVL2 : MonoBehaviour
{
    [SerializeField] int scorePerHit = 5;

    [SerializeField] scoreBoard sb;

    private void OnCollisionEnter(Collision collision)
    {
        sb.ScoreHit(scorePerHit);
        Destroy(gameObject);
    }

    void Update()
    {
        checkScore();
    }

    public void checkScore()
    {
        if (sb.score >= 100)
        {
            SceneManager.LoadScene(4);
        }
    }
}
