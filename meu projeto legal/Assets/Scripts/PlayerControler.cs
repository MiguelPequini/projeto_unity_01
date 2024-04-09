using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float moveSpeed;

    private bool isMoving;

    public Vector2 input;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

        if (!isMoving) 
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

           


            
            if ( input != Vector2.zero)
            {
            
                var targetPos = transform.position;
                targetPos.x += input.x; 
                targetPos.y += input.y;
                animator.SetFloat("Movex", input.x);
                animator.SetFloat("Movey", input.y);
                StartCoroutine(Move(targetPos));
            }
        }
        animator.SetBool("isMoving", isMoving);

    }
    
    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon) 
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false; 
    }




}
