using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {


	public Sprite frontCard;
	public int cardnum;
	Sprite backCard;

	Vector3 backCardScale;

	bool flipped;

	SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		flipped = false;
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		backCard=spriteRenderer.sprite;
		backCardScale = gameObject.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown(){
		Debug.Log(gameObject.tag);
		if(flipped){
			gameObject.transform.localScale = backCardScale;
			spriteRenderer.sprite=backCard;
			flipped=false;
		}else{
			gameObject.transform.localScale = new Vector3(1.3f, 1.3f, 0);
			spriteRenderer.sprite=frontCard;
			flipped=true;
		}
	}

}
