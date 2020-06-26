using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
	public float speed = 5f;
	public int damage;
	private Rigidbody2D rb;
	public Vector3 shootDir;
	[SerializeField] private float timeToDestroy;

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
		PlayerHealth player = other.GetComponent<PlayerHealth>();
		if (player != null)
		{
			player.TakeDamage(damage);
			Destroy(gameObject);
		}
	}
}