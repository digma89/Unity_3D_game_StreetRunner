using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
    //PUBLIC VARIABLES
    public Transform FlashPoint;
    public GameObject MuzzleFlash;
    public AudioSource MachineGunSound;
    public AudioSource Eating;
    public Transform PlayerCam;

    //PRIVATE VARIABLES
    
    //private Transform _transform;
	// Use this for initialization
	void Start () {
        this.PlayerCam = this.GetComponent<Transform>();
	}
	
	// FixedUpdate is called once per frame
	void FixedUpdate () {
        if (Input.GetButtonDown("Fire1"))
        {
            //Show MuzzleFlash at the flash point            
            GameObject childObject = Instantiate(this.MuzzleFlash, this.FlashPoint.position,Quaternion.identity) as GameObject;
            childObject.transform.parent = FlashPoint.transform; //put the MuzzleFlash inside Flashpoint
            Destroy(childObject, 1);

            RaycastHit hit;

            if(Physics.Raycast (this.PlayerCam.position,this.PlayerCam.forward,out hit))
            {
                Debug.Log(hit.transform.gameObject);
            }


            //Play rifle sound
            this.MachineGunSound.Play();
        }

	}

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
   
        if (hit.gameObject.CompareTag("Food"))
        {
            Eating.Play();
            Debug.Log("Food !!");
            Destroy(hit.gameObject);
        }
    }
}
