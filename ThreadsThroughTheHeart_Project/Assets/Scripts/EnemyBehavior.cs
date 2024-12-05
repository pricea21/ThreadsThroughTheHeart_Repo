using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;
    private int currentHealth;
    private bool isShouting = false;
    private bool isAttacking = false;

    public WeaponController wc;


    // Set the initial health
    private void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        // Start in idle state
        animator.SetTrigger("Idle");
    }

    // When the player hits the enemy
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Weapon" && wc.isAttacking)
        {
            // If the enemy is in the shout animation and the player hits it
            if (isShouting)
            {
                StopShoutingAndAttack();
            }
            else if (!isAttacking)
            {
                // If the enemy is not attacking, start the attack animation
                StartAttack();
                StartShout();
            }
        }
    }

    // Handle the enemy being hit during a shout animation
    private void StopShoutingAndAttack()
    {
        isShouting = false;
        animator.SetTrigger("Hit"); // Trigger hit animation
        animator.SetTrigger("Attack"); // Switch to attack animation after being hit
    }

    // Start the attack animation
    private void StartAttack()
    {
        isAttacking = true;
        Debug.Log("Attack Start");
        animator.SetTrigger("Attack"); // Play the attack animation
    }

    // Start the shout animation
    private void StartShout()
    {
        isShouting = true;
        animator.SetTrigger("Shout");
    }

    // The enemy's shout animation ends, either it gets hit or it continues with the attack animation
    private void EndShoutAnimation()
    {
        if (!isShouting)
        {
            animator.SetTrigger("Attack"); // If not hit, start attack animation
        }
        isShouting = false;
    }

    // Handle the enemy getting hit during its attack animation
    public void OnHitWhileAttacking()
    {
        if (isAttacking)
        {
            animator.SetTrigger("Hit"); // Hit animation
            animator.SetTrigger("Attack"); // Restart attack animation
            isAttacking = false; // Exit attacking state
        }
    }

    // Call this when the attack or shout finishes
    public void OnAnimationEnd()
    {
        if (currentHealth <= 0)
        {
            // If the enemy has 1 HP or less, go into dying state (can be an animation change)
            animator.SetTrigger("Die");
        }
        else
        {
            // If still alive, return to idle
            animator.SetTrigger("Idle");
        }
    }

    // Handle the enemy's health being reduced
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            OnDeath();
        }
        else
        {
            animator.SetTrigger("Hit"); // Play hit animation when damage is taken
        }
    }

    // Handle the death state of the enemy
    private void OnDeath()
    {
        animator.SetTrigger("Die");
        // Any additional death logic like disabling AI can go here
    }
}
