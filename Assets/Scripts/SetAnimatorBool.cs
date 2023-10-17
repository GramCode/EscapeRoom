using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEditorInternal;
using UnityEngine;

public class SetAnimatorBool : MonoBehaviour
{
    [SerializeField]
    private Animator _animator;
    // Start is called before the first frame update
   
    public void SetAnimatorBoolValue(string name, bool value)
    {
        _animator.SetBool(name, value);
    }
}
