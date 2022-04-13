using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
<<<<<<< HEAD
    // Start is called before the first frame update
    void Start()
    {
        
=======
    public static PlayerController instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (!instance)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
>>>>>>> ea510710 (imported dialogue system from previous project.)
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
=======
        
>>>>>>> ea510710 (imported dialogue system from previous project.)
    }
}
