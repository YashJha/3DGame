using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpiderEnemy : MonoBehaviour {
	private const int MAX_HEALTH = 100;
	[SerializeField]
	int Health = MAX_HEALTH;
	[SerializeField]
	Image ImgHealth;
	private Transform target;

	[SerializeField]
	Animator myAnimator;
	[SerializeField]
	AudioSource myAudioSource;
	private float timeToAttack;

	public void Damage(int points, Transform newTarget)
	{
		Health -= points;
		ImgHealth.fillAmount = (float)Health / (float)MAX_HEALTH;
		if (Health <= 0)
			Destroy(gameObject);
		else{
			target = newTarget;
			myAudioSource.Play();
		}
	}
	void Update()
	{
		if (target)
		{
			GetComponent<NavMeshAgent>().SetDestination(target.position);
			float distance = Vector3.Distance(target.position, transform.position);
			if (distance > 1.0f)
			{
				myAnimator.SetBool("IsCrawling", true);
				timeToAttack = 1.5f;
			}else{
				myAnimator.SetBool("IsCrawling", false);
				Attack();
			}
		}
	}
	void Attack()
	{
		timeToAttack -= Time.deltaTime;
		if (timeToAttack > 0)
			return;
		timeToAttack = 1.5f;
		Player player = target.GetComponent<Player>();
		if (player)
		{
			myAnimator.SetTrigger("IsAttack");
			player.Damage(50);
		}
	}
}
