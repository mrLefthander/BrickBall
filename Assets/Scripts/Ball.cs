using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
  [SerializeField] private float _baseKickPower = 20f;

  public event UnityAction DisableEvent = delegate { };

  private Vector3 _ballOriginPosition;
  private Rigidbody _rigidBody;

  private void Awake()
  {
    _rigidBody = GetComponent<Rigidbody>();
  }

  private void Start()
  {
    _ballOriginPosition = transform.position;
  }

  public void ResetPosition()
  {
    transform.position = _ballOriginPosition;
    _rigidBody.velocity = Vector3.zero;
  }

  public void Kick(Vector3 kickerPosition, float powerMultiplier)
  {
    Vector3 kickForce = (transform.position - kickerPosition) * powerMultiplier * _baseKickPower;
    _rigidBody.AddForce(kickForce, ForceMode.Impulse);
  }

  private void OnDisable()
  {
    DisableEvent?.Invoke();
  }
}
