using UnityEngine;
using System.Collections;

public class GridCompleteState : BaseGameState {
	
	public override void OnEnter ()
	{
		base.OnEnter ();
		//tutScript.gameObject.audio.Play();
	}
	
	public override void OnUpdate ()
	{
		base.OnUpdate ();
		if (base.tutScript.grid.GridComplete())
		{
			OnExit();
		}
	}
	
	public override void OnExit ()
	{
		base.OnExit ();
	}
}