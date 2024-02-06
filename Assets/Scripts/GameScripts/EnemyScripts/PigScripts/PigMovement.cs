using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigMovement : MonoBehaviour
{
    
    private Vector3 startPosition;
    private Vector3 targetPosition;
    
    private float speed = 1f;
    private float waitTime = 1f;

    private Animator animator;

    public void Initialize(Vector3 startPosition, Vector3 targetPosition, float speed, float waitTime)
    {
        this.startPosition = startPosition;
        this.targetPosition = targetPosition;
        this.speed = speed;
        this.waitTime = waitTime;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        StartCoroutine(nameof(Oscillate));
    }

    private IEnumerator Oscillate()
    {
        bool toTarget = true;
        while (true)
        {
            if (toTarget)
            {
                bool doubleSpeed = IsFacingPlayer();
                float currentSpeed = doubleSpeed ? speed * 2 : speed;
            
                if (doubleSpeed) animator.SetFloat("speed", 1f);
                else animator.SetFloat("speed", 0.5f);

                // go towards target with speed
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, currentSpeed * Time.deltaTime);
                yield return null;
                if(transform.position == targetPosition)
                {
                    toTarget = false;
                    
                    // face the other direciton
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                    yield return new WaitForSeconds(waitTime);
                }
            }
            else
            {
                bool doubleSpeed = IsFacingPlayer();
                float currentSpeed = doubleSpeed ? speed * 2 : speed;
            
                if (doubleSpeed) animator.SetFloat("speed", 1f);
                else animator.SetFloat("speed", 0.5f);

                // go towards start with speed
                transform.position = Vector3.MoveTowards(transform.position, startPosition, currentSpeed * Time.deltaTime);
                yield return null;
                if(transform.position == startPosition)
                {
                    toTarget = true;
                    // face the other direciton
                    transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                    yield return new WaitForSeconds(waitTime);
                }
            }
        }
    }

    private bool IsFacingPlayer()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null) return false;

        float distance;
        // if player is on the side enemy looking at
        if (transform.localScale.x < 0)
        {
            distance = player.transform.position.x - transform.position.x;
            return distance is > 0 and < 5;
        }

        distance = transform.position.x - player.transform.position.x;
        return distance is > 0 and < 5;
    }
    
}
