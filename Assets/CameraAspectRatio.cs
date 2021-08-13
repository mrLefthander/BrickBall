using UnityEngine;

public class CameraAspectRatio : MonoBehaviour
{
  public Vector2 ReferenceResolution;
  public Vector3 ZoomFactor = Vector3.one;
  private Vector3 _originPosition;

  void Start()
  {
    _originPosition = transform.position;
  }

  void Update()
  {
    if (ReferenceResolution.y == 0 || ReferenceResolution.x == 0)
      return;

    var refRatio = ReferenceResolution.x / ReferenceResolution.y;
    var ratio = (float)Screen.width / (float)Screen.height;

    transform.position = _originPosition + (1f - refRatio / ratio) * ZoomFactor.z * transform.forward
                                        + (1f - refRatio / ratio) * ZoomFactor.x * transform.right
                                        + (1f - refRatio / ratio) * ZoomFactor.y * transform.up;
  }
}
