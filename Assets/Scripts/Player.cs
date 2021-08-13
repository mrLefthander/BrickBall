using UnityEngine;

public class Player : MonoBehaviour
{
  [SerializeField] private float _moveSpeed = 0.005f;
  [SerializeField] private float _maxMoveRadius = 1f;

  private Vector3 _playerOriginPosition;
  private Quaternion _playerOriginRotation;
  private Vector3 _centerPosition;

  private void Start()
  {
    _playerOriginPosition = transform.position;
    _playerOriginRotation = transform.rotation;
  }

  public void ResetPosition()
  {
    transform.SetPositionAndRotation(_playerOriginPosition, _playerOriginRotation);
  }

  public float DragPlayer(Vector2 deltaPosition, Vector3 centerPosition)
  {
    _centerPosition = centerPosition;
    Vector3 offset = CalculateMoveOffset(deltaPosition);
    transform.SetPositionAndRotation(_centerPosition + offset, CalculateRotation());
    return offset.magnitude / _maxMoveRadius;
  }

  private Vector3 CalculateMoveOffset(Vector2 deltaPosition)
  {
    Vector3 newPosition = transform.position + new Vector3(deltaPosition.x * _moveSpeed, 0, deltaPosition.y * _moveSpeed);
    Vector3 rawOffset = newPosition - _centerPosition;
    Vector3 clampedOffset = Vector3.ClampMagnitude(rawOffset, _maxMoveRadius);
    return clampedOffset;
  }

  private Quaternion CalculateRotation()
  {
    Vector3 lookPosition = _centerPosition - transform.position;
    lookPosition.y = 0f;
    Quaternion lookRotation = Quaternion.LookRotation(lookPosition);
    return Quaternion.Slerp(transform.rotation, lookRotation, 1f);
  }
}
