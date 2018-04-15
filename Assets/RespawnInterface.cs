using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RespawnInterface : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Button b = GetComponent<Button>();

        b.onClick.AddListener(DoRespawn);
	}
	
    public void DoRespawn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
