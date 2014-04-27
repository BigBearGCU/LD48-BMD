using UnityEngine;
using System.Collections;

public class MainMenuScript : MonoBehaviour {

	public TextMesh[] MenuText;
	public int currentSelection=0;

	// Use this for initialization
	void Start () {
		EnableSelection(MenuText[currentSelection]);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("MenuDown"))
		{
			if (currentSelection!=MenuText.Length-1){
				audio.Play();
				DisableSelection(MenuText[currentSelection]);
				currentSelection++;
				EnableSelection(MenuText[currentSelection]);
			}
		}
		else if (Input.GetButtonDown("MenuUp"))
		{
			if (currentSelection!=0)
			{
				audio.Play();
				DisableSelection(MenuText[currentSelection]);
				currentSelection--;
				EnableSelection(MenuText[currentSelection]);
			}
		}

		if (Input.GetButtonDown("MenuSelect"))
		{
			Application.LoadLevel(MenuText[currentSelection].name);
		}

	}
	
	void DisableSelection(TextMesh currentSelection)
	{
		currentSelection.color=Color.white;
	}

	void EnableSelection(TextMesh newSelection)
	{
		newSelection.color=Color.green;

	}
}
