using UnityEngine;

public class BottomCutOff : MonoBehaviour
{
  [SerializeField] private LayerMask _ballLayer;

  private void OnCollisionEnter(Collision collision)
  {
    bool isTouchingBall = _ballLayer == (_ballLayer | (1 << collision.gameObject.layer));
    if (isTouchingBall)
    {
      collision.gameObject.SetActive(false);
    }
  }
}
