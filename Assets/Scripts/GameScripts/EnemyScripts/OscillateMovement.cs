using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillateMovement : MonoBehaviour
{
    private Vector3 startPosition;
    private Vector3 targetPosition;
    
    private float speed = 1f;
    private float waitTime = 1f;

    public void SetOscillation(Vector3 startPosition, Vector3 targetPosition, float speed, float waitTime)
    {
        this.startPosition = startPosition;
        this.targetPosition = targetPosition;
        this.speed = speed;
        this.waitTime = waitTime;
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nameof(Oscillate));
    }

    private IEnumerator Oscillate()
    {
        bool toTarget = true;
        while (true)
        {
            
            if (toTarget)
            {
                // go towards target with speed
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
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
                // go towards start with speed
                transform.position = Vector3.MoveTowards(transform.position, startPosition, speed * Time.deltaTime);
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


}
