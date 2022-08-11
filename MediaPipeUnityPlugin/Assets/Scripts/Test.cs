using UnityEngine;

public class Test : MonoBehaviour
{

  public Transform Target;
  public Transform MediaPipe;

  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    if (Target != null && MediaPipe != null)
    {
      Target.position = MediaPipe.position;
    }
  }
}
