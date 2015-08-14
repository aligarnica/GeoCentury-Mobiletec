using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using PlayerPrefs = PreviewLabs.PlayerPrefs;

public class ConfigServidores : MonoBehaviour {

	private string url;
	public Button aceptar;
	public Button volver;
	public InputField ip;
	public Text conec;
	public GameObject cammen;
	public GameObject camcon;


	// Use this for initialization
	void Start () {
		aceptar.onClick.AddListener(delegate () { this.aceptarclick(); });
		volver.onClick.AddListener(delegate () { this.volverclick(); });
		conec.color = Color.white;
		conec.text = "";
		try
		{
			ip.text = PlayerPrefs.GetString ("IPSERVER");
		}
		catch{

		}
			}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void volverclick () {
		cammen.SetActive (true);
		camcon.SetActive (false);
	}

	public void aceptarclick () {
		conec.color = Color.white;
		conec.text = "Probando";
		WWWForm form = new WWWForm();
		url = "http://" + ip.text + "/";
		string customUrl = url+ "prueba.aspx";
		Debug.Log(customUrl);
		//Setup the paramaters
		form.AddField("UserID", "47");
		form.AddField("Score", "100");
		
		//Call the server
		WWW www = new WWW(customUrl, form);
		StartCoroutine(WaitForRequest(www));
	}
	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		
		// check for errors
		if (www.error == null)
		{
			PlayerPrefs.SetString ("IPSERVER",ip.text);
			PlayerPrefs.Flush();
			conec.color = Color.green;
			conec.text = "Conectado.";

			//write data returned from ASP.NET

			
		} else {
			conec.color = Color.red;
			conec.text = "No se Puede Conectar.";
		}
	}
	//setup a form


}
