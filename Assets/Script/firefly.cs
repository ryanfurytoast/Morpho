using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class firefly : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float thrustSpeed;
    Rigidbody fireflyRB;

    [SerializeField] AudioClip breakSFX;
    AudioSource source;

    private bool FROZEN = false;
    private Vector3 FREEZEPOSITION = Vector3.zero;
    private bool isControllable = true;
    // Start is called before the first frame update
    void Start()
    {
        fireflyRB = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Thrust();

        if (!isControllable)
        {
            Input.ResetInputAxes();
        }

        else if (FROZEN)
        {
            transform.position = FREEZEPOSITION;
        }

    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.forward * moveSpeed);
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.back * moveSpeed);
        }
    }

    public void Thrust()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            fireflyRB.AddRelativeForce(Vector3.up * thrustSpeed);
        }

        else if (Input.GetKey(KeyCode.DownArrow))
        {
            fireflyRB.AddRelativeForce(Vector3.down * thrustSpeed);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Nothing":
                print("safe");
                break;
            case "Friendly":
                break;
            case "Spider":
                Death();
                break;
            case "Finish":
                LoadNextScene();
                break;
            default:
                source.PlayOneShot(breakSFX);
                Freeze();
                Invoke("Thaw", 1);
                break;
        }
    }

    public void Death()
    {
        Destroy(gameObject);
        LoadPreviousScene();
    }

    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }

    void LoadPreviousScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int previousSceneIndex = currentSceneIndex - 1;

        if (previousSceneIndex == 5)
        {
            SceneManager.LoadScene(6);
        }

        else { SceneManager.LoadScene(previousSceneIndex); }

    }

    public void Freeze()
    {
       isControllable = false; // disable player controls.
       FREEZEPOSITION = transform.position;
       FROZEN = true;
    }

    public void Thaw()
    {
        FROZEN = false;
        isControllable = true;
    }

}
