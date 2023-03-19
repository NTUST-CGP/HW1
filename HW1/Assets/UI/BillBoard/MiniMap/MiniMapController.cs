using UnityEngine;

public class MiniMapController : MonoBehaviour
{
    public Camera _miniCam;
    public Transform _player;
    public Transform _miniPlayerIcon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _miniCam.transform.position = new Vector3(_player.position.x, _miniCam.transform.position.y, _player.position.z);
        _miniPlayerIcon.eulerAngles = new Vector3(0, 0, -_player.eulerAngles.y);
    }
}
