using UnityEngine;

public class PlayerControls : MonoBehaviour
{
  [SerializeField] private Arrow _arrow;
  [SerializeField] private Ball _ball;
  [SerializeField] private Player _player;

  private Touch _touch;
  private float _powerMultiplier;
  private Vector3 _ballPosition;

  private void Awake()
  {
    if (_arrow != null) { return; }
    _arrow = FindObjectOfType<Arrow>();
    if (_ball != null) { return; }
    _ball = FindObjectOfType<Ball>();
    if (_player != null) { return; }
    _player = FindObjectOfType<Player>();
  }

  private void Start()
  {
    _ballPosition = _ball.transform.position;
  }

  private void Update()
  {
    if(Input.touchCount > 0)
    {
      _touch = Input.GetTouch(0);
      if(_touch.phase == TouchPhase.Moved)
      {
        _powerMultiplier = _player.DragPlayer(_touch.deltaPosition, _ballPosition);
        _arrow.Show(_player.transform.rotation, _powerMultiplier);
      }
      if(_touch.phase == TouchPhase.Canceled)
      {
        _arrow.Hide();
      }
      if(_touch.phase == TouchPhase.Ended)
      {
        _ball.Kick(_player.transform.position, _powerMultiplier);
        _player.transform.position = _ballPosition;
        _arrow.Hide();
      }
    }
  }
}
