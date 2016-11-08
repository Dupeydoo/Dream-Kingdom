using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public Text text;
    private enum GameStates {Start, Morning, GenMorning, FieldWalk, StreetVisit, Maids};
    private GameStates currentState;

	// Use this for initialization
	internal void Start () {
        currentState = GameStates.Start;
	}

    // Update is called once per frame
    internal void Update () {
        switch(currentState)
        {
            case GameStates.Start: StartState(); break;
            case GameStates.Morning: MorningState(); break;
            case GameStates.GenMorning: GenMorningState(); break;
            case GameStates.Maids: MaidState(); break;
            case GameStates.FieldWalk: WalkState(); break;
            case GameStates.StreetVisit: VisitState(); break;
            default: break;
        }
    }

    internal void StartState()
    {
        text.text = "Press space to begin...";
        TextInput(KeyCode.Space, GameStates.Morning);
    }

    internal void MorningState()
    {
        text.text = "Once upon a time there was a radiant princess who lived atop the highest " +
                    "castle in the land! It was a quiet age and the people loved their princess " +
                    "and the kingdom their ancestors has created. You see the land of lirashil " +
                    "was a vibrant ectasy of fauna mixed with lush green fields. The grass flowed " +
                    "and danced in the wind just as elegantly as the kingdom's finest entertainers. " +
                    "\"rrrggggghhh.\" It was time for the princess to get up and do her duties for the day. " +
                    "What should the princess do? Press W to walk through the fields, V to visit the streets " +
                    "or C to chat with her maids for a while...";

        MorningChoices();
    }

    internal void GenMorningState()
    {
        text.text = "What will the princess do today? Press W to walk through the fields, V to visit the streets " +
                    "or C to chat with her maids for a while...";

        MorningChoices();
    }

    internal void MaidState()
    {
        text.text = "\"Hey princess have you heard!\", exclaimed the head maid, \"Word is the guards " +
                    "had to take in a man off the streets! They said he wouldn't stop talking about the whispers " +
                    "of the kingdom's corruption.\" The princess pondered this for a moment... what could this mean? " +
                    "She considered it as she continued her day, but had soon forgotten these words. Blissfully unaware she " +
                    "lay down for a nights rest. Press N to continue to the next day...";

        TextInput(KeyCode.N, GameStates.GenMorning);
    }

    internal void WalkState()
    {
        text.text = "The wind blew through the princesses' hair. Bliss. The animals leapt and moved around her, " +
                    "as if they were excited by her presence. She came to her usual field but was dumbfounded... " +
                    "a patch of red and purple dirt. The ground seemed to wriggle and convulse, possessed by some " +
                    "monstrosity from a nightmare. She ran home as fast as she could. It was night by her return, so " +
                    "she tried to sleep... Press N for the next morning";

        TextInput(KeyCode.N, GameStates.GenMorning);
    }

    internal void VisitState()
    {
        text.text = "The people cheered and greeted the princess as she glided gracefully through the " +
                    "the streets. She was generous and empathetic to the poor. A high class lady to the rich, but " +
                    "this is just who she was. Respected and loved by her subjects. Little did she know an abomination " +
                    "had just began to stir... (Wait for the story to continue, press P to play again";

        TextInput(KeyCode.P, GameStates.Start);
    }

    private void MorningChoices()
    {
        TextInput(KeyCode.W, GameStates.FieldWalk);
        TextInput(KeyCode.V, GameStates.StreetVisit);
        TextInput(KeyCode.C, GameStates.Maids);
    }

    private void TextInput(KeyCode kc, GameStates state)
    {
        if(Input.GetKeyDown(kc))
        {
            currentState = state;
        }
    }

}
