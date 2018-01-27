using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class NotesPlayer : MonoBehaviour {
	public GameObject notes;
    public string filePath;
    public const float timeOffsetToCreate = -1;
    public GameObject startButton;
    private List<Queue<NotesData>> channels;
    private AudioSource audioSource;
    private float startTime = 0;
    private bool isPlaying = false;
    void Start(){
        audioSource = GameObject.Find("GameMusic").GetComponent<AudioSource> ();
        channels = LoadChannelsFromCsv(Application.dataPath + "/" + filePath);
    }
    private static List<Queue<NotesData>> LoadChannelsFromCsv(string csvPath){
		StreamReader sr = new FileInfo(csvPath).OpenText();
        List<Queue<NotesData>> channels = new List<Queue<NotesData>>();
        for (int i = 0; i < 5; i++){
            channels.Add(new Queue<NotesData>());
        }
        while (sr.Peek() > -1) {
            string[] values = sr.ReadLine().Split (',');
            //叩く時刻, チャンネル, ノーツの種類, 叩く位置, 出現位置
            int channelId = int.Parse(values[1]);
            channels[channelId].Enqueue(new NotesData(
                time:float.Parse(values[0]),
                type:(NotesData.NotesType)Enum.Parse(typeof(NotesData.NotesType), values[2]),
                start:(NotesData.NotesPosition)Enum.Parse(typeof(NotesData.NotesPosition), values[4]),
                goal:(NotesData.NotesPosition)Enum.Parse(typeof(NotesData.NotesPosition), values[3]),
                channelId:channelId));
        }
        return channels;
    }
   void Update () {
        if (isPlaying) {
            CreateNextNotes();
		}
        
    }
    void CreateNextNotes(){
        float currentTime = Time.time - startTime;
        foreach (var channel in channels){
            while(channel.Count > 0 && channel.Peek().Time + timeOffsetToCreate < currentTime) {
                NotesBehaviour.CreateNotesObject(notes, channel.Dequeue());
            }
        }
    }
    public void StartMusic(){
        startButton.SetActive (false);
        startTime = Time.time;
        audioSource.Play();
        isPlaying = true;
    }
}
