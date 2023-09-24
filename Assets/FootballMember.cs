using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootballMember
{
    public string memberName { get; set; }
    public string teamName { get; set; }

   

    public bool withBall = false;

    public FootballMember(string memberName, string teamName)
    {
        this.memberName = memberName;
        this.teamName = teamName;
    }

    public void PerformAction(Action action)
    {
        action.MakeAction(memberName);
    }
}
