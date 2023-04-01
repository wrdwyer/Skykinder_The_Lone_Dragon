using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardFootsteps_FMOD : MonoBehaviour
{
    public string path;

    public void PlayFootstepsEvent(string path)
    {
        FMOD.Studio.EventInstance Footsteps = FMODUnity.RuntimeManager.CreateInstance(path);
        Footsteps.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        Footsteps.start();
        Footsteps.release();
    }

    public void AttackAxeEvent(string path)
    {
        FMOD.Studio.EventInstance Footsteps = FMODUnity.RuntimeManager.CreateInstance(path);
        Footsteps.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        Footsteps.start();
        Footsteps.release();
    }

    public void PlayLookingAroundEvent(string path)
    {
        FMOD.Studio.EventInstance LookAround = FMODUnity.RuntimeManager.CreateInstance(path);
        LookAround.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        LookAround.start();
        LookAround.release();
    }

    public void PlayBoredEvent(string path)
    {
        FMOD.Studio.EventInstance Bored = FMODUnity.RuntimeManager.CreateInstance(path);
        Bored.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        Bored.start();
        Bored.release();
    }
}


