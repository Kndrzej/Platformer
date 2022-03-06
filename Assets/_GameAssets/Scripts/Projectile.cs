using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float projectileSpeed;
    private bool hit;
    private float projectileDirection;
    private BoxCollider2D boxCollider;
    private float projectileLifetime;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (hit) return;
        float movementSpeed = projectileSpeed * Time.deltaTime * projectileDirection;
        transform.Translate(movementSpeed, 0, 0);
        projectileLifetime += Time.deltaTime;
        if (projectileLifetime > 2) gameObject.SetActive(false);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        //Deactivate();
    }
    public void SetDirection(float direction)
    {
        projectileLifetime = 0;
        projectileDirection = direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != projectileDirection) localScaleX = -localScaleX;
        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }

}
