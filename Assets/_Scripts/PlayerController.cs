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
    private Transform _transform;
    private Transform _playerSpawnPoint;
	// Use this for initialization
	void Start () {
        this.PlayerCam = this.GetComponent<Transform>();
        this._transform = this.GetComponent<Transform>();
        this._playerSpawnPoint = GameObject.FindGameObjectWithTag("PlayerSpawnPoint").transform;
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
                if (hit.transform.gameObject.CompareTag("Enemy")) {
                    hit.transform.gameObject.SetActive(false);
                    Debug.Log("BULLET HIT");
                    // DO ANYTHING ELSE
                }
                Debug.Log(hit.transform.gameObject.ToString() + " - " + hit.transform.gameObject.tag + " - " + hit.collider.tag);
            }

            //Play rifle sound
            this.MachineGunSound.Play();
        }


        //CHECK IF THEY FELL!
        if (this._transform.position.y <= 21f) {
            this._transform.position = this._playerSpawnPoint.position;
        }
	}

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {   
        if (hit.gameObject.CompareTag("Food"))
        {
            Eating.Play();
            Debug.Log("Food !!");
            Destroy(hit.gameObject);
        } else if(hit.gameObject.CompareTag("Enemy")) {
            Debug.Log("Enemy hit");
            // DO SOMETHING ELSE
        }
    }
}
