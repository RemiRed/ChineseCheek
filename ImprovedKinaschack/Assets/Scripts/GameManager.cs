using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    [SerializeField]
    GameObject node, marbles;

    [SerializeField]

    Material[]mats;
    InputManager IM;
    BoardManager BM;

    void Start()
    {
        IM = gameObject.AddComponent<InputManager>();
        this.BM = new BoardManager(this, node, mats); 
            }



	
}
