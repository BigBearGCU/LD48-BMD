using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {

	public enum GameState
	{
		StartLevel=0,
		PlayingLevel,
		EndLevel,
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

	public GameObject RestartGameMsg;

	// Use this for initialization
	void Start () {
		StartLevel();
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
			RestartGameMsg.SetActive(true);
			grid.gameObject.SetActive(false);
			topMagnet.gameObject.SetActive(false);
			leftMagnet.gameObject.SetActive(false);
			gun.gameObject.SetActive(false);
			if (Input.GetButtonDown("Restart"))
			{
				StartLevel();
			}
		}
	}

	public void EndLevel()
	{

	}

	public void StartLevel()
	{
		grid.gameObject.SetActive(true);
		topMagnet.gameObject.SetActive(true);
		leftMagnet.gameObject.SetActive(true);
		gun.gameObject.SetActive(true);
		RestartGameMsg.SetActive(false);
		currentTime=timeLimit;
		currentScore=0;
		grid.currentLevelName="Level1";
		grid.LoadLevel();
		topMagnet.maxForce=grid.NoOfRows-1;
		leftMagnet.maxForce=grid.NoOfColumns-1;
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
