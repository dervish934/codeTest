using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Terminal.WriteLine("HELLO, THIS IS DREIDEL INTERACTIVE");
        Terminal.WriteLine("WHAT WOULD YOU LIKE TO DO?");

        Terminal.WriteLine("-Tinos");
        Terminal.WriteLine("-Bingos");
        Terminal.WriteLine("-Slots");

        Terminal.WriteLine("Enter your selection:");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
