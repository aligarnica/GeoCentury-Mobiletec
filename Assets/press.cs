using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class press : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (algo ());
	}
	
	// Update is called once per frame
	void Update () {

	}
	IEnumerator algo()
	{
		yield return new WaitForSeconds (5);
		Application.LoadLevel ("MenuPrincipal");
	}
}
