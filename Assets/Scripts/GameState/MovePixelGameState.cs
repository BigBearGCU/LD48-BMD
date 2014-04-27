using UnityEngine;
using System.Collections;

public class MovePixelGameState : BaseGameState {

	public float waitTime=0.5f;

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
			//OnExit();
			StartCoroutine(WaitAndExitState());
			OnExit();
		}
	}

	IEnumerator WaitAndExitState()
	{
		yield return new WaitForSeconds(waitTime); 
	}

	public override void OnExit ()
	{
		base.OnExit ();
		
	}
}
