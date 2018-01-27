using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CsvEditor : MonoBehaviour {
	public string fileName;
	void Start () {
		//AppendLine("Jumpaku, Test");
	}
	void Update () {	
	}
	public void AppendLine(string line){
		StreamWriter sw = new FileInfo(Application.dataPath + "/" + fileName).AppendText();
		sw.WriteLine(line);
		sw.Flush();
		sw.Close();
	}
}
