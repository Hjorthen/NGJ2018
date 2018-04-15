<<<<<<< HEAD:Assets/RespawnInterface.cs
﻿using System.Collections;
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
=======
﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnInterface : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
>>>>>>> 2489432ef4baa295ecd08c82a07ae7182e10d296:Assets/Scripts/RespawnInterface.cs
