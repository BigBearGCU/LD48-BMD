using UnityEngine;
using System.Collections;

public class MagnetScript : MonoBehaviour {

	public int currentForce=0;
	public int maxForce=10;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown(gameObject.name+"Pos"))
		{
			currentForce+=1;
		}
		else if(Input.GetButtonDown(gameObject.name+"Neg"))
		{
			currentForce-=1;
		}
	}

	void OnGUI()
	{
		//percentage, position
	}
}
