using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class butterfly : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float rotateSpeed;
    [SerializeField] float thrustSpeed;
    Rigidbody butterflyRB;
 
    // Start is called before the first frame update
    void Start()
    {
        butterflyRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        //Rotate();
    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            butterflyRB.AddRelativeForce(Vector3.up * thrustSpeed);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
           transform.Translate(Vector3.left * moveSpeed);
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.right * moveSpeed);
        }
    }

    public void Rotate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * rotateSpeed);
        }

        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * rotateSpeed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.tag)
        {
            case "Finish":
                SceneManager.LoadScene(5);
                break;
            default:
                break;
        }
    }
}
