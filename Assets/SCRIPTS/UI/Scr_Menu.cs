using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scr_Menu : MonoBehaviour {


    CanvasGroup fadeGroup;
    float fadeSpeed = 0.5f;
    
    
    
    // Use this for initialization
	void Start () {

        fadeGroup = FindObjectOfType<CanvasGroup>();

        fadeGroup.alpha = 1;

	}
	
	// Update is called once per frame
	void Update () {

        fadeGroup.alpha = 1 - Time.timeSinceLevelLoad * fadeSpeed;

	}
}
