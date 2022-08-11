using Mediapipe.Unity;
using RootMotion.FinalIK;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace MP
{
	[Serializable]
	public struct Pair
	{
		public int AnnotationNumber;
		public Transform IKTarget;
		public Transform MediaPipeTarget;

		public Pair(int annotationNumber, Transform iKTarget, Transform mediaPipeTarget)
		{
			AnnotationNumber = annotationNumber;
			IKTarget = iKTarget;
			MediaPipeTarget = mediaPipeTarget;
		}
	}

	public class MediaIKController : MonoBehaviour
	{
		public PointListAnnotation pointListAnnotation;
		[SerializeField] public List<Pair> Pairs = new List<Pair>();

		private bool wasInstantiated;

		private void Update()
		{
			if (wasInstantiated == false && pointListAnnotation.PointsAnnotation.Count == 33)
			{
				for (int i = 0; i < Pairs.Count; i++)
				{
					var annotation = pointListAnnotation.PointsAnnotation.Find(x => x.name == Pairs[i].AnnotationNumber.ToString());
					Pairs[i] = new Pair(Pairs[i].AnnotationNumber, Pairs[i].IKTarget, annotation.transform);
				}
				wasInstantiated = true;
			}
			else
			{
				foreach (var pair in Pairs)
				{
					pair.IKTarget.position = pair.MediaPipeTarget.position;
				}
			}
		}
	}
}
