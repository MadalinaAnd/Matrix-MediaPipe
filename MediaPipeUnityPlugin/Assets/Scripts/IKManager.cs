using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IKManager : MonoBehaviour
{

	public float THRESHOLD = 0.05f;
	public float RATE = 5.0f;
	public float STEAPS = 20.0f;

	//Root of the armature(red)
	public JointController StartPoint;
	//End effector(blue)
	public JointController EndPoint;
	//References to sphere
	public GameObject Target;

	void Update()
	{
		for (int i = 0; i < STEAPS; ++i)
		{
			float distance1 = GetDistance(EndPoint.transform.position, Target.transform.position);
			if (distance1 > THRESHOLD)
			{
				JointController current = StartPoint;
				while (current != null)
				{
					float slope = CalculateSlope(StartPoint);
					current.Rotate(-slope * RATE);
					current = current.GetChild();
				}

			}
		}
	}

	float CalculateSlope(JointController joint)
	{
		float deltaTime = 0.01f;
		float distance1 = GetDistance(EndPoint.transform.position, Target.transform.position);

		joint.Rotate(deltaTime);
		float distance2 = GetDistance(EndPoint.transform.position, Target.transform.position);

		joint.Rotate(-deltaTime);
		return (distance2 - distance1) / deltaTime;
	}

	float GetDistance(Vector3 point1, Vector3 point2)
	{
		return Vector3.Distance(point1, point2);
	}
}
