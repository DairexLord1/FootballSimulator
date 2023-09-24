using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Action 
{
    public abstract string ActionName { get; }
    public abstract float percent { get; }

    public abstract void MakeAction(string memberName);
}




public class GivePass : Action
{

    public override string ActionName => "Give Pass";

    public override float percent => 0.3f;

    public override void MakeAction(string memberName)
    {
        Debug.Log($"Player: {memberName} Gave pass  ");
    }
}

public class MakeKick : Action
{
    public override string ActionName => "Make Kick";
    public override float percent => 0.3f;

    public override void MakeAction(string memberName)
    {
        Debug.Log($"Player :{memberName} made kick");
    }
}

public class TakeBall : Action
{
    public override string ActionName => "Take Ball";
    public override float percent => 0.2f;

    public override void MakeAction(string memberName)
    {
        Debug.Log($"Player: { memberName} took ball");
    }
}

public class SaveGates : Action
{
    public override string ActionName => "Save Gates";
    public override float percent => 0.1f;

    public override void MakeAction(string memberName)
    {
        Debug.Log($"Player {memberName} saved gates");
    }
}


public class MakeGoal : Action
{
    public override string ActionName => "Make Goal";
    public override float percent => 0.1f;

    public override void MakeAction(string memberName)
    {
        Debug.Log($"Player {memberName} made Goal");
    }
}


public class Team
{
    public FootballMember[] team;
    public string teamName;

    public Team(string teamName)
    {
        this.teamName = teamName;
        FootballMember[] t = new FootballMember[11];

        for (int i = 0; i < t.Length; i++)
        {
            FootballMember FootballMember = new Defender(Random.Range(0, 1000).ToString(), teamName);
            t[i] = FootballMember;
        }

        FootballMember footballMember = new GoalKeeper(Random.Range(0, 1000).ToString(), teamName);
        t[1] = footballMember;
        team = t;

        Debug.Log($"team: {teamName} created ");
    }
}