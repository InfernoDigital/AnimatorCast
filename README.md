# AnimatorCast
An upgraded version of my previous AnimParameterBehavior Script that is meant for use as a script on Gameobjects.

![image](https://github.com/InfernoDigital/AnimatorCast/assets/12396056/3d345291-a2c6-4e3f-8ecc-eb69c085a940)


This script, like the last one, takes an Animator and sequences through a list of Animator Parameters making changes as it goes.
However, the previous script could only be called from within an Animator to change it's own Parameters, whereas this script has a Public Animator Variable
so any gameobject can link to an animator to change it's Parameters.

Additionally, this version of the script now uses "Sequences". Sequences are how a separate GameObject knows which Parameters to change.

The script contains a single major list, called "Sequences" which a user can add as many "Sequences" to as they'd like. Each Sequence has a name
that is set by the user. Inside each "Sequence" you can add a list of "Actions". Each "Action" contains the Name of an Animation Parameter, a drop down
for it's Type, and checkboxes/fields to set the value for each. 

Once each Action in a Sequence is set, another script can call the public "RollCall" method
and pass it the name of one of the Sequences, and RollCall will run through every Action in that sequence, automatically setting the Animation Parameters! It's that easy!

I made this script, using ChatGPT, to make it easier to change the values of parameters in Mass, especially for GUI animations, as they often utilize many parameters to do different things.
It's a major time saver on my end, so I hope you all get use out of it as well!

Cheers!
