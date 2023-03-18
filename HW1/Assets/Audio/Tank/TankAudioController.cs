using UnityEngine;

public class TankAudioController : MonoBehaviour
{
    [SerializeField]private AudioSource _tankSource;
    [SerializeField]private AudioClip _fireSoundEffect;
    [SerializeField]private AudioClip _tankActSource;
    private bool _isRun = false;
    void Update()
    {
        //Tank Fire 
        if(Input.GetKeyDown(KeyCode.F))
        {
            _tankSource.PlayOneShot(_fireSoundEffect);
        }
        //Tank Active
        if(Input.GetKeyDown(KeyCode.Z))
        {
            _tankSource.PlayOneShot(_tankActSource);
        }
        if(_isRun)
        {
            //TODO: AudioClip of AudioSource in tank is high_on & high_off
            _tankSource.Play();
        }
        else
        {
            _tankSource.Pause();
        }

    }
}
