using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace catGirlDemo
{
    public class CatGirl : MonoBehaviour
    {
        public Animator animator;

        public void Dash()
        {
            animator.SetTrigger("Dash");
        }

        public void Dive()
        {
            animator.SetTrigger("Dive");
        }

        public void Dangling()
        {
            animator.SetTrigger("Dangling");
        }

        public void Dodge()
        {
            animator.SetTrigger("Dodge");
        }

        public void Idle1()
        {
            animator.SetTrigger("Idle1");
        }

        public void Idle2()
        {
            animator.SetTrigger("Idle2");
        }

        public void Walk()
        {
            animator.SetTrigger("Walk");
        }

        public void Run()
        {
            animator.SetTrigger("Run");
        }

        public void Wallclinging()
        {
            animator.SetTrigger("Wall-clinging");
        }

        public void Crawling()
        {
            animator.SetTrigger("Crawling");
        }

        public void Crouching()
        {
            animator.SetTrigger("Crouching");
        }

        public void Attack1()
        {
            animator.SetTrigger("Attack1");
        }

        public void Attack2()
        {
            animator.SetTrigger("Attack2");
        }

        public void Attack3()
        {
            animator.SetTrigger("Attack3");
        }

        public void SwimIdle()
        {
            animator.SetTrigger("Swim-idle");
        }

        public void Swimming()
        {
            animator.SetTrigger("Swimming");
        }

        public void Ground()
        {
            animator.SetTrigger("Ground");
        }

        public void PushIdle()
        {
            animator.SetTrigger("Push-idle");
        }

        public void Pulling()
        {
            animator.SetTrigger("Pulling");
        }

        public void Pushing()
        {
            animator.SetTrigger("Pushing");
        }

        public void LadderIdle()
        {
            animator.SetTrigger("Ladder-idle");
        }

        public void LadderClimbUp()
        {
            animator.SetTrigger("Ladder-climbUp");
        }

        public void LadderClimbDown()
        {
            animator.SetTrigger("Ladder-climbDown");
        }

        public void AirDeath()
        {
            animator.SetTrigger("AirDeath");
        }

        public void AirDeathGround()
        {
            animator.SetTrigger("AirDeath-ground");
        }

        public void Death()
        {
            animator.SetTrigger("Death");
        }

        public void Hurt()
        {
            animator.SetTrigger("Hurt");
        }

        public void GlideIdle()
        {
            animator.SetTrigger("Glide-idle");
        }

        public void GlideFlying()
        {
            animator.SetTrigger("Glide-flyinging");
        }

        public void GripIdle()
        {
            animator.SetTrigger("Grip-idle");
        }

        public void GripMoving()
        {
            animator.SetTrigger("Grip-moving");
        }

        public void Jump1Up()
        {
            animator.SetTrigger("Jump1-up");
        }

        public void Jump1Down()
        {
            animator.SetTrigger("Jump1-down");
        }

        public void Jump2Up()
        {
            animator.SetTrigger("Jump2-up");
        }

        public void Jump2Down()
        {
            animator.SetTrigger("Jump2-down");
        }
    }
}

