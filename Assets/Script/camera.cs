using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public GameObject character;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - character.transform.position + new Vector3(3,0,0);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = character.transform.position + offset;
    }
}
