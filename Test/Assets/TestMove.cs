using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var input = new Vector3(Input.GetAxis("Horizontal"), 0f,Input.GetAxis("Vertical"));
        transform.Translate(6f * Time.deltaTime * input.normalized);
    }
}
