using UnityEngine;
using UnityEngine.Events;

public class InputEvents: MonoBehaviour
{
  public event UnityAction<Vector2> MoveEvent = delegate { };
  public event UnityAction KickEvent = delegate { };
  private GameManager _gameManager;
  private Touch _touch;

  private void Awake()
  {
    _gameManager = FindObjectOfType<GameManager>();
  }

  private void Update()
  {
    if (Input.touchCount <= 0 || _gameManager.IsPaused) { return; }

    _touch = Input.GetTouch(0);

    if (_touch.phase == TouchPhase.Moved)
      MoveEvent?.Invoke(_touch.deltaPosition);

    if (_touch.phase == TouchPhase.Ended)
      KickEvent?.Invoke();
  }
}
