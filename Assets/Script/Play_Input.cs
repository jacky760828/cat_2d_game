using Cat;
using Cat;
using Spine.Unity;
using System.Collections;
using UnityEngine;
using UnityEngine.Windows;
using static UnityEngine.RuleTile.TilingRuleOutput;
#region 主角旗標
public struct InputCommand
{
    // ===== 狀態 =====
    public float moveX;
    public float moveZ;

    public bool run;
    public bool jump;

    public bool attack;
    public bool attackPressed;
   // public bool heavyPressed;
    public bool sweep;
   
    public bool rollForward;

    public bool crouch;
    public bool heavy;

    public void ClearOneShot()
    {
        attack = false;
        sweep = false;
        rollForward = false;
        heavy = false;
    }
}
#endregion




public class Play_Input: MonoBehaviour
{
    // ===== 移動 =====
    public float Run_Speed = 5.0f;
     // ===== 跳躍 =====
    public float jump_high = 2f;
    public float jump_speed;
    // ===== 狀態 =====
    public InputCommand Input;
    public LayerMask groundLayer;
    public Rigidbody2D Cat_Rig;

    // ===== Input =====
    // ===== Component =====
    //public Rigidbody myrigi; // 新增此欄位
    private void Awake()
    {
    Cat_Rig = GetComponent<Rigidbody2D>();
    // model = transform.GetChild(0);
    }

    private void Update()
    {
        float rawX = UnityEngine.Input.GetAxisRaw("Horizontal");
        float rawZ = UnityEngine.Input.GetAxisRaw("Vertical");
        Input.moveX =rawX;
        Input.moveZ = rawZ;
        Debug.DrawRay(transform.position, Vector2.down * 0.2f, Color.red);
        // In this simple implementation, "running" is defined as holding any horizontal input.
        Input.run = Mathf.Abs(rawX) > 0.0f;
        //if (UnityEngine.Input.GetKeyDown(KeyCode.Mouse0))
        //  {
        Input.attack = UnityEngine.Input.GetMouseButtonDown(0);
        // bool wantUppercut = (Time.time - lastForwardTime) <= comboWindow;
        if (Input.attack)
        {
            Input.attackPressed = true;
            if (UnityEngine.Input.GetKey(KeyCode.LeftShift))
            {
                Input.heavy = true;
                Debug.Log("重擊！");
            }
            //else
            //{
            //    Input.attack =false;
            //}
        }
        if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
        {
            //jumpPressed = true;
            Input.jump = true;
        }



        // myrigi.linearVelocity = new Vector3(0, myrigi.linearVelocity.y, 0);
        // }
        //else
        //{
        //    //Input.attack = false;
        //    Input.heavy = false;
        //}
        // You can extend these if you decide to support jumping or attacking later.
        //Input.jump = UnityEngine.Input.GetKeyDown(KeyCode.Space);
        //Input.attack = UnityEngine.Input.GetMouseButtonDown(0);
    }

    public void turn(float duration)
    {
        float angle = duration == +1 ? 90 : 270;

        //角度=角度插值(目前角度,目標角度,時間*轉速)
        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, angle, 0), Time.deltaTime * turn_speed);

    }
    public void setv(Vector2 velocity)
    {
        // Debug.Log("setv called: " + velocity);
        Cat_Rig.linearVelocity = velocity;
        //   Debug.Log("after setv rb vel: " + myrigi.linearVelocity);
    }
    public bool IsGrounded()
    {
        Vector2 pos = transform.position;
        float distance = 0.25f;

        Debug.DrawRay(pos, Vector2.down * distance, Color.red);

        return Physics2D.Raycast(pos, Vector2.down, distance, groundLayer);
    }

}
