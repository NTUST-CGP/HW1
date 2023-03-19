using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDMoveBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
 public float speed = 10f; //how fast the tank moves
    public float turnSpeed = 50f; //how fast the tank turns

    void Update () {
        //get input values from WASD keys
        float horizontal = Input.GetAxis("Horizontal"); 
        float vertical = Input.GetAxis("Vertical");

        //move the tank forward or backward based on vertical input
        transform.Translate(Vector3.forward * vertical * speed * Time.deltaTime);

        //rotate the tank left or right based on horizontal input
        transform.Rotate(Mathf.Abs(Vertical).Vector3.up * horizontal * turnSpeed * Time.deltaTime);
    }
}
