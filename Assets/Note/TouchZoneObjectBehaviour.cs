using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TouchZoneObjectBehaviour : MonoBehaviour {
	public NotesData.NotesPosition goal;
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
}
