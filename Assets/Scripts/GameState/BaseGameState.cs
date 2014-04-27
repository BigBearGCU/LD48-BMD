using UnityEngine;
using System.Collections;

public class BaseGameState : MonoBehaviour {

	public TutorialScript tutScript;
	public AudioClip audioClip;
	public TextMesh textMsg;

	public string message;
	public string keyPress;

	public void Start()
	{
		//message=gameObject.name;
	}

	public virtual void OnEnter()
	{
		tutScript.gameObject.audio.clip=audioClip;
		textMsg.text=message;
	}

	public virtual void OnExit()
	{
		tutScript.OnExitState();
	}

	public virtual void OnUpdate()
	{
	}
}
