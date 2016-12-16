using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowAmmo : MonoBehaviour {

    public Text ammoText;
    public GameObject ammoCounter;

	// Use this for initialization
	void Start () {

        ammoCounter = GameObject.Find("Pistol");
	}
	
	// Update is called once per frame
	void Update () {
        ammoText.text = "Ammo:" + ammoCounter.GetComponent<GunControl>().ammo.ToString();
	
	}
}
