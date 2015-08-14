using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PlayerPrefs = PreviewLabs.PlayerPrefs;

public class Preregistro : MonoBehaviour {
	public GameObject campre;
	public GameObject campri;
	public GameObject camreg;
	public Button Invitado;
	public Button Colegio;
	public Button Volver;

	// Use this for initialization
	void Start () {
		Invitado.onClick.AddListener(delegate () { this.invitadosclick(); });
		Colegio.onClick.AddListener(delegate () { this.Colegios(); });
		Volver.onClick.AddListener(delegate () { this.atras(); });

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void invitados () {
		PlayerPrefs.SetString ("Inv","SI");
		PlayerPrefs.Flush ();
		Application.LoadLevel ("juego");
	}
	public void Colegios () {
		campre.SetActive (false);
		campri.SetActive (false);
		camreg.SetActive (true);
	}
	public void invitadosclick () {
		PlayerPrefs.SetString ("Inv","SI");
		PlayerPrefs.Flush ();
		Application.LoadLevel ("juego");
	}
	public void atras () {
		campre.SetActive (false);
		campri.SetActive (true);
		camreg.SetActive (false);
	}
}
