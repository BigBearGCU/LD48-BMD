using UnityEngine;
using System.Collections;

public class WelcomeState : BaseGameState {


	public override void OnEnter ()
	{
		base.OnEnter ();
		tutScript.gameObject.audio.Play();
	}

	public override void OnUpdate ()
	{
		base.OnUpdate ();
		if (!tutScript.gameObject.audio.isPlaying)
		{
			OnExit();
		}
	}

	public override void OnExit ()
	{
		base.OnExit ();

	}
}
