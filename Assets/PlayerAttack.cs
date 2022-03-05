using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform projectileStartingPoint;
    [SerializeField] private GameObject[] projectiles;
    private Animator animator;
    private PlayerMovement playerMovement;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerMovement = GetComponent<PlayerMovement>();

    }
    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer>attackCooldown &&playerMovement.CanAttack()) Attack();

        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        cooldownTimer = 0;
        projectiles[FindFireball()].transform.position = projectileStartingPoint.position;
        projectiles[FindFireball()].GetComponent<Projectile>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int FindFireball()
    {
        for(int i =0; i < projectiles.Length; i++)
        {
            if (!projectiles[i].activeInHierarchy) return i;
        }
            return 0;
    }
}
