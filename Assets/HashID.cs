using UnityEngine;
using System.Collections;

public class HashID : MonoBehaviour {

	public int speedFloat;

	// Use this for initialization
	void Awake ()
	{

		speedFloat = Animator.StringToHash("Speed");
	}
}
