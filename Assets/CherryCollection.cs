using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CherryCollection : MonoBehaviour
{

    public bool collected = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.name == "Cherry"){
            collected = true;
        }
    }

    void OnTriggerExit(Collider other){
        if(other.gameObject.name == "Cherry"){
            collected = false;
        }
    }
}
