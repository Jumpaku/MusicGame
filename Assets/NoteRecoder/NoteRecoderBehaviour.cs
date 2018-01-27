using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class NoteRecoderBehaviour : MonoBehaviour {
	public string fileName;
	private AudioSource audioSource;
	private float startTime;
	void Start () {
		audioSource = GetComponent<AudioSource>();
		audioSource.Play();
		startTime = Time.time;
	}
	void Update () {
		DetectKeys();
	}
	private void DetectKeys(){
		if (Input.GetKeyDown (KeyCode.D)) {
            WriteNoteTiming (0);
        }
        if (Input.GetKeyDown (KeyCode.F)) {
            WriteNoteTiming (1);
        }
        if (Input.GetKeyDown (KeyCode.Space)) {
            WriteNoteTiming (2);
        }
        if (Input.GetKeyDown (KeyCode.J)) {
            WriteNoteTiming (3);
        }
        if (Input.GetKeyDown (KeyCode.K)) {
            WriteNoteTiming (4);
        }
	}
	void WriteNoteTiming(int position){
		float time = Time.time - startTime;
        Debug.Log(time +","+ 0 +","+ 0+","+ position +","+ position);
		//叩く時刻, チャンネル, ノーツの種類, 叩く位置, 出現位置
		StreamWriter sw = new FileInfo(Application.dataPath + "/" + fileName).AppendText();
		sw.WriteLine(time +","+ 0 +","+ 0+","+ position +","+ position);
		sw.Flush();
		sw.Close();
    }
}
