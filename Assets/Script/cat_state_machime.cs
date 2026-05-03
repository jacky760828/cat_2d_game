using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.Rendering;
using static Spine.Unity.Examples.BasicPlatformerController;

namespace Cat
{ 
   public class Cat_State_Machime: MonoBehaviour
    {
        private State _State;//動畫改變
        private Animator _anim;
        private Play_Input pi;
        public audio_manage Audio { get; private set; }
        public Idle _idle;
        public Run _run;
        public Attack_Big   _Attack_Big;
        public Attack_Small _Attack_Small;
        public Attack_Throw _Attack_Throw;
        public Jump _jump;
        public Roll _roll;
        public Dead _dead;
        //public back_walk _back_walk;
        //public air_punch1 _uppercut;
        //public heavy_attack _heavy;
        //public air_punch3 _air_punch3;
        //public kick _kick;
        //public stop _stop;
        //public crouch _crouch;
        //public sweep _sweep;
        //public roll_b _roll_b;
        //public down _down;
        //public Get_up _Get_up;
        public bool Dead = false;
        private void FixedUpdate()
        {
            _State?.PalyLogic();
        }

        private void Awake()
        {
            InitComponents();
            InitStates();
            //InitFacing();
        }
        private void Start()
        {
            
            if (_idle != null)
            {
                Current_state(_idle);
            }
        }

        void Current_state(State newstate)
        {
            _State = newstate;
            _State.Enter();

        }


        private void Update()
        {
            // Run the game logic for the current state once per frame.
            _State?.GameLogic();
        }
        void InitStates()
        {
            _idle = new Idle(_anim, pi, this,"待機");
            _run = new Run(_anim, pi, this,"跑");
            _Attack_Small= new Attack_Small(_anim, pi, this,"攻擊1");
            _Attack_Big = new Attack_Big(_anim, pi, this, "攻擊3");
            _jump= new Jump(_anim, pi, this, "跳");
        }
        void InitComponents()
        {
            _anim = GetComponentInChildren<Animator>();
            pi = GetComponent<Play_Input>();
            if (_anim == null)
            {
                Debug.LogError("找不到 Animator！");
            }
            //ch_stats = GetComponent<CharacterStats>();
            Audio = Object.FindFirstObjectByType<audio_manage>();
            //Hitboxes = GetComponent<att_control>(); // ✅ 角色身上要掛這個腳本
            //if (_anim == null) Debug.LogError("找不到 Animator");
            //if (pi == null) Debug.LogError("找不到 playinput");
            //if (Hitboxes == null) Debug.LogWarning("找不到 att_control，攻擊 hitbox 可能無法開啟");
        }


        
        public void changeto(State newstate)
        {
            if (Dead) return;

            _State.Exit();
            _State = newstate;
            _State.Enter();
        }
    }
}
