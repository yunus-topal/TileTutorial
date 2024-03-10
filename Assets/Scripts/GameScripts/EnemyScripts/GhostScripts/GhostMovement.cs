using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMovement : MonoBehaviour
{
    private enum GhostStatus
    {
        hidden,
        visible
    }
    private GameObject player;
    private float speed = 1f;
    private float disappearDelay = 1f;
    private GhostStatus ghostStatus;
    
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        ghostStatus = GhostStatus.visible;
        animator = GetComponent<Animator>();
        StartCoroutine(FollowPlayer());
    }

    public void Initialize(GameObject player, float speed, float disappearDelay)
    {
        this.player = player;
        this.speed = speed;
        this.disappearDelay = disappearDelay;
    }

    // Update is called once per frame
    void Update()
    {
        if (disappearDelay <= 0 && ghostStatus == GhostStatus.visible)
        {
            animator.SetTrigger("hide_trig");
            ghostStatus = GhostStatus.hidden;
        }
    }

    IEnumerator FollowPlayer()
    {
        while (true)
        {
            if (player != null)
            {
                Vector3 distance = player.transform.position - transform.position;
                if(distance.magnitude is < 10f and > 0.1f)
                {
                    disappearDelay -= Time.deltaTime;
                    // move towards player
                    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                    
                    // flip ghost if needed
                    if (distance.x > 0)
                    {
                        transform.localScale = new Vector3(-2, 2, 2);
                    }
                    else
                    {
                        transform.localScale = new Vector3(2, 2, 2);
                    }
                }
            }

            yield return null;
        }
    }
    
    public void Show()
    {
        disappearDelay = 1f;
        if (ghostStatus == GhostStatus.visible) return;
        ghostStatus = GhostStatus.visible;
        animator.SetTrigger("show_trig");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Show();
        }
    }
}
