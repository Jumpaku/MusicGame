using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using TouchScript.Gestures;

public class TouchZoneObjectBehaviour : MonoBehaviour
{
    public List<GameObject> touchTargets;
    void Start()
    {
    }
    void Update()
    {
    }
    private void OnEnable()
    {
        GetComponent<TapGesture>().Tapped += OnTapped;
        GetComponent<FlickGesture>().Flicked += OnFlicked;
        GetComponent<PressGesture>().Pressed += OnPressed;
        GetComponent<ReleaseGesture>().Released += OnReleased;
    }
    private void OnDisable()
    {
        GetComponent<TapGesture>().Tapped -= OnTapped;
        GetComponent<FlickGesture>().Flicked -= OnFlicked;
        GetComponent<PressGesture>().Pressed -= OnPressed;
        GetComponent<ReleaseGesture>().Released -= OnReleased;
    }
    private void OnTapped(object sender, EventArgs e)
    {
        DetectObject(sender as Gesture);
    }
    private void OnFlicked(object sender, EventArgs e)
    {
    }
    private void OnPressed(object sender, EventArgs e)
    {
    }
    private void OnReleased(object sender, EventArgs e)
    {
    }
    private void DetectObject(Gesture gesture)
    {
        var camera = Camera.main;
        var screenPosition = new Vector3(gesture.ScreenPosition.x, gesture.ScreenPosition.y, camera.nearClipPlane);
        var ray = camera.ScreenPointToRay(screenPosition);
        var hit = new RaycastHit();
        if (Physics.Raycast(ray, out hit))
        {
            foreach (var t in touchTargets.Where(o => o == hit.collider.gameObject))
            {
                Debug.Log(t.name);
            }
        }
    }
}
