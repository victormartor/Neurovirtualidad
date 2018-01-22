using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class Video : MonoBehaviour {

	VideoPlayer video;

	// Use this for initialization
	void Start () {
		video = this.GetComponent<VideoPlayer> ();
		video.Pause ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
