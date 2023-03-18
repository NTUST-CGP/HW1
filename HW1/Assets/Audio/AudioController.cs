using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class AudioController : MonoBehaviour
{
    [SerializeField]private AudioClip _btnSoundEffect;
    [SerializeField]private AudioSource _btnAudioSource;
    [SerializeField]private AudioSource _bgmSource;
    [SerializeField]private Slider _bgmSlider;
    [SerializeField]private Slider _effectSlider;
    public void MouseOnButtton()
    {
        _btnAudioSource.PlayOneShot(_btnSoundEffect);
    }
    public void AdjustBGMVolume()
    {
        _bgmSource.volume = _bgmSlider.value;
    }
    public void AdjustEffectVolume()
    {
        _btnAudioSource.volume = _effectSlider.value;
    }
    public void PlayerEffectSound()
    {
        _btnAudioSource.PlayOneShot(_btnSoundEffect);
    }
}
