using UnityEngine;
using System.Collections;
using UnityEngine.UI;

using PlayerPrefs = PreviewLabs.PlayerPrefs;

public class scrRanking : MonoBehaviour {
	public Text top1;
	public Text top2;
	public Text top3;
	public Text top4;
	public Text top5;
	public Text top6;
	public Text top7;
	public Text top8;
	public Text top9;
	public Text top10;
	public GameObject camprin;
	public GameObject camran;
	public Button volverRank;
	private string url="";
	private string top;
	// Use this for initialization
	void Start () {
		volverRank.onClick.AddListener(delegate () { this.volverRankclick(); });
		WWWForm form = new WWWForm();
		//url = "http://" + PlayerPrefs.GetString ("IPSERVER") + "/";
		url = "http://" + PlayerPrefs.GetString ("IPSERVER") + "/";
		string customUrl = url+ "Ranking.aspx";

		//Setup the paramaters

		form.AddField ("UserID", 1);
		//Call the server
		WWW www = new WWW (customUrl, form);

		StartCoroutine (WaitForRequest (www));

	}
	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;
		// check for errors
		if (www.error == null)
		{
			int i = 1;
			Debug.Log (www.text);
			string [] split = www.text.Split(';');
			foreach (string s in split) {
				
				if (s.Trim() != "")
				{
					if(i==1)
						top1.text=s;
					if(i==2)
						top2.text=s;
					if(i==3)
						top3.text=s;
					if(i==4)
						top4.text=s;
					if(i==5)
						top5.text=s;
					if(i==6)
						top6.text=s;
					if(i==7)
						top7.text=s;
					if(i==8)
						top8.text=s;
					if(i==9)
						top9.text=s;
					if(i==10)
						top10.text=s;
				}
				
				i=i+1;
			}

		}
	}
	// Update is called once per frame
	void Update () {
		WWWForm form = new WWWForm();
		//url = "http://" + PlayerPrefs.GetString ("IPSERVER") + "/";
		url = "http://" + PlayerPrefs.GetString ("IPSERVER") + "/";
		string customUrl = url+ "Ranking.aspx";
		
		//Setup the paramaters
		
		form.AddField ("UserID", 1);
		//Call the server
		WWW www = new WWW (customUrl, form);
		
		StartCoroutine (WaitForRequest (www));

	}

	public void volverRankclick () {
		camprin.SetActive(true);
		camran.SetActive(false);
	}
}
