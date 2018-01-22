using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LineaVolver : MonoBehaviour {

	public Transform target;
	public GameObject progressBarVolver;
	public int timeToComplete = 3;

	bool chocando;

	void Start()
	{
		chocando = false;
	}

	void FixedUpdate()
	{
		Quaternion targetCamPos = target.rotation;
		transform.rotation = targetCamPos;

		if (progressBarVolver.GetComponent<Renderer> ().material.GetFloat ("_Progress") >= 1)
			SceneManager.LoadScene (0);
	}

	void OnTriggerEnter(Collider obj)
	{
		chocando = true;
		if (obj.gameObject.tag == "Volver") {
			StartCoroutine(RadialProgress(timeToComplete));
		}
	}

	void OnTriggerExit(Collider obj)
	{
		chocando = false;
		progressBarVolver.GetComponent<Renderer>().material.SetFloat("_Progress", 0);
	}

	IEnumerator RadialProgress(float time)
	{
		float rate = 1 / time;
		float i = 0;
		while (i < 1 && chocando)
		{
			i += Time.deltaTime * rate;
			progressBarVolver.GetComponent<Renderer>().material.SetFloat("_Progress", i);
			yield return 0;
		}
	}
}

