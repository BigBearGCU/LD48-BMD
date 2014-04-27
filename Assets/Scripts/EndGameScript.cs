using UnityEngine;
using System.Collections;

public class EndGameScript : MonoBehaviour {

	public TextMesh scoreTxt;
	// Use this for initialization
	void Start () {
		scoreTxt.text=PlayerPrefs.GetInt("Score",0).ToString();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Restart"))
		{
			Application.LoadLevel("MainMenu");
		}
	}
}
