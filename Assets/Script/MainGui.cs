using UnityEngine;
using System.Collections;

public class MainGui : MonoBehaviour {

	bool characterSelected, menuOpened;

	public AudioSource audioSource;

	void Awake (){
		characterSelected = false;
		menuOpened = false;
	    PlayerChoiceController.Instance.onPlayerCharacterChoice += onPlayerCharacterChoice;
 	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI () {
		if(characterSelected){
			GUILayout.BeginArea (new Rect (20, Screen.height-(Screen.height-20), 100, 80));
			GUILayout.BeginVertical();
			if(!menuOpened){
				if (GUILayout.Button ("Pause")){
	        		menuOpened=true;
	        	}
			}
	        
	        if(menuOpened){
	        	audioSource.mute = true;
		    	if(GUILayout.Button ("Back To Start")){	
		    		Application.LoadLevel(Application.loadedLevelName);
		    	}
		    	if(GUILayout.Button ("Resume")){	
		    		menuOpened = false;
		    		audioSource.mute = false;
		    	}
	        }
	        GUILayout.EndVertical();
	        GUILayout.EndArea ();
		} 
        
        
    }

    void onPlayerCharacterChoice(PlayerChoiceController.playerCharacterChoice characterChoice){

	  	if(characterChoice != PlayerChoiceController.playerCharacterChoice.none){
	  		characterSelected = true;
	  	}
  	}
}
