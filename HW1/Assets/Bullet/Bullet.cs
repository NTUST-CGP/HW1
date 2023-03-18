using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]private AudioClip _bulletExplosionSound;
    [SerializeField]private GameObject _explosionParticle;
    private void Update()
    {
        transform.position += new Vector3(0, 0, 1f) * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision other) 
    {
        GameObject explotion = (GameObject)Instantiate(_explosionParticle, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(_bulletExplosionSound, transform.position);
        Destroy(explotion, 1.0f);
        Destroy(gameObject);
    }
}
