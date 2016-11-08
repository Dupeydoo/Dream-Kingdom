using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    public Text text;
    private enum GameStates {Start, Morning, GenMorning, FieldWalk, StreetVisit, Maids};
    private GameStates currentState;

	// Use this for initialization
	void Start () {
        currentState = GameStates.Start;
	}
	
	// Update is called once per frame
	void Update () {
        switch(currentState)
        {
            case GameStates.Start: StartState(); break;
            case GameStates.Morning: MorningState(); break;
            case GameStates.GenMorning: GenMorningState(); break;
            case GameStates.Maids: MaidState(); break;
            default: break;
        }
    }

    void StartState()
    {
        text.text = "Press space to begin...";
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentState = GameStates.Morning;
        }
    }

    void MorningState()
    {
        text.text = "Once upon a time there was a radiant princess who lived atop the highest " +
                    "castle in the land! It was a quiet age and the people loved their princess " +
                    "and the kingdom their ancestors has created. You see the land of lirashil " +
                    "was a vibrant ectasy of fauna mixed with lush green fields. The grass flowed " +
                    "and danced in the wind just as elegantly as the kingdom's finest entertainers. " +
                    "\"rrrggggghhh.\" It was time for the princess to get up and do her duties for the day. " +
                    "What should the princess do? Press w to walk through the fields, v to visit the streets " +
                    "or c to chat with her maids for a while...";

        MorningChoices();
    }

    void GenMorningState()
    {
        text.text = "What will the princess do today? Press w to walk through the fields, v to visit the streets " +
                    "or c to chat with her maids for a while...";

        MorningChoices();
    }

    void MaidState()
    {
        text.text = "\"Hey princess have you heard!\", exclaimed the head maid, \"Word is the guards " +
                    "had to take in a man off the streets! They said he wouldn't stop talking about the whispers " +
                    "of the kingdom's corruption.\" The princess pondered this for a moment... what could this mean? " +
                    "She considered it as she continued her day, but had soon forgotten these words. Blissfully unaware she " +
                    "lay down for a nights rest. Press n to continue to the next day...";

        if (Input.GetKeyDown(KeyCode.N))
            currentState = GameStates.GenMorning;
    }

    private void MorningChoices()
    {
        if (Input.GetKeyDown(KeyCode.W))
            currentState = GameStates.FieldWalk;

        else if (Input.GetKeyDown(KeyCode.V))
            currentState = GameStates.StreetVisit;

        else if (Input.GetKeyDown(KeyCode.C))
            currentState = GameStates.Maids;
    }

}
