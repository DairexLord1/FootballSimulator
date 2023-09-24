using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static System.Collections.Specialized.BitVector32;

public class Manager : MonoBehaviour
{
    Team  teamOne;
    Team  teamTwo;

    FootballMember[] footballPlayers;

    public List<Action> actions;

    bool goal = false;

    private void Start()
    {
        CreateTeam();
        GiveBall();

        StartCoroutine(StartMatch());
    }

    void CreateTeam()
    {
        actions = new();
        goal = false;

        actions.Add(new MakeKick());
        actions.Add(new GivePass());
        actions.Add(new MakeGoal());
        actions.Add(new SaveGates());
        actions.Add(new TakeBall());

        teamOne = new Team("teamOne");
        teamTwo = new Team("teamTwo");

        footballPlayers = new FootballMember[teamOne.team.Length + teamTwo.team.Length];

        for (int i = 0; i < teamOne.team.Length; i++)
        {
            footballPlayers[i] = teamOne.team[i];
        }

        for (int i = 0; i < teamTwo.team.Length; i++)
        {
            footballPlayers[teamOne.team.Length + i] = teamTwo.team[i];
        }
    }

    /// <summary>
    /// give ball to a random player
    /// </summary>
    void GiveBall()
    {
        foreach (FootballMember member in footballPlayers)
            member.withBall = false;

        int giveBall = UnityEngine.Random.Range(0, footballPlayers.Length);
        footballPlayers[giveBall].withBall = true;

    }


    IEnumerator StartMatch()
    {
        while (!goal)
        {
           yield return new WaitForSeconds(UnityEngine.Random.Range(1,3.5f));

            SimulateActions();
        }
    }

    

    private void SimulateActions()
    {
        FootballMember player = null;

        foreach (FootballMember member in footballPlayers)
        {
            if (member.withBall)
            {
                player = member;
                Debug.Log($"ball is in  {player.teamName} hands");
            }
        }


        float randomValue = UnityEngine.Random.Range(0f, 1f); // Генеруємо випадкове число від 0 до 100
       
        Action actionTODO = null;

        foreach (Action action in actions)
        {
            randomValue -= action.percent;

            if (randomValue <= 0)
            {
                actionTODO = action;
                break;
            }
        }


        player.PerformAction(actionTODO);

        if (actionTODO.ActionName == "Make Goal")
        {
            goal = true;
            Debug.Log($"{player.teamName} won!!!");
            return;
        }

        GiveBall();
    }
}

