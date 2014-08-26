using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {


	public Sprite frontCard;
	public int cardnum;
	Sprite backCard;

	Vector3 backCardScale;

	bool flipped, clickActive;

	SpriteRenderer spriteRenderer;

	public delegate void OnClickEvent(GameObject g);
	public static event OnClickEvent OnClick;  

	void Awake(){
		CardsHolder.CardsSelected += CardSelected;
	}

	// Use this for initialization
	void Start () {
		flipped = false;
		clickActive = true;
		spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
		backCard=spriteRenderer.sprite;
		backCardScale = gameObject.transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnMouseDown(){
		if(clickActive){
			Debug.Log(gameObject.tag);
			if(flipped){
				gameObject.transform.localScale = backCardScale;
				spriteRenderer.sprite=backCard;
				flipped=false;
			}else{
				gameObject.transform.localScale = new Vector3(1.3f, 1.3f, 0);
				spriteRenderer.sprite=frontCard;
				flipped=true;
				gameObject.collider2D.enabled=false;
				StartCoroutine(Wait());  
			}
		}
	}

	IEnumerator Wait(){
		clickActive=false;
	    yield return new WaitForSeconds (1.0f);
	    OnClick(gameObject);
	}

	void CardSelected(GameObject g){
		if(g.tag==gameObject.tag){
			Debug.Log(gameObject.tag + " riattivato il collider");
			gameObject.collider2D.enabled=true;
			gameObject.transform.localScale = backCardScale;
			spriteRenderer.sprite=backCard;
			flipped=false;
		}else{
			Debug.Log("Questa carta è:" + gameObject.tag + "mentre la carta passata è: " + g.tag);
		}
		clickActive=true;
	}

}