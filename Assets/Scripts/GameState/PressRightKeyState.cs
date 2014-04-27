using UnityEngine;
using System.Collections;

public class PressRightKeyState : BaseGameState {

	public override void OnEnter ()
	{
		base.OnEnter ();
		tutScript.gameObject.audio.Play();
	}
	
	public override void OnUpdate ()
	{
		base.OnUpdate ();
		if (Input.GetButtonDown(keyPress))
		{
			OnExit();
		}
	}
	
	public override void OnExit ()
	{
		base.OnExit ();
		
	}
}
