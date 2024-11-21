using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public GameObject Weapon;
    public bool CanAttack = true;
    public float AttackCooldown = 1.0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //add controller button inside 
        {
            if (CanAttack)
            {
                WeaponAttack();
            }
        }
    }

    public void WeaponAttack()
    {
        CanAttack = false;
        Animator anim = Weapon.GetComponent<Animator>();
        anim.SetTrigger("Attack");
        StartCoroutine(ResetAttackCooldown());
    }

    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(AttackCooldown);
        CanAttack = true;
    }
}
