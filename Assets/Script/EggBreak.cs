using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBreak : MonoBehaviour
{
    [SerializeField] GameObject caterpillar;
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
            Instantiate(caterpillar, new Vector3(0, 0, 0), Quaternion.identity);
        }
    }
}
