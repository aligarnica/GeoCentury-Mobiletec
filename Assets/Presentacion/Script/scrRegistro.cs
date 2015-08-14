using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using PlayerPrefs = PreviewLabs.PlayerPrefs;


public class scrRegistro : MonoBehaviour {
	public InputField nombre;
	public InputField pin;
	public InputField colegio;
	public InputField colegio2;
	public GameObject colB;
	public GameObject col;
	public Button Aceptar;
	public Button Cancelar;
	public GameObject Camreg;
	public GameObject campre;
	private string id;
	private bool NC=false;
	// Use this for initialization
	void Start () {
		colegio2.text="";
		colB.SetActive (true);
		col.SetActive (false);
		pin.onEndEdit.AddListener((value) => cambiopin(value));
		Aceptar.onClick.AddListener(delegate () { this.aceptarclick(); });
		Cancelar.onClick.AddListener(delegate () { this.cancelarclick(); });
	}
	public void cambiopin(string name) {
		if (pin.text.StartsWith ("pint")) {
			if(pin.text=="pint133")
			{
				NC=true;
				colegio.text="";
				col.SetActive (true);
				colB.SetActive (false);

			}
			else
			{
				NC=false;
				colegio2.text="";
				colB.SetActive (true);
				col.SetActive (false);
				string [] split =  pin.text.Split('t');
				foreach (string s in split)
				{
					try
					{
						id = s;
					}
					catch{

					}
				}
				WWWForm form = new WWWForm ();
				string url;
				url = "http://" + PlayerPrefs.GetString ("IPSERVER") + "/";
				string customUrl = url + "VerColegioporPIN.aspx";

			//Setup the paramaters
				form.AddField ("UserID", pin.text);

		
			//Call the server
				WWW www = new WWW (customUrl, form);
				StartCoroutine (WaitForRequest (www));
			}
		}
	}
	public void aceptarclick() {
		if (nombre.text == "" || colegio.text + colegio2.text == "") {

			GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), "Faltan espacios requeridos");
		} 
		else {
			if(NC)
			{
				WWWForm form2 = new WWWForm ();
				string url2;
				url2 = "http://" + PlayerPrefs.GetString ("IPSERVER") + "/";
				string customUrl2 = url2 + "NuevoColegio.aspx";
				
				//Setup the paramaters
				form2.AddField ("UserID", colegio2.text);
				
				
				//Call the server
				WWW www2 = new WWW (customUrl2, form2);
				StartCoroutine (WaitForRequest2 (www2));
			}
			else{
				PlayerPrefs.SetString ("nombre",nombre.text);
				Debug.Log ("NuevoID: " + id);
				PlayerPrefs.SetString ("id",id);
				PlayerPrefs.SetString ("idColegio",id);
				PlayerPrefs.SetString ("colegio",colegio.text + colegio2.text);
				PlayerPrefs.SetString ("Inv","NO");
				PlayerPrefs.Flush ();
				Debug.Log (PlayerPrefs.GetString ("nombre"));
				Debug.Log (PlayerPrefs.GetString ("id"));
				Debug.Log (PlayerPrefs.GetString ("colegio"));
				Application.LoadLevel ("juego");
			}

		}

	}
	public void cancelarclick() {
		Camreg.SetActive (false);
		campre.SetActive (true);
	}
	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		
		// check for errors
		if (www.error == null)
		{
			colegio.text=www.text;
			//write data returned from ASP.NET
			
			
		} else {

		}
	}
	IEnumerator WaitForRequest2(WWW www2)
	{
		yield return www2;
		
		// check for errors
		if (www2.error == null)
		{
			id=www2.text;
			PlayerPrefs.SetString ("nombre",nombre.text);
			Debug.Log ("NuevoID: " + id);
			PlayerPrefs.SetString ("idColegio",id);
			PlayerPrefs.SetString ("colegio",colegio.text + colegio2.text);
			PlayerPrefs.SetString ("Inv","NO");

			PlayerPrefs.Flush ();
			Debug.Log (PlayerPrefs.GetString ("nombre"));
			Debug.Log (PlayerPrefs.GetString ("id"));
			Debug.Log (PlayerPrefs.GetString ("colegio"));
			Application.LoadLevel ("juego");
			//write data returned from ASP.NET
			
			
		} else {
			id=www2.text;
			PlayerPrefs.SetString ("nombre",nombre.text);
			Debug.Log ("NuevoID: " + id);
			PlayerPrefs.SetString ("idColegio",id);
			PlayerPrefs.SetString ("colegio",colegio.text + colegio2.text);
			Debug.Log(PlayerPrefs.GetString ("idColegio"));
			PlayerPrefs.SetString ("idColegio",pin.text);
			PlayerPrefs.SetString ("Inv","NO");
			PlayerPrefs.Flush ();
			Debug.Log (PlayerPrefs.GetString ("nombre"));
			Debug.Log (PlayerPrefs.GetString ("id"));
			Debug.Log (PlayerPrefs.GetString ("colegio"));
			Application.LoadLevel ("juego");
		}
	}
	// Update is called once per frame
	void Update () {
	
	}
}
