using UnityEngine;

namespace Cat
{
    public class Idle : State
    {
        Animator anim;
        Play_Input    pi;
        Cat_State_Machime _State_Machime;
        string Name;

        public Idle(Animator anim, Play_Input pi, Cat_State_Machime state_Machime, string name)
        {
            this.anim = anim;
            this.pi = pi;
            this._State_Machime = state_Machime;
            this.Name = name;
        }

        public override void GameLogic()
        {
            //anim.Play(Name);
            float x = pi.Input.moveX;
            Debug.Log("moveX = " + pi.Input.moveX);
           
            // ⭐ 面向控制（這段就是你要的）
            if (x > 0)
            {
                Vector3 s = pi.transform.localScale;
                s.x = Mathf.Abs(s.x);   // 面向右
                pi.transform.localScale = s;
            }
            else if (x < 0)
            {
                Vector3 s = pi.transform.localScale;
                s.x = -Mathf.Abs(s.x);  // 面向左
                pi.transform.localScale = s;
            }

            // ⭐ 狀態切換
            if (Mathf.Abs(x) > 0.1f)
            {
                anim.SetBool("跑",true); // ⭐ 提前開動畫
                Debug.Log("切換到跑");
                _State_Machime.changeto(_State_Machime._run);
                return;
            }
            if (pi.Input.attackPressed)
            {
                pi.Input.attackPressed=false; // ⭐ 只觸發一次
                if (pi.Input.heavy)
                {
                    pi.Input.heavy = false;
                    _State_Machime.changeto(_State_Machime._Attack_Big);
                }
                else
                {
                    _State_Machime.changeto(_State_Machime._Attack_Small);
                }

                return;
                // _play.turn(inputH > 0 ? 1 : -1);
            }
            if (pi.Input.jump && pi.IsGrounded())
            {
                Debug.Log("jump做");

                _State_Machime.changeto(_State_Machime._jump);
                
                return;
            }
        }
        public override void PalyLogic()
        {
            //按下右鍵就撥撥放walk
            float vy = pi.Cat_Rig.linearVelocity.y;
            pi.setv(new Vector2(0f, vy));

        }
        public override void Enter()
        {
            //anim.SetBool("跑", false); // ⭐ 關閉跑
            //anim.SetBool("攻擊1", false);
            pi.Input.ClearOneShot();
            pi.Input.attackPressed = false;
            pi.Input.jump = false;
            Debug.Log("Enter Idle");
            // anim.Play(Name);
            // anim.CrossFade(Name, 0.1f, 0, 0.1f);
            //pi.setv(new Vector3(0, pi.myrigi.linearVelocity.y, 0));
            //pi.movex = 0;
            // pi.Input.attack = false;


        }

        public override void Exit() 
        { }

    }
}