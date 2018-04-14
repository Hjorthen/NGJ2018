using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour {

    public List<Minigame> minigames;
    public float noDamageStreakTime = 15; //Seconds

    float lastDamageTime = Time.timeSinceLevelLoad;
    bool minigameActive = false;
    

	// Update is called once per frame
	void Update () {
        //If the player manages to not take damage for a while a minigame challenge should start
        if (lastDamageTime - Time.timeSinceLevelLoad >= noDamageStreakTime)
        {
            StartMinigame();
        }
	}

    void StartMinigame()
    {
        Minigame minigame = minigames[Random.Range(0, minigames.Count)];
        minigame.StartGame();
    }

    public void endMinigame()
    {
        minigameActive = false;
        lastDamageTime = Time.timeSinceLevelLoad; //Reset timer so a new game does not start instantly
    }
}
