using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocoonBreak : MonoBehaviour
{
    [SerializeField] GameObject butterfly;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            Destroy(gameObject);
            Instantiate(butterfly, new Vector3(378, 40, -415), Quaternion.identity);
        }
    }
}
