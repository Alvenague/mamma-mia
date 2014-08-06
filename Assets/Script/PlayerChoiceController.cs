using UnityEngine;
using System.Collections;

public class PlayerChoiceController : MonoBehaviour {

	public enum playerCharacterChoice {
		none=0,
		mark,
		nino,
		luna
	}

    private  static PlayerChoiceController instance;   

    private PlayerChoiceController() {} 

    public static PlayerChoiceController Instance{     
        get{       
            if (instance ==  null)
             	instance = GameObject.FindObjectOfType(typeof(PlayerChoiceController)) as  PlayerChoiceController;      
            return instance;    
        }
    }

	public delegate void playerChoiceHandler(GameObject g);

	public event playerChoiceHandler onPlayerChoice;

	public delegate void playerCharacterChoiceHandler(playerCharacterChoice characterChoice);

	public event playerCharacterChoiceHandler onPlayerCharacterChoice;
	
	void LateUpdate (){

    Vector2 worldPoint = Camera.main.ScreenToWorldPoint( Input.mousePosition );
    
    RaycastHit2D hit = Physics2D.Raycast( worldPoint, Vector2.zero );
      
    if ( hit.collider!=null ){

      if (Input.GetMouseButtonUp(0)){

            onPlayerChoice(hit.transform.gameObject);
            switch(hit.transform.gameObject.name){
            	case "LUNA":
                	onPlayerCharacterChoice(PlayerChoiceController.playerCharacterChoice.luna);
                	break;
            	case "MARK":
                	onPlayerCharacterChoice(PlayerChoiceController.playerCharacterChoice.mark);
                	break;
            	case "NINO":
                	onPlayerCharacterChoice(PlayerChoiceController.playerCharacterChoice.nino);
                	break;
            }
      }
    }

  }
}