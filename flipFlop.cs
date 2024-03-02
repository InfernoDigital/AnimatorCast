using UnityEngine;

public class flipFlop : MonoBehaviour
{
    public GameObject eventReceiver;
    public bool Tracker = false;
    public string Option1;
    public string Option2;

    public void toggle()
    {
        Tracker = !Tracker; // Set Tracker to the opposite of its current state

        // Check if eventReceiver is not null
        if (eventReceiver != null)
        {
            // Get the AnimationAction component on eventReceiver
            AnimatorCast animatorCast = eventReceiver.GetComponent<AnimatorCast>();

            // Check if AnimationAction is not null
            if (animatorCast != null)
            {
                // Call the Rollcall method and pass the appropriate string argument based on Tracker's value
                string optionToPass = Tracker ? Option1 : Option2;
                animatorCast.RollCall(optionToPass);
            }
        }
    }
}
