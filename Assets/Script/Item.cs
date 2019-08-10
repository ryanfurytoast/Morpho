using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Item : MonoBehaviour
{
    [SerializeField] int scorePerHit = 5;
    [SerializeField] scoreBoard sb;
    [SerializeField] AudioClip eatSFX;
    AudioSource source;

    private void OnTriggerEnter(Collider other)
    {
        source.PlayOneShot(eatSFX);
        sb.ScoreHit(scorePerHit);
        Destroy(gameObject);
    }

    void Update()
    {
        checkScore();
    }

    public void checkScore()
    {
        if (sb.score >= 50)
        {
            SceneManager.LoadScene(3) ;
        }
    }

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }


}
