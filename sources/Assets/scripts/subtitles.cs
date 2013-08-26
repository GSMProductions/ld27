using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class subtitles : MonoBehaviour {
	public TextAsset monolog;

	private List<string> code = new List<string>();
	private List<string> text = new List<string>();
	private float time = 0f;

	// Use this for initialization
	void Start () {
		string m_text = monolog.text;

		string[] lines = m_text.Split('\n');

		foreach(string txt in lines)
			{
			string[] t = txt.Split(';');

			if(t.Length == 2)
				{
				
				code.Add(t[0]);
				text.Add(t[1]);
				}
			}

	//for test
	display("ecran_noir",2f);
	
	}
	void Update () {

		float dt = Time.deltaTime;
		time -= dt;

		if(time <= 0f)
			{
			time = 0f;
			guiText.text=getText("none");
			}
		
	}

	public void display(string code, float t)
		{
		time = t;
		guiText.text=getText(code);
		}


	private string getText(string c)
		{
			int index = -1;

			for(int i=0;i<code.Count;i++)
				if(code[i] == c)
					index = i;

			if(index == -1)
				return "";
			
			return text[index];
		}

}
