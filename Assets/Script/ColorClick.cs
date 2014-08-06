using UnityEngine;
using System.Collections;

public class ColorClick : MonoBehaviour {

	public static string colorTag=null;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseUp(){
		colorTag = gameObject.tag;
		Debug.Log(colorTag);
	}

}
