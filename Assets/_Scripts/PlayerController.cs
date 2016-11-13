using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    //PUBLIC VARIABLES

    //PRIVATE VARIABLES
    private Transform _transform;
	// Use this for initialization
	void Start () {
        this._transform = this.GetComponent<Transform>();
	}
	
	// FixedUpdate is called once per frame
	void FixedUpdate () {

	}
}
