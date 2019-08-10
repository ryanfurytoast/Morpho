using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Caterpillar : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;

    [SerializeField] AudioClip itemEatSFX;
    [SerializeField] AudioClip walkingSFX;
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
    }

    public void Move()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
        }

        else if(Input.GetKey(KeyCode.DownArrow))
        {
             transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }
    }

        public void Rotate() 
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(Vector3.down * Time.deltaTime * rotateSpeed);
            }

            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            switch (collision.gameObject.tag)
            {
                case "Friendly":
                    source.PlayOneShot(itemEatSFX);
                    break;
                case "Nothing":
                    break;
                default:
                    Death();
                    break;
            }
        }

        public void Death ()
        {
            Destroy(gameObject);
            SceneManager.LoadScene(2);
        }
}
