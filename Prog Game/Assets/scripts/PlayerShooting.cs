using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] private Vector2 bulletForce = new Vector2(25, 0);
    [SerializeField] private float shootingDelay = 0.5f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletParent;

    private Controller player;
    private float timeSinceLastShot;
    private Animator animator;

    private void Start()
    {
        player = FindObjectOfType<Controller>().GetComponent<Controller>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            animator.SetBool("isShooting", true);
            if (timeSinceLastShot > shootingDelay) Shoot();
        }
        else
        {
            animator.SetBool("isShooting", false);
        }

        timeSinceLastShot += Time.deltaTime;
    }

    private void Shoot()
    {
        var bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.transform.parent = bulletParent;

        var forceOnBullet = bulletForce * player.ReturnPlayerDirection();
        bullet.GetComponent<Rigidbody2D>().AddForce(forceOnBullet, ForceMode2D.Impulse);

        timeSinceLastShot = 0f;
    }
}
