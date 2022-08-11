using UnityEngine;

public class JointController : MonoBehaviour
{
	public JointController m_child;

	public JointController GetChild()
	{
		return m_child;
	}

	public void Rotate(float angle)
	{
		transform.Rotate(Vector3.up * angle);
	}
}
