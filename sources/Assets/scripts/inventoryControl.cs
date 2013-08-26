using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class inventoryControl : MonoBehaviour 
	{
	public GameObject guiInventory;
	public GameObject guiText;

	public GameObject[] guiItem;
	public Texture2D[] pictures;
	public TextAsset objectListText;

	private int inventoryIndex = 0;

	private List<string> inv = new List<string>();
	private List<string> description = new List<string>();
	
	// Use this for initialization
	void Start () {
		SetVisible(false);
		inv.Add("torch");
		inv.Add("key1");
		inv.Add("medfile_day1");
		inv.Add("medfile_day89");

		string text;

		text = objectListText.text;

		string[] lines = text.Split('\n');

		foreach(string txt in lines)
			{
			string[] t = txt.Split(';');

			if(t.Length == 3)
				{
				foreach(string desc in t)
					description.Add(desc.Replace("|","\n"));
				}
			}
		moveInventory(0);
	}
	
	// Update is called once per frame
	void Update () {
		if(guiInventory.guiTexture.enabled)
			{
 		
			if (Input.GetKeyDown(KeyCode.E)||Input.GetKeyDown(KeyCode.Escape)) 
				{
			    // hide
			   SetVisible(false);
				}

			if (Input.GetKeyDown(KeyCode.Z)||Input.GetKeyDown(KeyCode.W)) 
				{
			    // hide
			   moveInventory(1);
				}

			if (Input.GetKeyDown(KeyCode.S)) 
				{
			    // hide
			   moveInventory(-1);
				}
			}
		else
			{
			if (Input.GetKeyDown(KeyCode.E)) 
				{
    			SetVisible(true);
				}
			}

		}

	private void SetVisible(bool isVisible)
		{
		guiInventory.guiTexture.enabled = isVisible;
		guiText.guiText.enabled = isVisible;
		foreach(GameObject item in guiItem)
			item.guiTexture.enabled = isVisible;		

		}
		

	private string getDescription(string code)
		{
		int index = -1;
		for(int i=0;i<description.Count;i+=3)
			{
			if(code == description[i])
				index =i;
			}
		if(index == -1)
			return "";

		return description[index + 2];
		}

	private string getName(string code)
		{
		int index = -1;
		for(int i=0;i<description.Count;i+=3)
			{
			if(code == description[i])
				index =i;
			}
		if(index == -1)
			return "";

		return description[index + 1];
		}

	private int getIndexTexture(string code)
		{

			if ( code == "key1")
				return 0;
			if ( code == "medfile_day1")
				return 1;
			if ( code == "medfile_day5")
				return 2;
			if ( code == "medfile_day12")
				return 3;
			if ( code == "medfile_day89") 
				return 4;
			if ( code == "torch")
				return 5;
			
		return -1;
		}

	private void moveInventory(int move)
		{
		int index = inventoryIndex + move;

		if(index >= inv.Count)
			index =  index%inv.Count;

		if(index < 0)
			index = inv.Count + index;


		int up_index = (index-1)%inv.Count;

		if(up_index < 0)
			up_index = inv.Count + up_index;

		int down_index = (index+1)%inv.Count;

		if(down_index < 0)
			down_index = inv.Count + down_index;

		int down_index2 = (index+2)%inv.Count;

		if(down_index2 < 0)
			down_index2 = inv.Count + down_index2;

		guiText.guiText.text = getName(inv[index])+"\n\n"+getDescription(inv[index]);

		guiItem[0].guiTexture.texture = pictures[getIndexTexture(inv[up_index])];
		guiItem[1].guiTexture.texture = pictures[getIndexTexture(inv[index])];
		guiItem[2].guiTexture.texture = pictures[getIndexTexture(inv[down_index])];
		guiItem[3].guiTexture.texture = pictures[getIndexTexture(inv[down_index2])];

		inventoryIndex = index;
		}

	public bool isInInventory(string code)
		{
		int index = -1;
		for(int i=0;i<description.Count;i+=3)
			{
			if(code == description[i])
				index =i;
			}
		if(index == -1)
			return false;

		return true;
		}
	}

