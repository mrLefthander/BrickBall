using UnityEngine;

public class Arrow : MonoBehaviour
{
  [SerializeField] private float _maxWidth = 2f;

  private SpriteRenderer _arrowSpriteRenderer;

  private void Awake()
  {
    _arrowSpriteRenderer = GetComponentInChildren<SpriteRenderer>();
  }

  private void Start()
  {
    _arrowSpriteRenderer.gameObject.SetActive(false);
  }

  public void Show(Quaternion rotation, float powerMultiplier)
  {
    _arrowSpriteRenderer.gameObject.SetActive(true);
    Rotate(rotation);
    StretchWidth(powerMultiplier);
  }

  public void Hide()
  {
    _arrowSpriteRenderer.gameObject.SetActive(false);
  }

  private void Rotate(Quaternion rotation)
  {
    transform.rotation = rotation;
  }

  private void StretchWidth(float powerMultiplier)
  {
    _arrowSpriteRenderer.size = new Vector2(_maxWidth * powerMultiplier, _arrowSpriteRenderer.size.y);
  }
}
