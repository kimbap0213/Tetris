using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class T : Block
{

    private void Awake()
    {
        existBlock = new int[4, 4]{ 
            { 0,0,0,0},
            { 0,1,1,1},
            { 0,0,1,0},
            { 0,0,0,0} };
    }
}
