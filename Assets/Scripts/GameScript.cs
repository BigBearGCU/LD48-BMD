using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameScript : MonoBehaviour {

	public enum GameState
	{
		StartLevel=0,
		PlayingLevel,
		EndLevel,
		EndGame,
	};

	public GameState currentGameState=GameState.StartLevel;
	public float timeLimit=120;
	public float currentTime=0;
	public bool startedGame=false;

	public int currentScore=0;

	public MagnetScript topMagnet;
	public MagnetScript leftMagnet;
	public GunScript gun;
	public GridScript grid;

	public TextMesh scoreText;
	public TextMesh timeText;

	public TextMesh gameText;

	public List<string> levelNames;
	public int currentLevelNumber=0;

	public string restartMsg="Press C to Continue or R to Restart Level";

	// Use this for initialization
	void Start () {
		StartGame();
		gameText.text=restartMsg;
		gameText.renderer.sortingOrder=3;
		gameText.renderer.sortingLayerName="Foreground";
	}
	
	// Update is called once per frame
	void Update () {
		if (currentGameState==GameState.PlayingLevel){
			currentTime-=Time.deltaTime;
			if (grid.GridComplete() || currentTime<0)
			{
				currentGameState=GameState.EndLevel;
				EndLevel();
			}
			scoreText.text=currentScore.ToString();
			timeText.text=string.Format("{0:0}:{1:00}",currentTime/60,currentTime%60);
		}

		if (currentGameState==GameState.EndLevel)
		{

			gameText.gameObject.SetActive(true);
			grid.gameObject.SetActive(false);
			topMagnet.gameObject.SetActive(false);
			leftMagnet.gameObject.SetActive(false);
			gun.gameObject.SetActive(false);
			if (Input.GetButtonDown("Continue"))
			{
				if(currentLevelNumber<levelNames.Count-1)
				{
					StartLevel();
				}
				else
				{
					PlayerPrefs.SetInt("Score",currentScore);
					Application.LoadLevel("ScoreScreen");
				}
			}
			else if(Input.GetButtonDown("Restart"))
			{
				currentLevelNumber--;
				currentScore=0;
				StartLevel();
			}
		}
		if (currentGameState==GameState.EndGame)
		{
			if (Input.GetButtonDown("Restart"))
			{
				StartGame();
			}
		}
	}

	public void StartGame()
	{
		currentLevelNumber=0;
		grid.gameObject.SetActive(true);
		topMagnet.gameObject.SetActive(true);
		leftMagnet.gameObject.SetActive(true);
		gun.gameObject.SetActive(true);
		gameText.gameObject.SetActive(false);
		currentTime=timeLimit;
		currentScore=0;
		grid.currentLevelName=levelNames[currentLevelNumber];
		grid.LoadLevel();
		topMagnet.maxForce=grid.NoOfRows-1;
		leftMagnet.maxForce=grid.NoOfColumns-1;
		topMagnet.currentForce=0;
		leftMagnet.currentForce=0;;
		gun.targetPixelColumn=0;
		gun.targetPixelRow=0;
		startedGame=true;
		currentGameState=GameState.PlayingLevel;
	}

	public void EndLevel()
	{

		if(currentLevelNumber>levelNames.Count-1)
		{

		}
		else
			currentLevelNumber++;
	}

	public void StartLevel()
	{
		Debug.Log("Start Level");
		grid.gameObject.SetActive(true);
		topMagnet.gameObject.SetActive(true);
		leftMagnet.gameObject.SetActive(true);
		gun.gameObject.SetActive(true);
		gameText.gameObject.SetActive(false);
		currentTime=timeLimit;
		grid.currentLevelName=levelNames[currentLevelNumber];
		grid.LoadLevel();
		topMagnet.maxForce=grid.NoOfRows-1;
		leftMagnet.maxForce=grid.NoOfColumns-1;
		topMagnet.currentForce=0;
		leftMagnet.currentForce=0;;
		gun.targetPixelColumn=0;
		gun.targetPixelRow=0;
		startedGame=true;
		currentGameState=GameState.PlayingLevel;
	}

	public void AddScore(int score)
	{
		currentScore+=score;
	}

	public void SubtractScore(int score)
	{
		currentScore-=score;
	}
}
