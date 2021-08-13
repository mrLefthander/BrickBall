using UnityEngine;

public class Brick : MonoBehaviour
{
  [SerializeField] private LayerMask _ballLayer;

  private void OnCollisionEnter(Collision collision)
  {
    bool isTouchingBall = _ballLayer == (_ballLayer | (1 << collision.gameObject.layer));
    if (isTouchingBall)
    {
      collision.gameObject.SetActive(false);
      gameObject.SetActive(false);
    }
  }
}
