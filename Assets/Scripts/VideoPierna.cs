using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPierna : MonoBehaviour {

	VideoPlayer video;
	public int timeToComplete = 3;

	// Use this for initialization
	void Start () {
		video = this.GetComponent<VideoPlayer> ();
		video.Pause ();
		StartCoroutine(RadialProgress(timeToComplete));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator RadialProgress(float time)
	{
		float rate = 1 / time;
		float i = 0;
		while (i < 1)
		{
			i += Time.deltaTime * rate;
			yield return 0;
		}

		video.Play ();
	}
}
