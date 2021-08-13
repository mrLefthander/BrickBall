using UnityEngine;
using TMPro;

public class UIHandler: MonoBehaviour
{
  private const string PLAY_BUTTON_TEXT = "Play";
  private const string RESUME_BUTTON_TEXT = "Resume";
  private const string DIFFICULTY_LEVEL_TEXT = "DIFFICULTY: ";


  [SerializeField] private GameObject _pauseMenuGO;
  [SerializeField] private GameObject _pauseButtonGO;
  [SerializeField] private TMP_Text _playText;
  [SerializeField] private TMP_Text _difficultyText;

  private GameManager _gameManager;

  private void Awake()
  {
    _gameManager = FindObjectOfType<GameManager>();
  }

  private void Start()
  {
    _playText.text = PLAY_BUTTON_TEXT;
    _pauseMenuGO.SetActive(true);
    _pauseButtonGO.SetActive(false);
    UpdateDifficulty(1);
  }

  private void Update()
  {
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      PauseGame();
    }
  }

  public void PauseGame()
  {
    _gameManager.PauseGame();
    _playText.text = RESUME_BUTTON_TEXT;
    _pauseMenuGO.SetActive(true);
    _pauseButtonGO.SetActive(false);
  }

  public void StartGame()
  {
    _pauseMenuGO.SetActive(false);
    _pauseButtonGO.SetActive(true);
    _gameManager.StartGame();
  }

  public void UpdateDifficulty(int difficultyLevel)
  {
    _difficultyText.text = DIFFICULTY_LEVEL_TEXT + difficultyLevel.ToString();
  }

}
