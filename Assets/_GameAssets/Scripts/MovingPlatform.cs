using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private GameObject startPosition, endPosition;
    [SerializeField] private float platformMovementSpeed;
    [SerializeField] private float waitInPlaceTime;
    public Vector3 nextPosition;
    // Start is called before the first frame update
    void Start()
    {
        nextPosition = endPosition.transform.position;
        StartCoroutine(MovePlatform());
    }

    // Update is called once per frame
    void Update()
    { 
        transform.position = Vector3.MoveTowards(transform.position,nextPosition,platformMovementSpeed*Time.deltaTime);
    }
    private IEnumerator MovePlatform()
    {
        while (true)
        {
            if (transform.position == endPosition.transform.position) nextPosition = startPosition.transform.position;
            yield return new WaitForSeconds(waitInPlaceTime);
            if (transform.position == startPosition.transform.position) nextPosition = endPosition.transform.position;
            yield return new WaitForSeconds(waitInPlaceTime);
        }
    }
}
