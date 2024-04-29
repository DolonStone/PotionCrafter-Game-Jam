using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trailfront : MonoBehaviour
{
	public TrailRenderer trail;

	void Start()
	{
		trail.sortingLayerName = "Background";
		trail.sortingOrder = 2;

	}
}
