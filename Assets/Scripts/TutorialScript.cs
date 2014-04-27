using UnityEngine;
using System.Collections;

public class TutorialScript : GameScript {
	public AudioClip[] tutorialVO;
	public GameObject DeadPixel;
	public GameObject Pixel;

	public int tutorialState=0;
	public BaseGameState[] states;

	public void OnExitState()
	{
		//move to new state
		tutorialState++;
		if (tutorialState>states.Length-1)
		{
			Application.LoadLevel("MainMenu");
		}
			else{
			if (tutorialState==6)
			{
				//show pixel
				Pixel.SetActive(true);

			}
			else if (tutorialState==9)
			{
				DeadPixel.SetActive(true);
			}
			states[(int)tutorialState].OnEnter();
		}
	}

	void Update()
	{
		states[(int)tutorialState].OnUpdate();
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			Application.LoadLevel("MainMenu");
		}
	}

	new public void Start()
	{
		base.Start();

		//Dead Pixel 4 x 4
		DeadPixel=grid.deadPixelholder.GetChild(0).gameObject;
		DeadPixel.SetActive(false);
		gameText.gameObject.SetActive(true);
		states[tutorialState].OnEnter();

		Pixel=grid.GetPixel(2,5).transform.GetChild(0).gameObject;
		Pixel.SetActive(false);
		//OnEnterWelcome();
	}
}
