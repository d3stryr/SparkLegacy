using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : State
{
    private const string ANIM_RUNNING = "Run_Animation";
    private string ANIM_WALK_PFX = "SmokeWalking";
    private string ANIM_WALK_IDLE = "walkingIdle";

    [SerializeField] private float m_maxXSpeed = 2.5f;
    [SerializeField] private Animator m_walkPfxAnimator;
    public float MaxSpeed => m_maxXSpeed;
    
    public override void Enter()
    {
        base.Enter();
        m_characterCore.animator.Play(ANIM_RUNNING);
        m_walkPfxAnimator.Play(ANIM_WALK_PFX);
    }

    public override void Do()
    {
        base.Do();
        float velX = m_characterCore.rigidBody.velocity.x;
        m_characterCore.animator.speed = Helpers.Map(m_maxXSpeed, 0, 1, 0, 1.6f, true);
      
        if (!m_characterCore.groundSensor.isGrounded || m_characterCore.rigidBody.velocity.x == 0)
        {
            isComplete = true;
        }
    }

    public override void FixedDo()
    {
        base.FixedDo();
    }

    public override void Exit()
    {
        base.Exit();
        m_walkPfxAnimator.Play(ANIM_WALK_IDLE);
    }
}
