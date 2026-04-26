using Cat;
using UnityEngine;

public class Attack_Small : State
{
    Animator anim;
    Play_Input pi;
    Cat_State_Machime _State_Machime;
    string Name;

    public Attack_Small(Animator anim, Play_Input pi, Cat_State_Machime state_Machime, string name)
    {
        this.anim = anim;
        this.pi = pi;
        this._State_Machime = state_Machime;
        this.Name = name;
    }




}
