using UnityEngine;
using System.Collections;

public class StartMenuGUI : MonoBehaviour {

	
	void Update () {

	}


	void OnGUI(){

		if(GUI.Button(new Rect(Screen.width/2 - 50,150,100,20),"Gioco Uno")){
			Application.LoadLevel("Scene1");
		}

		if(GUI.Button(new Rect(Screen.width/2 - 50,190,100,20),"Gioco Due")){

		}
	}
}
