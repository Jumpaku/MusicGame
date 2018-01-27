using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesRecoder : MonoBehaviour {
	public GameObject startButton;
	private AudioSource audioSource;
	private CsvEditor csvEditor;
	private bool isPlaying = false;
	private float startTime;
	void Start () {
		audioSource = GameObject.Find("GameMusic").GetComponent<AudioSource>();
		csvEditor = GameObject.Find("CsvEditor").GetComponent<CsvEditor>();
	}
	void Update () {
		if(!isPlaying){
			return;
		}
		DetectKeys();
	}
	public void StartMusic(){
		startButton.SetActive(false);
		audioSource.Play();
		startTime = Time.time;
        isPlaying = true;
	}
	private void DetectKeys(){
		if (Input.GetKeyDown (KeyCode.D)) {
            WriteNotesTiming (0);
        }
        if (Input.GetKeyDown (KeyCode.F)) {
            WriteNotesTiming (1);
        }
        if (Input.GetKeyDown (KeyCode.Space)) {
            WriteNotesTiming (2);
        }
        if (Input.GetKeyDown (KeyCode.J)) {
            WriteNotesTiming (3);
        }
        if (Input.GetKeyDown (KeyCode.K)) {
            WriteNotesTiming (4);
        }
	}
	void WriteNotesTiming(int position){
		float time = Time.time - startTime;
        Debug.Log(time +","+ 0 +","+ 0+","+ position +","+ position);
		//叩く時刻, チャンネル, ノーツの種類, 叩く位置, 出現位置
        csvEditor.AppendLine(time +","+ 0 +","+ 0+","+ position +","+ position);
    }
}
