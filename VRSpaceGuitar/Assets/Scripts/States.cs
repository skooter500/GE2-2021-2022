using System.Collections;
using System.Collections.Generic;
using UnityEngine;


class PatrolState : State
{
    public override void Enter()
    {
        owner.GetComponent<FollowPath>().enabled = true;
    }

    public override void Think()
    {
        if (Vector3.Distance(
            owner.GetComponent<Fighter>().enemy.transform.position,
            owner.transform.position) < 10)
        {
            owner.ChangeState(new DefendState());
        }
    }

    public override void Exit()
    {
        owner.GetComponent<FollowPath>().enabled = false;
    }
}

public class DefendState : State
{
    public override void Enter()
    {
        owner.GetComponent<Pursue>().target = owner.GetComponent<Fighter>().enemy.GetComponent<Boid>();
        owner.GetComponent<Pursue>().enabled = true;
    }

    public override void Think()
    {
        Vector3 toEnemy = owner.GetComponent<Fighter>().enemy.transform.position - owner.transform.position; 
        if (Vector3.Angle(owner.transform.forward, toEnemy) < 45 && toEnemy.magnitude < 20)
        {
            GameObject bullet = GameObject.Instantiate(owner.GetComponent<Fighter>().bullet, owner.transform.position + owner.transform.forward * 2, owner.transform.rotation);
            owner.GetComponent<Fighter>().ammo --;        
        }
        if (Vector3.Distance(
            owner.GetComponent<Fighter>().enemy.transform.position,
            owner.transform.position) > 30)
        {
            owner.ChangeState(new PatrolState());
        }
    }

    public override void Exit()
    {
        owner.GetComponent<Pursue>().enabled = false;
    }

}


public class AttackState : State
{
    public override void Enter()
    {
        owner.GetComponent<Pursue>().target = owner.GetComponent<Fighter>().enemy.GetComponent<Boid>();
        owner.GetComponent<Pursue>().enabled = true;
    }

    public override void Think()
    {
        Vector3 toEnemy = owner.GetComponent<Fighter>().enemy.transform.position - owner.transform.position; 
        if (Vector3.Angle(owner.transform.forward, toEnemy) < 45 && toEnemy.magnitude < 30)
        {
            GameObject bullet = GameObject.Instantiate(owner.GetComponent<Fighter>().bullet, owner.transform.position + owner.transform.forward * 2, owner.transform.rotation);
            owner.GetComponent<Fighter>().ammo --;
        }        
        if (Vector3.Distance(
            owner.GetComponent<Fighter>().enemy.transform.position,
            owner.transform.position) < 10)
        {
            owner.ChangeState(new FleeState());
        }

    }

    public override void Exit()
    {
        owner.GetComponent<Pursue>().enabled = false;
    }
}

public class FleeState : State
{
    public override void Enter()
    {
        owner.GetComponent<Flee>().targetGameObject = owner.GetComponent<Fighter>().enemy;
        owner.GetComponent<Flee>().enabled = true;
    }

    public override void Think()
    {
        if (Vector3.Distance(
            owner.GetComponent<Fighter>().enemy.transform.position,
            owner.transform.position) > 30)
        {
            owner.ChangeState(new AttackState());
        }
    }
    public override void Exit()
    {
        owner.GetComponent<Flee>().enabled = false;
    }
}

public class Alive:State
{
    public override void Think()
    {

        if (owner.GetComponent<Fighter>().health <= 0)
        {
            Dead dead = new Dead();
            owner.ChangeState(dead);
            owner.SetGlobalState(dead);
            return;
        }

        if (owner.GetComponent<Fighter>().health <= 2)
        {
            owner.ChangeState(new FindHealth());
            return;
        }
        
        if (owner.GetComponent<Fighter>().ammo <= 0)
        {
            owner.ChangeState(new FindAmmo());
            return;
        }
    }
}

public class Dead:State
{
    public override void Enter()
    {
        SteeringBehaviour[] sbs = owner.GetComponent<Boid>().GetComponents<SteeringBehaviour>();
        foreach(SteeringBehaviour sb in sbs)
        {
            sb.enabled = false;
        }
        owner.GetComponent<StateMachine>().enabled = false;        
    }         
}

public class FindAmmo:State
{
    Transform ammo;
    public override void Enter()
    {
        GameObject[] ammos = GameObject.FindGameObjectsWithTag("Ammo");
        // Find the closest ammo;
        Transform closest = ammos[0].transform;
        foreach(GameObject go in ammos)
        {
            if (Vector3.Distance(go.transform.position, owner.transform.position) <
                Vector3.Distance(closest.position, owner.transform.position))
                {
                    closest = go.transform;
                }
        }
        ammo = closest;
        owner.GetComponent<Seek>().targetGameObject = ammo.gameObject;
        owner.GetComponent<Seek>().enabled = true;
    }

    public override void Think()
    {
        // If the other guy already took tghe ammo
        if (ammo == null)
        {
            owner.ChangeState(new FindAmmo());
            return;
        }
        if (Vector3.Distance(owner.transform.position, ammo.position) < 1)
        {
            owner.GetComponent<Fighter>().ammo += 10;
            owner.RevertToPreviousState();
            GameObject.Destroy (ammo.gameObject);
        }
    }

    public override void Exit()
    {
        owner.GetComponent<Seek>().enabled = false;
    }
}

public class FindHealth:State
{
    Transform health;
    public override void Enter()
    {
        GameObject[] healths = GameObject.FindGameObjectsWithTag("Health");
        // Find the closest ammo;
        Transform closest = healths[0].transform;
        foreach(GameObject go in healths)
        {
            if (Vector3.Distance(go.transform.position, owner.transform.position) <
                Vector3.Distance(closest.position, owner.transform.position))
                {
                    closest = go.transform;
                }
        }
        health = closest;
        owner.GetComponent<Seek>().targetGameObject = health.gameObject;
        owner.GetComponent<Seek>().enabled = true;
    }

    public override void Think()
    {
        // If the other guy already took the health
        if (health == null)
        {
            owner.ChangeState(new FindHealth());
            return;
        }
        if (Vector3.Distance(owner.transform.position, health.transform.position) < 2)
        {
            owner.GetComponent<Fighter>().health += 10;
            owner.RevertToPreviousState();
            GameObject.Destroy (health.gameObject);
        }
    }

    public override void Exit()
    {
        owner.GetComponent<Seek>().enabled = false;
    }
}