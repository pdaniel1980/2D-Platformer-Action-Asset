using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControls : MonoBehaviour
{
    [SerializeField] private GatherInput gInput;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gInput.tryToAttack)
        { 
            gInput.tryToAttack = false;
        }
    }
}
