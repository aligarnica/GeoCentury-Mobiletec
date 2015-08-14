using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
	public Button Empezar;
	public Button Ranking;
	public Button Configurar;
	public Button Salir;
	public GameObject CamMen;
	public GameObject CamRan;
	public GameObject CamReg;
	public GameObject CamPre;
	public GameObject camconf;
	public Text mejor;

	// Use this for initialization
	void Start () {
		Empezar.onClick.AddListener(delegate () { this.EmpezarClick(); });
		Ranking.onClick.AddListener(delegate () { this.RankingClick(); });
		Configurar.onClick.AddListener (delegate () { this.config(); });
		Salir.onClick.AddListener(delegate () { this.SalirClick(); });
		CamRan.SetActive (false);
		CamMen.SetActive (true);
		CamReg.SetActive (false);
		CamPre.SetActive (false);
		camconf.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		try{
			mejor.text = PlayerPrefs.GetString ("nombreBest") + " - " + PlayerPrefs.GetInt ("best");
		}
		catch{
		}

	}

	public void EmpezarClick () {
		CamRan.SetActive (false);
		CamMen.SetActive (false);
		CamReg.SetActive (false);
		CamPre.SetActive (true);
		camconf.SetActive (false);
	}
	public void RankingClick () {
		CamRan.SetActive (true);
		CamMen.SetActive (false);
		CamReg.SetActive (false);
		CamPre.SetActive (false);
		camconf.SetActive (false);

	}
	public void config () {
		CamRan.SetActive (false);
		CamMen.SetActive (false);
		CamReg.SetActive (false);
		CamPre.SetActive (false);
		camconf.SetActive (true);
		
	}
	public void SalirClick () {
		Application.Quit();

	}

}
