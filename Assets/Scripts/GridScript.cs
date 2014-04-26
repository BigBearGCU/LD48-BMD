using UnityEngine;
using System.Collections;

public class GridScript : MonoBehaviour {

	public int NoOfRows;
	public int NoOfColumns;

	public GameObject[] tilePrefabs;

	public int[] tileValues;
	public string testLevelName;
	public MagnetScript topMagnet;
	public MagnetScript leftMagnet;

	public void LoadFromFile(string filename)
	{
		if (System.IO.File.Exists(filename)){
			string[] levelText=System.IO.File.ReadAllLines(filename);
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
		}
		else
		{
			Debug.Log("File dosen't exist");
		}
	}

	void populateMap()
	{
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

			}
		}
	}

	public GameObject GetPixel(int row,int column)
	{
		if (row <NoOfRows && column<NoOfColumns)
			return transform.FindChild(row.ToString()+","+column.ToString()).gameObject;
		return null;
	}

	// Use this for initialization
	void Start () {
		LoadFromFile(Application.dataPath+"/"+testLevelName+".txt");
		populateMap();
		topMagnet.maxForce=NoOfRows-1;
		leftMagnet.maxForce=NoOfColumns-1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
