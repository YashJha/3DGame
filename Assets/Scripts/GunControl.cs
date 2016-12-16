using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;

public class GunControl : MonoBehaviour {

	[SerializeField]
	Animator myAnimator;

	[SerializeField]
	AudioSource myAudiosource;

	[SerializeField]
	GameObject PlayerFPCamera;

    public float ammo = 30;

    void Update () {
		if (CrossPlatformInputManager.GetButtonDown("Fire1"))
		{
			myAnimator.SetTrigger("Shoot");
			myAudiosource.Play();

			RaycastHit hit;
			if (Physics.Raycast(PlayerFPCamera.transform.position, 
				PlayerFPCamera.transform.forward, out hit))
			{
				GameObject target = hit.collider.transform.gameObject;
				Enemy enemy = target.GetComponent<Enemy>();
                if (ammo > 0)
                {
                    if (enemy)
                    {
                        ammo -= 1;
                        Debug.Log(ammo);
                        enemy.Damage(25, PlayerFPCamera.transform.parent);
                    }
                }
			}
		}
	}
}
