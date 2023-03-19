using UnityEngine;

public class TankAudioController : MonoBehaviour
{
    [SerializeField]private AudioSource _tankSource;
    [SerializeField]private AudioClip _fireSoundEffect;
    [SerializeField]private AudioClip _tankActSource;
    void Update()
    {
        //Tank Fire 
        if(Input.GetKeyDown(KeyCode.F))
        {
            AudioSource.PlayClipAtPoint(_fireSoundEffect, transform.position);
        }
        //Tank Active
        if(Input.GetKeyDown(KeyCode.Z))
        {
            _tankSource.PlayOneShot(_tankActSource);
        }

    }
}
