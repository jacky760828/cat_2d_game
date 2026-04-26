using Cat;
using UnityEngine;
using UnityEngine.Windows;

public class Run:State
{
    Animator anim;
    Play_Input pi;
    Cat_State_Machime _State_Machime;
    string Name;

    public Run(Animator anim, Play_Input pi, Cat_State_Machime state_Machime, string name)
    {
        this.anim = anim;
        this.pi = pi;
        this._State_Machime = state_Machime;
        this.Name= name;
    }

    public override void GameLogic()
    {
       
       // anim.Play(Name);
        Debug.Log("狀態= "+Name);
        //if (!pi.input.run)
        //{
        //    _statemachine.changeto(_statemachine._stop);
        //    return;
        //}
        if (pi.Input.moveX == 0)
        {
            _State_Machime.changeto(_State_Machime._idle);
            return;
        }
        //if (pi.input.attack)
        //{
        //    //Debug.Log("punch");
        //    _statemachine.changeto(_statemachine._punch);
        //    return;
        //    // _play.turn(inputH > 0 ? 1 : -1);
        //}
        //if (pi.input.jump)
        //{
        //    _statemachine.changeto(_statemachine._jump);
        //    return;
        //}
    }
    public override void PalyLogic()
    {
        //按下右鍵就撥撥放walk
        // pi.setv(Vector2.zero);

        float vx = pi.Input.moveX * pi.Run_Speed;
        float vy = pi.Cat_Rig.linearVelocity.y;

        pi.setv(new Vector2(vx, vy));

    }
    public override void Enter()
    {
        anim.SetBool("跑", true); // ⭐ 開啟跑
                                     // anim.Play(Name); // ⭐ Mecanim用這個
                                     // anim.CrossFade(Name, 0.1f, 0); // ⭐ 只在這裡播
        Debug.Log("Enter Run");
      // Debug.Log(anim.GetCurrentAnimatorStateInfo(0).normalizedTime);
        //pi.setv(new Vector3(0, pi.myrigi.linearVelocity.y, 0));
        //pi.movex = 0;
        pi.Input.attack = false;
        //anim.Play(Name);

    }

    public override void Exit()
    {
        anim.SetBool(Name, false); // ⭐ 開啟跑
    }

}
