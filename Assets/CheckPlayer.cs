using UnityEngine;
using System.Collections;

public class CheckPlayer : MonoBehaviour {

    [SerializeField]
    Collider mygameObj;
    public bool playerHere;
    
	// Use this for initialization
	void Start () {
        
	
	}
	
	// Update is called once per frame
	void Update () {

        OnTriggerStay(mygameObj);
        OnTriggerExit(mygameObj);
        if (playerHere == true)
        {
            Debug.Log("Player here.");
        }
	
	}

    void OnTriggerStay(Collider other)
    {
        
            playerHere = true;
        
    }

    void OnTriggerExit(Collider other)
    {
       
            playerHere = false;
        
    }
}
