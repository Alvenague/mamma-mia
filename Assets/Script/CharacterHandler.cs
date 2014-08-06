using UnityEngine;
using System.Collections;

public class CharacterHandler : MonoBehaviour {

	bool isMe;

	public GameObject emptyCharacter;
	public GameObject dropsHolder;

	GameObject cloneDropsHolder;
	GameObject cloneEmptyCharacter;

	void Awake (){
	    PlayerChoiceController.Instance.onPlayerChoice += onPlayerChoice;
	    PlayerChoiceController.Instance.onPlayerCharacterChoice += onPlayerCharacterChoice;
	    isMe = false;
 	}
  
  // The event that gets called
	void onPlayerChoice(GameObject g){
	    // If g is THIS gameObject
	    if (g == gameObject){
	      isMe = true;
	    }else{
	    	isMe = false;
	    	gameObject.SetActive(false);
	    }
	}

  	void onPlayerCharacterChoice(PlayerChoiceController.playerCharacterChoice characterChoice){

	  	if(isMe){
	  		switch(characterChoice){
		  		case PlayerChoiceController.playerCharacterChoice.nino:
			  		GetComponent<Animator>().SetBool("isSelected", true);
			  		break;
		  		case PlayerChoiceController.playerCharacterChoice.mark:
			  		GetComponent<Animator>().SetBool("isSelected", true);
			  		break;
		  		case PlayerChoiceController.playerCharacterChoice.luna:
			  		GetComponent<Animator>().SetBool("isSelected", true);
			  		break;
	  		}
	  	}
  	}

  	public void loadObjectToFill(){
  		gameObject.SetActive(false);
  		//emptyCharater.renderer.enabled = true;
  		//emptyCharater.transform.position = new Vector3(emptyCharater.transform.position.x, emptyCharater.transform.position.y, 0);
  		//emptyCharater.transform.localScale = new Vector3(2.449069f,2.449069f,0);
  		//dropsHolder.transform.localScale = new Vector3(1.5f,1.5f,1);

  		cloneEmptyCharacter = Instantiate(emptyCharacter.transform,
  							transform.position,
  							transform.rotation) as GameObject;

  		cloneDropsHolder = Instantiate(dropsHolder.transform,
  							dropsHolder.transform.position,
  							dropsHolder.transform.rotation) as GameObject;
  	}

}