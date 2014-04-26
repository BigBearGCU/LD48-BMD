using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GunScript : MonoBehaviour {

	public GameObject targetPixel;
	public GameObject actualPixel;
	public GridScript grid;

	public int targetPixelRow=0;
	public int targetPixelColumn=0;

	public MagnetScript topMagnet;
	public MagnetScript leftMagnet;
	public GameScript game;

	// Use this for initialization

	void Start () {
		SetTarget(targetPixelRow,targetPixelColumn);
		InvokeRepeating("CheckFire",0.1f,2.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
		{
			if (grid.CanPlace(targetPixelRow,targetPixelColumn))
			{
				grid.Place(targetPixelRow,targetPixelColumn,(GameObject)Instantiate(actualPixel));
				game.AddScore(1);
			}
		}
	}

	void SetTarget(int row,int column)
	{
		GameObject obj=grid.GetPixel(row,column);
		if (obj!=null)
			targetPixel.transform.position=obj.transform.position;


	}
	
	void CheckFire()
	{
		//TODO: Want it to march down all the time?
		if(topMagnet.currentForce!=0 || leftMagnet.currentForce!=0){
			targetPixelRow+=topMagnet.currentForce;
			targetPixelColumn+=leftMagnet.currentForce;
		}
		else if (topMagnet.currentForce==0 && leftMagnet.currentForce==0)
		{
			targetPixelRow--;
			targetPixelColumn--;

		}
		targetPixelColumn=Mathf.Clamp(targetPixelColumn,0,grid.NoOfColumns);
		targetPixelRow=Mathf.Clamp(targetPixelRow,0,grid.NoOfRows);
		SetTarget(targetPixelRow,targetPixelColumn);
	}
}
