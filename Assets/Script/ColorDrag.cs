using UnityEngine;
using System.Collections;

public class ColorDrag : MonoBehaviour {
    private Vector3 screenPoint;
    private Vector3 offset;

    private static Vector3 startingPoints;

	void OnMouseDown() {
		startingPoints = gameObject.transform.position;
	    offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
	}

	void OnMouseDrag(){
	    Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
	    Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
	    gameObject.transform.position = curPosition;
	}

	void OnMouseUp(){
		gameObject.transform.position = startingPoints;
	}

	public static Vector3 GetStartingPoints(){
		return startingPoints;
	}

	public void ResetObject(){
		gameObject.transform.position = startingPoints;
	}
}