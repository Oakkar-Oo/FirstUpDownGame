using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class playerController : MonoBehaviour
{
    public bool isMoving;

    private Vector2 input;

    public float moveSpeed;
    Animator animator;

    
    public void Awake()
    {

        animator = GetComponent<Animator>();
    }

    void Start()
    {
        
        
    }

    
    void Update()
    {
        if(!isMoving)
        {
            
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            

            if(input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);
                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

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
