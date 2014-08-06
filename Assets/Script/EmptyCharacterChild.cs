using UnityEngine;
using System.Collections;

public class EmptyCharacterChild : MonoBehaviour {

	public delegate void OnTouchedDelegate( GameObject touchedObject, string colorTag );
	public event OnTouchedDelegate touchDelegate;

	public delegate void OnClickedDelegate(GameObject clickedObject);
	public event OnClickedDelegate clickDelegate;

	GameObject colorClone;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}

	public OnTouchedDelegate TouchDelegate{
	    set { touchDelegate = value; }
	}

	public OnClickedDelegate ClickDelegate{
		set { clickDelegate = value; }
	}
	 
	void OnTriggerEnter2D(Collider2D coll){
	   	touchDelegate( gameObject, coll.gameObject.tag );
	}

	void OnMouseDown(){
		clickDelegate(gameObject);
	}
}
