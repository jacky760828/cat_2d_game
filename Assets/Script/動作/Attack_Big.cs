using Cat;
using UnityEngine;

public class Attack_Big:State
{

    Animator anim;
    Play_Input pi;
    Cat_State_Machime _State_Machime;
    string Name;
    float timer = 0f;
    float attackDuration = 0.3f; // ⭐ 攻擊時間（依動畫長度調整）

    public Attack_Big(Animator anim, Play_Input pi, Cat_State_Machime state_Machime, string name)
    {
        this.anim = anim;
        this.pi = pi;
        this._State_Machime = state_Machime;
        this.Name = name;
    }

    public override void Enter()
    {
        
        anim.SetTrigger("攻擊3"); // ⭐ 大攻擊用Trigger，避免動畫卡住
        Game_Manager.Instance.Audio?.play(3, "打3", false, 1f);
        timer = 0f;
    }

    public override void GameLogic()
    {
        timer += Time.deltaTime;

        // ⭐ 攻擊結束
        if (timer >= attackDuration)
        {
            anim.SetBool("攻擊3", false);
            Debug.Log("攻擊結束，回Idle或Run");
            // 判斷回哪個狀態
            if (Mathf.Abs(pi.Input.moveX) > 0.1f)
                _State_Machime.changeto(_State_Machime._run);
            else
                _State_Machime.changeto(_State_Machime._idle);
        }
    }

    public override void PalyLogic()
    {
        // 攻擊時不移動（可改成慢速移動）
        float vy = pi.Cat_Rig.linearVelocity.y;
        pi.setv(new Vector2(0, vy));
    }

    public override void Exit()
    {
        // pi.Input.attack = false;
        //anim.SetBool("攻擊1", false);
    }
}
