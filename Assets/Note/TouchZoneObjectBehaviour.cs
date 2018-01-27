using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using TouchScript.Gestures;

public class TouchZoneObjectBehaviour : MonoBehaviour {
    public NotesData.NotePosition goal;
    public bool FlickedLeft { get; private set; } = false;
    public bool FlickedRight { get; private set; } = false;
    public bool TapPressed { get; private set; } = false;
    public bool TapReleased { get; private set; } = false;
    public bool TapContinues { get; private set; } = false;
    void Start () {
        GetComponent<Renderer>().enabled = false;

    }
    void Update () {
    }
       private void OnEnable()
    {
        GetComponent<TapGesture>().Tapped += OnTapped;
        GetComponent<FlickGesture>().Flicked += OnFlicked;
        GetComponent<PressGesture>().Pressed += OnPressed;
        GetComponent<ReleaseGesture>().Released += OnReleased;
        GetComponent<LongPressGesture>().LongPressed += OnLongPressed;
    }
 
    // オブジェクトが無効化されたときにイベントハンドラを削除する
    private void OnDisable()
    {
        GetComponent<FlickGesture>().Flicked -= OnFlicked;
        GetComponent<PressGesture>().Pressed -= OnPressed;
        GetComponent<ReleaseGesture>().Released -= OnReleased;
        GetComponent<LongPressGesture>().LongPressed -= OnLongPressed;
    }
 
    // タップイベントのイベントハンドラ
    private void OnTapped(object sender, EventArgs e)
    {
        Debug.Log("OnTapped : " + goal);
    }
    private void OnFlicked(object sender, EventArgs e)
    {
        Debug.Log("OnFlicked : " + goal + ", Direction" + (sender as FlickGesture).ScreenFlickVector);
    }
    private void OnLongPressed(object sender, EventArgs e)
    {
        Debug.Log("OnLongPressed : " + goal);
    }
    private void OnPressed(object sender, EventArgs e)
    {
        Debug.Log("OnPressed : " + goal);
    }
    private void OnReleased(object sender, EventArgs e)
    {
        Debug.Log("OnReleased : " + goal);
    }
}
