using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IGestureInterface {

	void Update() {
		
	}
	bool FlickedLeft(){ return false; }
	bool FlickedRight(){ return false; }
	bool TapPressed(){ return false; }
	bool TapReleased(){ return false; }
	bool TapContinues(){ return false; }
}
