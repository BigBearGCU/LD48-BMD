using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunScript : MonoBehaviour {

	public GameObject targetPixel;
	public GridScript grid;

	public int targetPixelRow=0;
	public int targetPixelColumn=0;

	public MagnetScript topMagnet;
	public MagnetScript leftMagnet;

	// Use this for initialization
	void Start () {
		InvokeRepeating("CheckFire",0.1f,2.0f);
	}
	
	// Update is called once per frame
	void Update () {

	}

	void SetTarget(int row,int column)
	{
		GameObject obj=grid.GetPixel(row,column);
		if (obj!=null)
			targetPixel.transform.position=obj.transform.position;
	}

	void CheckFire()
	{
		//TODO: Want it to march down all the time
		targetPixelRow+=topMagnet.currentForce;
		targetPixelColumn+=leftMagnet.currentForce;
		SetTarget(targetPixelRow,targetPixelColumn);
	}
}
