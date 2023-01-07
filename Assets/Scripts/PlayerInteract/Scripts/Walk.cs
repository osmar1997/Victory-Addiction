using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour
{
    [SerializeField]
    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim.SetBool("Combat Idle", true);
    }

   
}
