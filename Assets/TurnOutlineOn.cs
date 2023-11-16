using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOutlineOn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Turn on the outline
        GetComponent<Outline>().enabled = true;
        
    }
}
