using UnityEngine;

public class Enemy: MonoBehaviour
{
  [SerializeField] private float _moveSpeed = 1f;
  [SerializeField] private float _moveSpeedStep = 0.2f;
  [SerializeField] private LayerMask _ballLayer;

  private Ball _ball;

  private void Awake()
  {
    _ball = FindObjectOfType<Ball>();
  }

  private void Update()
  {
    FollowBall();
  }

  public void RaiseDifficulty()
  {
    _moveSpeed += _moveSpeedStep;
    _moveSpeed *= 2;
  }

  private void FollowBall()
  {
    if (_ball == null)
      _ball = FindObjectOfType<Ball>();

    float targetPositionX = _ball.transform.position.x;
    float step = _moveSpeed * Time.deltaTime;
    Vector3 targetPosition = new Vector3(targetPositionX, transform.position.y, transform.position.z);
    transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
  }

  private void OnCollisionEnter(Collision collision)
  {
    bool isTouchingBall = _ballLayer == (_ballLayer | (1 << collision.gameObject.layer));
    if (isTouchingBall)
    {
      collision.gameObject.SetActive(false);
    }
  }
}
