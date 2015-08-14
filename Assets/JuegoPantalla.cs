using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using PlayerPrefs = PreviewLabs.PlayerPrefs;

public class JuegoPantalla : MonoBehaviour {
	public Button X;
	public Text puntos;
	public Text bien1;
	public Text bien2;
	public Text bien3;
	public Text bien4;
	public GameObject gate1;
	public GameObject gate2;
	public GameObject gate3;
	public GameObject gate4;
	public GameObject camjue;
	public GameObject campre;
	public Transform _robot1;
	public Transform _robot2;
	public Transform _robot3;
	public Transform _robot4;
	public Transform _robot5;
	public Transform _playersetuptrans;
	// Use this for initialization
	void Start () {
		X.onClick.AddListener(delegate () { this.Xclick(); });
		X.enabled = false;
		X.GetComponentInChildren<CanvasRenderer>().SetAlpha(0);
		X.GetComponentInChildren<Text>().color = Color.clear;
	}
	public void Xclick()
	{
		string id="5";
		if (Vector3.Distance (_robot1.localPosition, _playersetuptrans.localPosition) < 5f) {
			id="1";
			
		} 
		if (Vector3.Distance (_robot2.localPosition, _playersetuptrans.localPosition) < 5f) {
			id="2";
		} 
		if (Vector3.Distance (_robot3.localPosition, _playersetuptrans.localPosition) < 5f) {
			id="3";
			
		} 
		if (Vector3.Distance (_robot4.localPosition, _playersetuptrans.localPosition) < 5f) {
			id="4";
		} 
		if (Vector3.Distance (_robot5.localPosition, _playersetuptrans.localPosition) < 3f) {
			id="5";
		}
		PlayerPrefs.SetString ("PRE", id);
		string url = "";
		WWWForm form = new WWWForm();
		url = "http://" + PlayerPrefs.GetString ("IPSERVER") + "/";
		string customUrl = url+ "5Preguntas.aspx";
		Debug.Log(customUrl);
		Debug.Log(id);
		//Setup the paramaters
		form.AddField("UserID", id);
		if(PlayerPrefs.GetString("Inv")=="SI")
			form.AddField("tabla", "tbPreguntasInvitados");
			
		else
			form.AddField("tabla", "tbPreguntasAlumnos");
		WWW www = new WWW(customUrl, form);
		StartCoroutine(WaitForRequest(www));
	}
	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		
		// check for errors
		if (www.error == null)
		{
			string [] split =  www.text.Split(',');
			int i=0;
			Debug.Log (www.text);
			foreach (string s in split)
			{
				try
				{

					PlayerPrefs.SetString ("campo" + i.ToString () ,s);
					Debug.Log ("campo" + i.ToString () );
					Debug.Log (s);


					i=i+1;


			//write data returned from ASP.NET

			
				}
				catch
				{

				}
			}
			PlayerPrefs.SetFloat ("startime",Time.time);
			PlayerPrefs.SetBool ("corretiempo",true);
			PlayerPrefs.SetBool ("PrimeraPregunta",true);
			PlayerPrefs.Flush ();
			camjue.SetActive (false);
			campre.SetActive (true);
		}
		else {

		}
	}

		// Update is called once per frame
	void Update () {
		puntos.text = "PUNTOS: " + PlayerPrefs.GetInt ("puntaje").ToString ();
		if(bien1.color==Color.green && bien2.color==Color.green && bien3.color==Color.green && bien4.color==Color.green )
		{
			Destroy (gate1);
			Destroy (gate2);
			Destroy (gate3);
			Destroy (gate4);
		}
	}
}
