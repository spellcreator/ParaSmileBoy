using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float speed = 5f;
	public int damage;
	private Rigidbody2D rb;
	public Vector3 shootDir;
	public float timeToDestroy;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	void Update()
	{
		rb.velocity = transform.right * speed;
		Destroy(gameObject, timeToDestroy);
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		EnemyHealth enemy = other.GetComponent<EnemyHealth>();
		if (enemy != null)
		{
			enemy.TakeDamage(damage);
			Destroy(gameObject);
		}
		if(other.gameObject.layer == 9)
		{
			Destroy(gameObject);
		}
	}
}
