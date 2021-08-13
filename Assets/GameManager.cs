using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager: MonoBehaviour
{
  public bool IsPaused { get; private set; } = true;
  public int DifficultyLevel { get; private set; } = 1;

  private Enemy _enemy;
  private List<Brick> _bricks;
  private UIHandler _uiHandler;

  private void Awake()
  {
    _enemy = FindObjectOfType<Enemy>();
    _bricks = FindObjectsOfType<Brick>().ToList();
    _uiHandler = FindObjectOfType<UIHandler>();
  }

  private void Start()
  {
    PauseGame();
  }

  public void CheckLevelFinish()
  {
    bool isAllBricksHit = _bricks.Count(brick => brick.gameObject.activeSelf == true) == 0;
    if (isAllBricksHit)
    {
      _bricks.ForEach(brick => brick.gameObject.SetActive(true));
      DifficultyLevel++;
      _uiHandler.UpdateDifficulty(DifficultyLevel);
      _enemy.RaiseDifficulty();
    }
  }

  public void StartGame()
  {
    Time.timeScale = 1f;
    StartCoroutine(Unpause());
  }

  IEnumerator Unpause()
  {
    yield return new WaitForSeconds(0.5f);
    IsPaused = false;
  }

  public void PauseGame()
  {
    IsPaused = true;
    Time.timeScale = 0f;
  }

  public void QuitGame()
  {
    Application.Quit();
  }
}
