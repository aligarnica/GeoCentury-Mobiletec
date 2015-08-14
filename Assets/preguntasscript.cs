using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using PlayerPrefs = PreviewLabs.PlayerPrefs;

public class preguntasscript : MonoBehaviour {
	public Button Salir;
	public Text tiempo;
	public Text puntaje;
	public Text valoracion;
	public int i=0;
	public int bien;
	public string res="0";
	public Button Pregunta;
	public Button Respuesta1;
	public Button Respuesta2;
	public Button Respuesta3;
	public Button Respuesta4;
	public GameObject camjue;
	public GameObject campre;
	public Text bien1;
	public Text bien2;
	public Text bien3;
	public Text bien4;
	public GameObject cambes;

	// Use this for initialization
	void Start () {
		Salir.onClick.AddListener(delegate () { this.Salirclick(); });
		Respuesta1.onClick.AddListener(delegate () { this.Respuesta1click(); });
		Respuesta2.onClick.AddListener(delegate () { this.Respuesta2click(); });
		Respuesta3.onClick.AddListener(delegate () { this.Respuesta3click(); });
		Respuesta4.onClick.AddListener(delegate () { this.Respuesta4click(); });
		PlayerPrefs.SetBool ("corretiempo", false);
		PlayerPrefs.SetInt ("segundos", 300);
		PlayerPrefs.SetInt ("suma2", 0);
		PlayerPrefs.SetInt ("puntaje", 0);

	}
	
	// Update is called once per frame
	void Update () {
		puntaje.text=PlayerPrefs.GetInt("puntaje").ToString();
		if (PlayerPrefs.GetBool ("corretiempo")) {
			PlayerPrefs.SetInt("suma",((int)Time.time - (int)PlayerPrefs.GetFloat ("startime")));
			tiempo.text = minutos (PlayerPrefs.GetInt("segundos")-PlayerPrefs.GetInt("suma2")-PlayerPrefs.GetInt("suma"));
			if (PlayerPrefs.GetBool ("PrimeraPregunta")) {
				Pregunta.GetComponentInChildren<Text>().text=PlayerPrefs.GetString ("campo" + i.ToString ());
				i=i+1;
				res=PlayerPrefs.GetString ("campo" + i.ToString ());
				i=i+1;
				Respuesta1.GetComponentInChildren<Text>().text=PlayerPrefs.GetString ("campo" + i.ToString ());
				i=i+1;
				Respuesta2.GetComponentInChildren<Text>().text=PlayerPrefs.GetString ("campo" + i.ToString ());
				i=i+1;
				Respuesta3.GetComponentInChildren<Text>().text=PlayerPrefs.GetString ("campo" + i.ToString ());
				i=i+1;
				Respuesta4.GetComponentInChildren<Text>().text=PlayerPrefs.GetString ("campo" + i.ToString ());
				i=i+1;
				PlayerPrefs.SetBool ("PrimeraPregunta",false);
			}
			if(PlayerPrefs.GetInt("segundos")-PlayerPrefs.GetInt("suma2")-PlayerPrefs.GetInt("suma") <=0)
			{
				valoracion.color = Color.white;
				PlayerPrefs.SetBool ("corretiempo",false);
				valoracion.text = "Se acabo el tiempo";
				StartCoroutine (JuegoTerminado());
			}

			if(PlayerPrefs.GetString ("PRE")=="1" && bien>=3)
				bien1.color=Color.green;
			if(PlayerPrefs.GetString ("PRE")=="2" && bien>=3)
				bien2.color=Color.green;
			if(PlayerPrefs.GetString ("PRE")=="3" && bien>=3)
				bien3.color=Color.green;
			if(PlayerPrefs.GetString ("PRE")=="4" && bien>=3)
				bien4.color=Color.green;
		}


	}
	public void Respuesta1click(){
		if (res == "1") {
			valoracion.color = Color.green;
			valoracion.text = "Buena";
			bien=bien+1;
			if (PlayerPrefs.GetString ("PRE") == "5") {
				PlayerPrefs.SetInt ("puntaje", PlayerPrefs.GetInt ("puntaje") + 50);
			} else {
				PlayerPrefs.SetInt ("puntaje", PlayerPrefs.GetInt ("puntaje") + 20);
			}
		} else {
			valoracion.color = Color.red;
			valoracion.text = "Mala";
		}
		if (i >= 30 && PlayerPrefs.GetString ("PRE") != "5") {
			PlayerPrefs.SetBool ("corretiempo", false);
			PlayerPrefs.Flush ();
			StartCoroutine (PregTer ());

		} else if (i >= 120 && PlayerPrefs.GetString ("PRE") == "5") {
			PlayerPrefs.SetBool ("corretiempo",false);
			valoracion.color = Color.white;
			valoracion.text = "WOW TERMINASTE ANTES +500";
			PlayerPrefs.SetInt ("puntaje", PlayerPrefs.GetInt ("puntaje") + 500);
			StartCoroutine (JuegoTerminado ());
		} else {
			PlayerPrefs.SetBool ("PrimeraPregunta",true);
		}
	}
	public void Respuesta2click(){
		if (res == "2") {
			valoracion.color = Color.green;
			valoracion.text = "Buena";
			bien=bien+1;
			if (PlayerPrefs.GetString ("PRE") == "5") {
				PlayerPrefs.SetInt ("puntaje", PlayerPrefs.GetInt ("puntaje") + 50);
			} else {
				PlayerPrefs.SetInt ("puntaje", PlayerPrefs.GetInt ("puntaje") + 20);
			}
		} else {
			valoracion.color = Color.red;
			valoracion.text = "Mala";
		}
		if (i >= 30 && PlayerPrefs.GetString ("PRE") != "5") {
			PlayerPrefs.SetBool ("corretiempo", false);
			PlayerPrefs.Flush ();
			StartCoroutine (PregTer ());
			
		} else if (i >= 120 && PlayerPrefs.GetString ("PRE") == "5") {
			PlayerPrefs.SetBool ("corretiempo",false);
			valoracion.color = Color.white;
			valoracion.text = "WOW TERMINASTE ANTES +500";
			PlayerPrefs.SetInt ("puntaje", PlayerPrefs.GetInt ("puntaje") + 500);
			StartCoroutine (JuegoTerminado ());
		} else {
			PlayerPrefs.SetBool ("PrimeraPregunta",true);
		}
	}
	public void Respuesta3click(){
		if (res == "3") {
			valoracion.color = Color.green;
			valoracion.text = "Buena";
			bien=bien+1;
			if (PlayerPrefs.GetString ("PRE") == "5") {
				PlayerPrefs.SetInt ("puntaje", PlayerPrefs.GetInt ("puntaje") + 50);
			} else {
				PlayerPrefs.SetInt ("puntaje", PlayerPrefs.GetInt ("puntaje") + 20);
			}
		} else {
			valoracion.color = Color.red;
			valoracion.text = "Mala";
		}
		if (i >= 30 && PlayerPrefs.GetString ("PRE") != "5") {
			PlayerPrefs.SetBool ("corretiempo", false);
			PlayerPrefs.Flush ();
			StartCoroutine (PregTer ());
			
		} else if (i >= 120 && PlayerPrefs.GetString ("PRE") == "5") {
			PlayerPrefs.SetBool ("corretiempo",false);
			valoracion.color = Color.white;
			valoracion.text = "WOW TERMINASTE ANTES +500";
			PlayerPrefs.SetInt ("puntaje", PlayerPrefs.GetInt ("puntaje") + 500);
			StartCoroutine (JuegoTerminado ());
		} else {
			PlayerPrefs.SetBool ("PrimeraPregunta",true);
		}
	}
	public void Respuesta4click(){
		if (res == "4") {
			valoracion.color = Color.green;
			valoracion.text = "Buena";
			bien=bien+1;
			if (PlayerPrefs.GetString ("PRE") == "5") {
				PlayerPrefs.SetInt ("puntaje", PlayerPrefs.GetInt ("puntaje") + 50);
			} else {
				PlayerPrefs.SetInt ("puntaje", PlayerPrefs.GetInt ("puntaje") + 20);
			}
		} else {
			valoracion.color = Color.red;
			valoracion.text = "Mala";
		}
		if (i >= 30 && PlayerPrefs.GetString ("PRE") != "5") {
			PlayerPrefs.SetBool ("corretiempo", false);
			PlayerPrefs.Flush ();
			StartCoroutine (PregTer ());
			
		} else if (i >= 120 && PlayerPrefs.GetString ("PRE") == "5") {
			PlayerPrefs.SetBool ("corretiempo",false);
			valoracion.color = Color.white;
			valoracion.text = "WOW TERMINASTE ANTES +500";
			PlayerPrefs.SetInt ("puntaje", PlayerPrefs.GetInt ("puntaje") + 500);
			StartCoroutine (JuegoTerminado ());
		} else {
			PlayerPrefs.SetBool ("PrimeraPregunta",true);
		}
	}

	private string minutos(int num)
	{
		int  min, seg;
		min = ((num) / 60);  
		seg = num - (min * 60);  
		if (seg >= 10) {
			return min.ToString() + ":" + seg.ToString();
		}
		else
			return min.ToString() + ":0" + seg.ToString();

	}
	IEnumerator PregTer()
	{
		yield return new WaitForSeconds (2);
		valoracion.color = Color.white;
		valoracion.text = "veamos";
		PlayerPrefs.SetInt ("suma2",PlayerPrefs.GetInt("suma2")+ PlayerPrefs.GetInt("suma"));
		i = 0;
		bien=0;
		res = "0";
		camjue.SetActive (true);
		campre.SetActive (false);

	}
	IEnumerator JuegoTerminado()
	{
		yield return new WaitForSeconds (2);
		if (PlayerPrefs.GetString ("Inv") != "SI") {
			string url = "";
			WWWForm form = new WWWForm ();
			url = "http://" + PlayerPrefs.GetString ("IPSERVER") + "/";
			string customUrl = url + "InsertarAlumno.aspx";


			form.AddField ("Alumno", PlayerPrefs.GetString ("nombre"));
			form.AddField ("Colegio", PlayerPrefs.GetString ("idColegio"));
			form.AddField ("score", PlayerPrefs.GetInt ("puntaje").ToString ());

			WWW www = new WWW (customUrl, form);
			PlayerPrefs.Flush ();
			StartCoroutine (WaitForRequest (www));
		} else 
		{
			try{
				if (PlayerPrefs.GetInt("best")<PlayerPrefs.GetInt ("puntaje"))
				{
					PlayerPrefs.SetInt("best",PlayerPrefs.GetInt ("puntaje"));
					cambes.SetActive (true);
					campre.SetActive (false);
				}
				else
					Application.LoadLevel ("MenuPrincipal");
			}
			catch{
				PlayerPrefs.SetInt("best",PlayerPrefs.GetInt ("puntaje"));
				cambes.SetActive (true);
				campre.SetActive (false);
			}

		}
		
	}
	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		
		// check for errors
		if (www.error == null)
		{
			Application.LoadLevel ("MenuPrincipal");

		}
		else {
			Application.LoadLevel ("MenuPrincipal");
		}
	}
	
	// Update is called once per frame
	public void Salirclick()
	{
		try{
			if (PlayerPrefs.GetInt("best")<PlayerPrefs.GetInt ("puntaje"))
			{
				PlayerPrefs.SetInt("best",PlayerPrefs.GetInt ("puntaje"));
				cambes.SetActive (true);
				campre.SetActive (false);
			}
			else
				Application.LoadLevel ("MenuPrincipal");
		}
		catch{
			PlayerPrefs.SetInt("best",PlayerPrefs.GetInt ("puntaje"));
			cambes.SetActive (true);
			campre.SetActive (false);
		}
	}
}
