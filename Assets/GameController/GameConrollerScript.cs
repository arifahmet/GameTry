using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameConrollerScript : MonoBehaviour {

    public GameObject tree;
    Text scroe;
    private int count;
	// Use this for initialization
	void Start () {
        InvokeRepeating("CreateTree", 2.0f, 3.0f);
	}
	
	// Update is called once per frame
    void Update() {
        
    
    }

	void CreateTree(){
		Vector3 asteroidPosition = GetCreatePosition();
		Instantiate (tree, asteroidPosition, Quaternion.identity);	
	
	}

    private Vector3 GetCreatePosition(){
        int num = (int) Random.Range(-2.0f,+1.4f);

		Vector3 v = new Vector3	(
								 Camera.main.orthographicSize * Camera.main.aspect + 1.0f,
                                (num*2.0f)+0.33f,
								0.0f
							);

        return v;

	}
}
