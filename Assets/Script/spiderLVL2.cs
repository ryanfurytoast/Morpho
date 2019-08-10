using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiderLVL2 : MonoBehaviour
{ 
    public float seconds = 150;
    public float timer;
    public Vector3 Point;
    public Vector3 Difference;
    public Vector3 start;
    public float percent;

    [SerializeField] AudioClip breakSFX;
    AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        start = transform.position;
        Point = new Vector3(-40392, 419, -5250);
        Difference = Point - start;
    }

    void Update()
    {

        if (timer <= seconds)
        {
            // basic timer
            timer += Time.deltaTime;
            // percent is a 0-1 float showing the percentage of time that has passed on our timer!
            percent = timer / seconds;
            // multiply the percentage to the difference of our two positions
            // and add to the start
            transform.position = start + Difference * percent;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Nothing":
                break;
            case "Finish":
                break;
            default:
                source.PlayOneShot(breakSFX);
                break;
        }
    }
}
