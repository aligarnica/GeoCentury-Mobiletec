using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using PlayerPrefs = PreviewLabs.PlayerPrefs;

public class mejorInvitado : MonoBehaviour {

	public InputField Nombre;
	public Button guardar;
	public GameObject Salir;
	public GameObject camaras;
	// Use this for initialization
	void Start () {
		guardar.onClick.AddListener(delegate () { this.guardarclick(); });
		camaras.SetActive (false);
		if (PlayerPrefs.GetString ("Inv") != "SI") {
			Salir.SetActive (false);
		}
	}
	
	// Update is called once per frame
	private void guardarclick () {
		PlayerPrefs.SetString ("nombreBest", Nombre.text);
		Application.LoadLevel ("MenuPrincipal");
	}
}
