using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeWeaponEnemy : MonoBehaviour
{
    [SerializeField] private Item ak;

    public int damage;
    private SpriteRenderer itemSprite;
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float attackRate = 1f;
    private float nexAttackTime = 0f;

    private void Awake()
    {
        itemSprite = GetComponent<SpriteRenderer>();
        itemSprite.sprite = ak.image;
        damage = ak.damage;
    }

    private void Update()
    {
        if (nexAttackTime <= 0)
        {
            Shoot();
            nexAttackTime = attackRate;

        }
        else
        {
            nexAttackTime -= Time.deltaTime;
        }
    }

    public void Shoot()
    {
        var shootDir = new Vector3(firePoint.localRotation.x, 0f, firePoint.position.z);

        var bullets = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        bullets.GetComponent<EnemyBullet>().damage = damage;
        bullets.GetComponent<EnemyBullet>().shootDir = shootDir;
    }
}
