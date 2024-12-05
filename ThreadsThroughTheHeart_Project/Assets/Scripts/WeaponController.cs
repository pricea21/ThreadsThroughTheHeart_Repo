using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject weapon;
    public bool canAttack = true;
    public float attackCooldown = 1.0f;
    public bool isAttacking = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //add controller button inside 
        {
            if (canAttack)
            {
                WeaponAttack();
            }
        }
    }

    public void WeaponAttack()
    {
        isAttacking = true;
        canAttack = false;
        Animator anim = weapon.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        StartCoroutine(ResetattackCooldown());
    }

    IEnumerator ResetattackCooldown()
    {
        StartCoroutine(ResetAttackBool());
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    IEnumerator ResetAttackBool()
    {
        yield return new WaitForSeconds(0.15f);
        isAttacking = false;
    }
}
