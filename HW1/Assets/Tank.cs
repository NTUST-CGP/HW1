using UnityEngine;

public class Tank : MonoBehaviour
{
    [SerializeField]private GameObject _bullet;
    [SerializeField]private GameObject _barrel;

    [SerializeField]private float _upSpeed, _forwardSpeed;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            Rigidbody rb = Instantiate(_bullet, _barrel.transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            // Physics.IgnoreCollision(rb.GetComponent<Collider>(), _barrel.GetComponent<Collider>());
            rb.AddForce(transform.forward * _forwardSpeed, ForceMode.Impulse);
            rb.AddForce(transform.up * _upSpeed, ForceMode.Impulse);
        }
    }
}
