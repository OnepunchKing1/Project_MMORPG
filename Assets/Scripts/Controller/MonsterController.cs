using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterController : BaseController
{
    [SerializeField]
    float _scanRange = 10.0f;
    [SerializeField]
    float _attackRange = 2.0f;
    Stat _stat;
    public override void Init()
    {
        WorldObjectType = Define.WorldObject.Monster;
        _stat = gameObject.GetComponent<Stat>();

        if(gameObject.GetComponentInChildren<UI_HPBar>() == null)
        Managers.UI.MakeWorldSpaceUI<UI_HPBar>(transform);
    }

    protected override void UpdateDie()
    {
        
    }
    protected override void UpdateIdle()
    {
        
        GameObject player = Managers.Game.GetPlayer();
        if (player == null)
            return;

        float distance = (player.transform.position - transform.position).magnitude;
        if (distance <= _scanRange)
        {
            _lockTarget = player;
            State = Define.State.Moving;
            return;
        }
            
        
    }
    protected override void UpdateRun()
    {        
        //몬스터
        if (_lockTarget != null)
        {
            _destPos = _lockTarget.transform.position;
            float _distance = (_destPos - transform.position).magnitude;
            if (_distance <= _attackRange)
            {
                NavMeshAgent nma = gameObject.GetComponent<NavMeshAgent>();
                nma.SetDestination(transform.position);
                State = Define.State.Skill;
                return;
            }
        }

        //이동
        Vector3 dir = _destPos - transform.position;
        if (dir.magnitude < 0.1f)
        {
            State = Define.State.Idle;
        }
        else
        {
            NavMeshAgent nma = gameObject.GetComponent<NavMeshAgent>();
            nma.SetDestination(_destPos);
            nma.speed = _stat.MoveSpeed;
           
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10.0f * Time.deltaTime);

        }
    }
    protected override void UpdateSkill()
    {
        if (_lockTarget != null)
        {
            Vector3 dir = _lockTarget.transform.position - transform.position;
            Quaternion quat = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Lerp(transform.rotation, quat, 20 * Time.deltaTime);
        }
    }
    void OnHitEvent()
    {
        if (_lockTarget != null)
        {
            Stat targetStat = _lockTarget.GetComponent<Stat>();
            targetStat.OnAttacked(_stat);

            if (targetStat.Hp <= 0)
            {
                Managers.Game.Despawn(targetStat.gameObject);
            }

            if (targetStat.Hp > 0)
            {
                float distance = (_lockTarget.transform.position - transform.position).magnitude;
                if (distance <= _attackRange)
                    State = Define.State.Skill;
                else
                    State = Define.State.Moving;
            }
        }
        else
        {
            State = Define.State.Idle;
        }
    }
}
