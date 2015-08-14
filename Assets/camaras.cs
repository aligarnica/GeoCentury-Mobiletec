using UnityEngine;
using System.Collections;

public class camaras : MonoBehaviour {
	public GameObject CamaraPreguntas;
	public GameObject CamaraJuego;
	// Use this for initialization
	void Start () {
		CamaraPreguntas.SetActive (false);
		CamaraJuego.SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
