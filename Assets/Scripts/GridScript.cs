using UnityEngine;
using System.Collections;
using System;

public class GridScript : MonoBehaviour {

	public int NoOfRows;
	public int NoOfColumns;

	public GameObject[] tilePrefabs;
	public Transform answerTiles;

	public int[] tileValues;
	public string currentLevelName;
	public int noOfPixelsToFill;

	public void LoadLevel()
	{
		TextAsset level=(TextAsset)Resources.Load(currentLevelName);
		Debug.Log(level.text);
		string[] levelText=level.text.Split(new string[]{"\n","\r\n","\r"},StringSplitOptions.None);
	
		BuildGrd(levelText);

	}

	public bool CanPlace(int row,int column)
	{
		return transform.FindChild(row.ToString()+","+column.ToString()).gameObject.transform.childCount>0;
	}

	public bool Place(int row,int column,GameObject fullPixel)
	{
		Transform place=transform.FindChild(row.ToString()+","+column.ToString()).gameObject.transform;
		fullPixel.transform.position=place.position;
		fullPixel.transform.parent=answerTiles;
		Destroy(place.GetChild(0).gameObject);
		noOfPixelsToFill--;

		return true;
	}

	public bool GridComplete()
	{
		return noOfPixelsToFill==0;
	}

	void BuildGrd(string[] levelText)
	{
		NoOfRows=levelText.Length;
		NoOfColumns=levelText[0].Split(',').Length;
		tileValues=new int[NoOfRows*NoOfColumns];
		for(int row=0;row<levelText.Length;++row)
		{
			string[] tileIDs=levelText[row].Split(',');
			for (int columns=0;columns<NoOfColumns;++columns)
			{
				int currentIndex=row+(columns*NoOfRows);
				tileValues[currentIndex]=int.Parse(tileIDs[columns]);

			}
		}
		populateMap();
	}

	void LoadFromWWW(string url)
	{
		WWW request=new WWW(url);
		while(!request.isDone)
		{

		}

		string[] levelText=request.text.Split('\n');
		BuildGrd(levelText);
	}
	void LoadFromFile(string filename)
	{
		if (System.IO.File.Exists(filename)){
			string[] levelText=System.IO.File.ReadAllLines(filename);
			BuildGrd(levelText);
		}
		else
		{
			Debug.Log("File dosen't exist");
		}
	}

	void populateMap()
	{
		for(int i=0;i<transform.childCount;++i)
		{
			Destroy(transform.GetChild(i).gameObject);
		}

		Vector3 startPos=transform.position;
		startPos.x-=NoOfColumns/2;
		startPos.y+=NoOfRows/2;
		Vector3 pos=Vector3.zero;
		for (int i=0;i<tileValues.Length;++i)
		{
			int currentRow=i%NoOfRows;
			int currentColumn=i/NoOfRows;

			pos.x=startPos.x+currentColumn;
			pos.y=startPos.y-currentRow;
			GameObject obj=(GameObject)Instantiate(tilePrefabs[0]);
			obj.name=currentRow.ToString()+","+currentColumn.ToString();
			obj.transform.position=pos;
			obj.transform.parent=transform;
			if (tileValues[i]==1)
			{
				GameObject placeHolder=(GameObject)Instantiate(tilePrefabs[1]);
				placeHolder.name=currentRow.ToString()+","+currentColumn.ToString();
				placeHolder.transform.position=pos;
				placeHolder.transform.parent=obj.transform;
				noOfPixelsToFill++;

			}
		}
		for(int i=0;i<answerTiles.childCount;++i)
		{
			Destroy(answerTiles.GetChild(i).gameObject);
		}
	}

	public GameObject GetPixel(int row,int column)
	{
		if ((row <NoOfRows && row>=0) && (column>=0 && column<NoOfColumns))
			return transform.FindChild(row.ToString()+","+column.ToString()).gameObject;
		return null;
	}

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
