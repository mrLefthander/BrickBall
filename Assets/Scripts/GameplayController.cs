using System.Collections;
using UnityEngine;

public class GameplayController: MonoBehaviour
{
  private Arrow _arrow;
  private Ball _ball;
  private Player _player;
  private InputEvents _input;
  private GameManager _gameManager;

  private float _powerMultiplier;
  private Vector3 _ballPosition;

  private void Awake()
  {
    _arrow = FindObjectOfType<Arrow>();
    _ball = FindObjectOfType<Ball>();
    _player = FindObjectOfType<Player>();
    _input = GetComponent<InputEvents>();
    _gameManager = FindObjectOfType<GameManager>();
  }

  private void OnEnable()
  {
    _input.MoveEvent += OnMove;
    _input.KickEvent += OnKick;

    _ball.DisableEvent += OnBallHit;
  }

  private void Start()
  {
    _ballPosition = _ball.transform.position;
  }

  private void OnBallHit()
  {
    StartCoroutine(Respawn());
  }

  IEnumerator Respawn()
  {
    yield return new WaitForSeconds(0.5f);
    ResetPlayerAndBall();
    _gameManager.CheckLevelFinish();
  }

  private void ResetPlayerAndBall()
  {
    _player.ResetPosition();
    _ball.gameObject.SetActive(true);
    _ball.ResetPosition();
  }

  private void OnMove(Vector2 deltaPosition)
  {
    _powerMultiplier = _player.DragPlayer(deltaPosition, _ballPosition);
    _arrow.Show(_player.transform.rotation, _powerMultiplier);
  }

  private void OnKick()
  {
    _ball.Kick(_player.transform.position, _powerMultiplier);
    _player.ResetPosition();
    _arrow.Hide();
  }

  private void OnDestroy()
  {
    _input.MoveEvent -= OnMove;
    _input.KickEvent -= OnKick;

    _ball.DisableEvent -= OnBallHit;
  }
}
