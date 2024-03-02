using UnityEngine;
using System;
using System.Collections.Generic;

[System.Serializable]
public class AnimationAction
{
    public string parameterName;
    public AnimationParameterType parameterType;
    public bool boolValue;
    public float floatValue;
    public int intValue;
    public bool isSetTrigger; // Checkbox to determine whether to set or reset the trigger
}

[System.Serializable]
public class AnimationSequence
{
    public string sequenceName; // Name to label the sequence
    public List<AnimationAction> actions = new List<AnimationAction>();
}

public enum AnimationParameterType
{
    Trigger,
    Bool,
    Float,
    Int
}

public class AnimatorCast : MonoBehaviour
{
    // Public animator variable
    public Animator animator;

    public bool DebugEnabled;

    // List of animation sequences
    public List<AnimationSequence> sequences = new List<AnimationSequence>();

    // Public method to perform the roll call for a specific sequence by name
    public void RollCall(string sequenceName)
    {

        if (DebugEnabled) 
        { 
            Debug.LogWarning("Warning. RollCalling " + sequenceName);
        }

        // Check if the animator is assigned
        if (animator == null)
        {
            Debug.LogWarning("Animator not assigned for AnimatorCast.");
            return;
        }

        // Find the sequence with the specified name
        AnimationSequence sequence = sequences.Find(seq => seq.sequenceName == sequenceName);

        // Check if the sequence is found
        if (sequence == null)
        {
            Debug.LogWarning($"Sequence '{sequenceName}' not found.");
            return;
        }

        Debug.Log($"Running sequence: {sequence.sequenceName}");

        // Loop through each animation action in the sequence
        foreach (var action in sequence.actions)
        {
            // Check the parameter type and set/reset the corresponding value
            switch (action.parameterType)
            {
                case AnimationParameterType.Trigger:
                    if (action.isSetTrigger)
                    {
                        animator.SetTrigger(action.parameterName);
                    }
                    else
                    {
                        animator.ResetTrigger(action.parameterName);
                    }
                    break;
                case AnimationParameterType.Bool:
                    animator.SetBool(action.parameterName, action.boolValue);
                    break;
                case AnimationParameterType.Float:
                    animator.SetFloat(action.parameterName, action.floatValue);
                    break;
                case AnimationParameterType.Int:
                    animator.SetInteger(action.parameterName, action.intValue);
                    break;
                default:
                    Debug.LogWarning("Unsupported animation parameter type.");
                    break;
            }
        }

        if (DebugEnabled)
        {
            Debug.LogWarning("Warning. RollCalling " + sequenceName + " Completed.");
        }

    }
}
