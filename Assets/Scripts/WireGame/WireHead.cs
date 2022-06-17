using UnityEngine;

public class WireHead : MonoBehaviour
{
    [SerializeField] private Transform _connector;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private GeneralEvent onWireConnected;

    [SerializeField] private Vector3 distance;
    [SerializeField] private AudioSource _headSource;
    [SerializeField] private AudioClip _connectionSound;

    private void FixedUpdate()
    {
        distance = transform.position - _connector.position;
    }

    public void ConnectWire()
    {
        if (Mathf.Abs(distance.x) < 0.5F && Mathf.Abs(distance.y) < 0.5F)
        {
            _rb.simulated = false;
            transform.position = _connector.position;
            onWireConnected?.InvokeEvent();
            _particleSystem.Play();
            _headSource.PlayOneShot(_connectionSound);
        }
    }

    public void SetConnector(Transform t)
    {
        _connector = t;
    }

}
