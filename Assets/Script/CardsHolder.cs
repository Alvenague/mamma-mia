using UnityEngine;
using System.Collections;

public class CardsHolder : MonoBehaviour {

	public GameObject[] cards;

	// Use this for initialization
	void Start () {
		//Shuffle(cards);
	}
	
	// Update is called once per frame
	void Update () {
	
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
