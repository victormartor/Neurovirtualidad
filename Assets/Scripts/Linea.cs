using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Linea : MonoBehaviour {

	public Transform target;
	public GameObject progressBarDerecha;
	public GameObject progressBarIzquierda;
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

		if (progressBarDerecha.GetComponent<Renderer> ().material.GetFloat ("_Progress") >= 1)
			SceneManager.LoadScene (1);

		if (progressBarIzquierda.GetComponent<Renderer> ().material.GetFloat ("_Progress") >= 1)
			SceneManager.LoadScene (2);
	}

	void OnTriggerEnter(Collider obj)
	{
		chocando = true;
		if (obj.gameObject.tag == "Derecha") {
			StartCoroutine(RadialProgressDerecha(timeToComplete));
		}

		if (obj.gameObject.tag == "Izquierda") {
			StartCoroutine(RadialProgressIzquierda(timeToComplete));
		}
	}

	void OnTriggerExit(Collider obj)
	{
		chocando = false;
		progressBarDerecha.GetComponent<Renderer>().material.SetFloat("_Progress", 0);
		progressBarIzquierda.GetComponent<Renderer>().material.SetFloat("_Progress", 0);
	}

	IEnumerator RadialProgressDerecha(float time)
	{
		float rate = 1 / time;
		float i = 0;
		while (i < 1 && chocando)
		{
			i += Time.deltaTime * rate;
			progressBarDerecha.GetComponent<Renderer>().material.SetFloat("_Progress", i);
			yield return 0;
		}
	}

	IEnumerator RadialProgressIzquierda(float time)
	{
		float rate = 1 / time;
		float i = 0;
		while (i < 1 && chocando)
		{
			i += Time.deltaTime * rate;
			progressBarIzquierda.GetComponent<Renderer>().material.SetFloat("_Progress", i);
			yield return 0;
		}
	}
}

