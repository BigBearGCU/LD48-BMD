using UnityEngine;
using System.Collections;

public class MagnetScript : MonoBehaviour {

	public bool fired=false;
	public int currentForce=0;
	public int maxForce=10;

	public Material OnMaterial;
	public Material OffMaterial;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown(gameObject.name+"Pos"))
		{
			fired=!fired;
		}

		if(fired)
			Fire();
		else
			Stop();
	}

	void Fire()
	{
		currentForce=1;
		renderer.material=OnMaterial;
		if (!audio.isPlaying){
			audio.Play();
			audio.time=2.0f;
		}
	}

	void Stop()
	{
		currentForce=0;
		renderer.material=OffMaterial;
		audio.Stop();
		audio.time=2.0f;
	}
	void OnGUI()
	{
		//percentage, position

	}
}
