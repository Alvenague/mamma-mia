using UnityEngine;
using System.Collections;

public class EmptyCharacter : MonoBehaviour {                                                         

	Transform[] allChildren;

	GameObject colorActive;

	// Use this for initialization
	void Start () {
		allChildren = GetComponentsInChildren<Transform>();
		foreach (Transform child in allChildren) {
			//Debug.Log(child.name);
    		EmptyCharacterChild childClass = child.gameObject.AddComponent<EmptyCharacterChild>();
    		childClass.TouchDelegate = OnTouchedChild;
    		childClass.ClickDelegate = OnClickedChild;
		}		
	}
	
	// Update is called once per frame
	void Update () {	

	}

	void OnClickedChild(GameObject childObject){
		if(ColorClick.colorTag!=null){
			ColorChild(childObject, ColorClick.colorTag);
		}
	}

	void OnTouchedChild( GameObject childObject, string colorTag ){
		colorActive = GameObject.FindWithTag(colorTag);
		colorActive.SetActive(false);
		ColorChild(childObject, colorTag);
		StartCoroutine(WaitBeforeResetting(colorTag));
		//ResetColor(colorTag);
	}

	private void ResetColor(string colorTag){
		colorActive.transform.position = ColorDrag.GetStartingPoints();
		colorActive.SetActive(true);
	}

	IEnumerator WaitBeforeResetting(string colorTag) {
		yield return new WaitForSeconds(0.5f);
		ResetColor(colorTag);
	}	

	private void ColorChild(GameObject childObject, string colorTag){
		switch(childObject.tag){
			case "face":
				childObject.renderer.material.color = GetRightColor(colorTag);
				GameObject.FindWithTag("armLeft").renderer.material.color = GetRightColor(colorTag);
				GameObject.FindWithTag("armRight").renderer.material.color = GetRightColor(colorTag);
				break;
			case "armRight":
				childObject.renderer.material.color = GetRightColor(colorTag);
				GameObject.FindWithTag("armLeft").renderer.material.color = GetRightColor(colorTag);
				GameObject.FindWithTag("face").renderer.material.color = GetRightColor(colorTag);
				break;
			case "armLeft":
				childObject.renderer.material.color = GetRightColor(colorTag);
				GameObject.FindWithTag("armRight").renderer.material.color = GetRightColor(colorTag);
				GameObject.FindWithTag("face").renderer.material.color = GetRightColor(colorTag);
				break;
			case "legRight":
				childObject.renderer.material.color = GetRightColor(colorTag);
				GameObject.FindWithTag("legLeft").renderer.material.color = GetRightColor(colorTag);
				break;
			case "legLeft":
				childObject.renderer.material.color = GetRightColor(colorTag);
				GameObject.FindWithTag("legRight").renderer.material.color = GetRightColor(colorTag);
				break;
			case "footRight":
				childObject.renderer.material.color = GetRightColor(colorTag);
				GameObject.FindWithTag("footLeft").renderer.material.color = GetRightColor(colorTag);
				break;
			case "footLeft":
				childObject.renderer.material.color = GetRightColor(colorTag);
				GameObject.FindWithTag("footRight").renderer.material.color = GetRightColor(colorTag);
				break;
			default:
				childObject.renderer.material.color = GetRightColor(colorTag);
				break;
		}
	}

	private Color GetRightColor(string colorTag){
		Color col;
		switch(colorTag){
			case "red":
				col = new Color(0.67F, 0.04F, 0.27F, 1F);
				return col;
			case "pink":
				col = new Color(1F, 0.81F, 0.72F, 1F);
				return col;
			case "blue":
				col = new Color(0F, 0.48F, 0.76F, 1F);
				return col;
			case "orange":
				col = new Color(0.98F, 0.43F, 0.17F, 1F);
				return col;
			case "yellow":
				col = new Color(1F, 0.92F, 0F, 1F);
				return col;
			case "green":
				col = new Color(0.35F, 0.54F, 0.02F, 1F);
				return col;
			default:
				return Color.white;
		}
	}
}