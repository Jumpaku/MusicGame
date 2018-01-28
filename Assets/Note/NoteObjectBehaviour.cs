﻿using UnityEngine;
using System.Collections;

public class NoteObjectBehaviour : MonoBehaviour {
    public static GameObject CreateNotesObject(GameObject notesPrefab, NoteData notesData) {
        GameObject obj = Instantiate<GameObject>(notesPrefab);
        NoteObjectBehaviour notes = obj.GetComponent<NoteObjectBehaviour>();
        notes.NotesData = notesData;
        return obj;
    }
    private static Vector3 computeStartPosition(NoteData.NotePosition notesPosition) {
        float notesY = 10f;
        float notesX = 0f;
        switch (notesPosition) {
        case NoteData.NotePosition.L:
            notesX = -4.0f + (2.0f * 0);break;
        case NoteData.NotePosition.LC:
            notesX = -4.0f + (2.0f * 1);break;
        case NoteData.NotePosition.C: 
            notesX = -4.0f + (2.0f * 2);break;
        case NoteData.NotePosition.RC: 
            notesX = -4.0f + (2.0f * 3);break;
        case NoteData.NotePosition.R: 
            notesX = -4.0f + (2.0f * 4);break;
        }
        return new Vector3(notesX, notesY, 0f);
    }
    private static Vector3 computeGoalPosition(NoteData.NotePosition notesPosition) {
        float notesY = 0f;
        float notesX = 0f;
        switch (notesPosition) {
        case NoteData.NotePosition.L:
            notesX = -4.0f + (2.0f * 0);break;
        case NoteData.NotePosition.LC:
            notesX = -4.0f + (2.0f * 1);break;
        case NoteData.NotePosition.C: 
            notesX = -4.0f + (2.0f * 2);break;
        case NoteData.NotePosition.RC: 
            notesX = -4.0f + (2.0f * 3);break;
        case NoteData.NotePosition.R: 
            notesX = -4.0f + (2.0f * 4);break;
        }
        return new Vector3(notesX, notesY, 0f);
    }
    public Vector3　GetStartPosition() { return computeStartPosition(NotesData.Start); }
    public Vector3 GetGoalPosition() { return computeGoalPosition(NotesData.Goal); }

    public NoteData NotesData { get; private set; }
    private float parameterSpeed = 1f;//[1/s]
    private float parameter = 0f;
    private bool isAlive = true;
    void Start(){}
    void Update () {
        parameter += parameterSpeed * Time.deltaTime;
        transform.position = (1 - parameter) * GetStartPosition() + parameter * GetGoalPosition();
        isAlive = transform.position.y > -5.0f;
        if (!isAlive) {
            Destroy(gameObject);
        }
    }
    private void DetectTap(){}

    void OnTriggerEnter(Collider t) {
        bool isGoal = t.gameObject.name.Contains("NotesTargetObject")
            && t.GetComponent<NoteTargetObjectBehaviour>().goal == NotesData.Goal;
        if (isGoal){   
            Debug.Log(NotesData.Goal.ToString());
        }
    }
}