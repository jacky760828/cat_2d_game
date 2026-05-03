using Cat;
using UnityEngine;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
public class Jump : State
{
    Animator anim;
    Play_Input pi;
    Cat_State_Machime _State_Machime;
    string Name;
    UnityEngine.Transform transform; // 新增

    public Jump(Animator anim, Play_Input pi, Cat_State_Machime state_Machime, string name)
    {
        this.anim = anim;
        this.pi = pi;
        this._State_Machime = state_Machime;
        this.Name = name;
        this.transform = pi.Cat_Rig.transform; // 假設 Cat_Rig 是 Rigidbody2D 並有 transform 屬性
    }

    public override void Enter()
    {
        Debug.Log("跳躍");

        Vector2 v = pi.Cat_Rig.linearVelocity;
        v.y = pi.jump_high;
        pi.setv(v);

        anim.SetBool("isGround", false);
    }

    public override void GameLogic()
    {
        float vy = pi.Cat_Rig.linearVelocity.y;

        // ⭐ 更新 Blend Tree
        anim.SetFloat("y速度", vy);

        // ⭐ 落地判斷
        if (IsGrounded() && vy <= 0)
        {
            anim.SetBool("isGround", true);

            if (Mathf.Abs(pi.Input.moveX) > 0.1f)
                _State_Machime.changeto(_State_Machime._run);
            else
                _State_Machime.changeto(_State_Machime._idle);
        }
    }

    public override void PalyLogic()
    {
        float vx = pi.Input.moveX * pi.Run_Speed;
        float vy = pi.Cat_Rig.linearVelocity.y;

        pi.setv(new Vector2(vx, vy));
    }

    bool IsGrounded()
    {
        Vector2 pos = transform.position;
        float distance = 0.3f;

        Debug.DrawRay(pos, Vector2.down * distance, Color.red);

        return Physics2D.Raycast(pos, Vector2.down, distance, pi.groundLayer);
    }

    public override void Exit()
    {
   


      }
}
