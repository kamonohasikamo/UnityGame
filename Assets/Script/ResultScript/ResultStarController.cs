using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultStarController : MonoBehaviour
{
	public void EndStarAnimation()
	{
		var parent = this.gameObject.transform.parent.gameObject;
		Destroy(parent);
	}
}
