using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WASDMoveBehaviour : MonoBehaviour
{
    [SerializeField]private AudioSource _tankSource;
    public bool _isRun = false;
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
        if(horizontal != 0 || vertical != 0)
            _isRun = true;
        else
            _isRun = false;
        if(_isRun)
        {
            //TODO: AudioClip of AudioSource in tank is high_on & high_off
            _tankSource.Play();
        }
        else
        {
            _tankSource.Pause();
        }
        //move the tank forward or backward based on vertical input
        transform.Translate(Vector3.forward * vertical * speed * Time.deltaTime);

        //rotate the tank left or right based on horizontal input
        transform.Rotate( (Vector3.up) * horizontal * turnSpeed * (vertical<0 ? -1.0f:1.0f) * Time.deltaTime);
    }
}
