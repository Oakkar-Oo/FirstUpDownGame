using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool isAttacking = false;
    private GameObject AttackArea = default;

    private float timeToAttack = 0.25f;
    private float timer = 0f;

    void Start()
    {
        AttackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }

        if (isAttacking)
        {
            timer += Time.deltaTime;

            if (timer >= timeToAttack) 
            {
                timer = 0;
                isAttacking = false;
                AttackArea.SetActive(isAttacking);
            }
        }
    }

    private void Attack()
    {
        isAttacking = true;
        AttackArea.SetActive(isAttacking);
    }


}


        

