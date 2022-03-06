using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public delegate void DeathAction();
    public static event DeathAction OnDeath;

    public delegate void HitEnemy();
    public static event HitEnemy OnHit;

    [SerializeField] private GameObject startPosition, endPosition;
    [SerializeField] private float platformMovementSpeed;
    [SerializeField] private float waitInPlaceTime;
    public Vector3 nextPosition;
    private bool leftOrRight;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) OnDeath();
        if (collision.CompareTag("Projectile"))
        {
            gameObject.SetActive(false);
            collision.gameObject.SetActive(false);
            OnHit();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        nextPosition = endPosition.transform.position;
        StartCoroutine(MoveEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, platformMovementSpeed * Time.deltaTime);
        if (!leftOrRight) transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
        else if (leftOrRight) transform.localScale = new Vector3(-0.1f, 0.1f, 0.1f);
    }
    private IEnumerator MoveEnemy()
    {
        while (true)
        {
            if (transform.position == endPosition.transform.position)
            {
                leftOrRight = true;
                nextPosition = startPosition.transform.position;
            }
            yield return new WaitForSeconds(waitInPlaceTime);
            if (transform.position == startPosition.transform.position)
            {
                leftOrRight = false;
                nextPosition = endPosition.transform.position;
            }
            yield return new WaitForSeconds(waitInPlaceTime);
        }
    }
}
