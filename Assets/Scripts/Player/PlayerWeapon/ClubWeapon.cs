using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClubWeapon : MonoBehaviour
{
    [SerializeField]private Item club;
	private GameObject hit;

	public Vector3 attackOffset;
    public float attackRange = 1f;
    public LayerMask attackMask;
	public int damage;
	private SpriteRenderer itemSprite;

    private void Awake()
    {
		damage = club.damage;
		itemSprite = GetComponent<SpriteRenderer>();
		itemSprite.sprite = club.image;
    }

	private void Start()
	{
		hit = GameObject.Find("Fire");
		hit.GetComponent<Button>().onClick.AddListener(Attack);
	}
	public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackMask);
		if (colInfo != null)
		{
			colInfo.GetComponent<EnemyHealth>().TakeDamage(damage);
			Destroy(gameObject);
		}
		else
		{
			Debug.Log("Do nothing");
		}
	}
# if UNITY_EDITOR
	void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}
#endif 
}
