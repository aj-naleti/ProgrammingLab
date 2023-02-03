using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] private float bulletSpeed = 10f;
    [SerializeField] private float hitDistance = 5f;      
    [SerializeField] private float shootingDelay = 0.5f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletParent;

    private Transform player;
    private float timeSinceLastShot;

    private void Start()
    {
        player = FindObjectOfType<Controller>().GetComponent<Transform>();
    }

    private void Update()
    {
        timeSinceLastShot += Time.deltaTime;

        var distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer < hitDistance)
        {
            ShootPlayer();
        }
    }

    private void ShootPlayer()
    {
        if (timeSinceLastShot > shootingDelay)
        {
            var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            bullet.transform.parent = bulletParent;

            bullet.GetComponent<Rigidbody2D>().velocity = (player.position - transform.position).normalized * bulletSpeed;
            timeSinceLastShot = 0;
        }
    }
}
