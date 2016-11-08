using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/**
**********************************************************************************************
A simple textadventure game using Unity. In essence a very simple state machine, mapping from
each state using keybindings.

Author: James Du Plessis
Version: 1.0.0
See: Unity libraries
*********************************************************************************************

*/
public class TextController : MonoBehaviour {

    public Text text;
    private enum GameStates {Start, Morning, GenMorning, FieldWalk, StreetVisit, Maids}; //a type for game states
    private GameStates currentState;

	/*
        Start method, called upon the beginning of the game
    */
	internal void Start () {
        currentState = GameStates.Start; //when we start the state is the starting state
	}

    /*
        Each frame check the state and carry out a StateHandler depending
    */
    internal void Update () {
        switch(currentState)
        {
            case GameStates.Start: StartState(); break;  //if start state -> call Start handler
            case GameStates.Morning: MorningState(); break;
            case GameStates.GenMorning: GenMorningState(); break;
            case GameStates.Maids: MaidState(); break;
            case GameStates.FieldWalk: WalkState(); break;
            case GameStates.StreetVisit: VisitState(); break;
            default: break;
        }
    }

    #region StateHandler functions

    /*
        Handles the start state
    */
    internal void StartState()
    {
        text.text = "Press space to begin...";
        TextInput(KeyCode.Space, GameStates.Morning); //when space is pressed, new morning
    }

    /*
        Handles the initial morning state
    */
    internal void MorningState()
    {
        text.text = "Chapter 1: Once upon a time there was a radiant princess who lived atop the highest " +
                    "castle in the land! It was a quiet age and the people loved their princess " +
                    "and the kingdom their ancestors has created. You see the land of lirashil " +
                    "was a vibrant ectasy of fauna mixed with lush green fields. The grass flowed " +
                    "and danced in the wind just as elegantly as the kingdom's finest entertainers. " +
                    "\"rrrggggghhh.\" It was time for the princess to get up and do her duties for the day. " +
                    "What should the princess do?\n\nPress W to walk through the fields, V to visit the streets " +
                    "or C to chat with her maids for a while...";

        MorningChoices(); //generic morning choice, see TextController.MorningChoices()
    }

    /*
        Handles the normal morning state
    */
    internal void GenMorningState()
    {
        text.text = "What will the princess do today?\n\nPress W to walk through the fields, V to visit the streets " +
                    "or C to chat with her maids for a while...";

        MorningChoices();
    }

    /*
        Handles the talking to maids state
    */
    internal void MaidState()
    {
        text.text = "\"Hey princess have you heard!\", exclaimed the head maid, \"Word is the guards " +
                    "had to take in a man off the streets! They said he wouldn't stop talking about the whispers " +
                    "of the corruption.\" The princess pondered this for a moment... what could this mean? " +
                    "She considered it as she continued her day, but had soon forgotten these words. Blissfully unaware she " +
                    "lay down for a nights rest.\n\nPress N to continue to the next day...";

        TextInput(KeyCode.N, GameStates.GenMorning);
    }

    /*
        Handles the going for a walk in fields state
    */
    internal void WalkState()
    {
        text.text = "The wind blew through the princesses' hair. Bliss. The animals leapt and moved around her, " +
                    "as if they were excited by her presence. She came to her usual field but was dumbfounded... " +
                    "a patch of red and purple dirt. The ground seemed to wriggle and convulse, possessed by some " +
                    "monstrosity from a nightmare. She ran home as fast as she could. It was night by her return, so " +
                    "she tried to sleep...\n\nPress N for the next morning";

        TextInput(KeyCode.N, GameStates.GenMorning);
    }

    /*
        Handles the street visit state
    */
    internal void VisitState()
    {
        text.text = "The people cheered and greeted the princess as she glided gracefully through the " +
                    "the streets. She was generous and empathetic to the poor. A high class lady to the rich, but " +
                    "this is just who she was. Respected and loved by her subjects. Little did she know the nightmare " +
                    "was awakening...\n\nPress N for the next morning or 2 to moved onto the next chapter";

        TextInput(KeyCode.N, GameStates.GenMorning);
        TextInput(KeyCode.Alpha2, GameStates.Start);
    }

    #endregion

    #region Helper functions

    /*
        Generates the input choices you'd expect from a normal morning
    */
    private void MorningChoices()
    {
        TextInput(KeyCode.W, GameStates.FieldWalk);
        TextInput(KeyCode.V, GameStates.StreetVisit);
        TextInput(KeyCode.C, GameStates.Maids);
    }

    /*
        Handles usual keypress input

        @param kc     A KeyCode from the KeyCode enum representing a keypress
        @param state  A state representing a game state from the GameStates enum
    */
    private void TextInput(KeyCode kc, GameStates state)
    {
        if(Input.GetKeyDown(kc)) //for a given key mapping, change to the right state
        {
            currentState = state;
        }
    }
    #endregion
}
