using UnityEngine;
using System.Collections;

public class CardsHolder : MonoBehaviour {

	public GameObject[] cards;
	int cardsClicked, numberOfCorrectedAnswers;
	int cardNumber1, cardNumber2;

	GameObject card1, card2;

	public delegate void  OnCardsSelection(GameObject g);
	public static event OnCardsSelection CardsSelected;

	void Awake(){
		Card.OnClick+=OnClick;
		cardNumber1=-1;
		cardNumber2=-1;
		numberOfCorrectedAnswers=0;
	}

	// Use this for initialization
	void Start () {
		cardsClicked=0;
		//Shuffle(cards);
	}
	
	// Update is called once per frame
	void Update () {
		if(numberOfCorrectedAnswers==3){
			Application.LoadLevel("Scene0");
		}
	}

	void OnClick(GameObject g){
		if(cardsClicked<=2){
			cardsClicked++;
			if(cardsClicked==1){
				cardNumber1=g.GetComponent<Card>().cardnum;
				card1=g;
			} 
			if(cardsClicked==2){
				cardNumber2=g.GetComponent<Card>().cardnum;
				card2=g;
			} 
			Debug.Log(cardNumber1);
			Debug.Log(cardNumber2);
			if(cardsClicked>=2){
				if(cardNumber1==cardNumber2){
					Debug.Log("carte uguali");
					card1.renderer.enabled=false;
					card2.renderer.enabled=false;
					numberOfCorrectedAnswers++;
				}else{
					Debug.Log("carte diverse");
					CardsSelected(card1);
					CardsSelected(card2);
				}
				cardsClicked=0;
			}
		}
	}

	private void Shuffle(GameObject[] cards){
		for(int i=0; i<cards.Length; i++){
			int rng = Random.Range(i, cards.Length);
			GameObject tempCard = cards[i];
			cards[i]=cards[rng];
			cards[i].transform.localPosition = cards[rng].transform.localPosition;
			cards[rng]=tempCard;
			cards[rng].transform.localPosition=tempCard.transform.localPosition;	
		}
		
	}
}