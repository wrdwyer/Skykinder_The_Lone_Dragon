using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFMOD : MonoBehaviour
{
    public string path;

    public void DeathEvent(string path)
    {
        FMOD.Studio.EventInstance Footsteps = FMODUnity.RuntimeManager.CreateInstance(path);
        Footsteps.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        Footsteps.start();
        Footsteps.release();
    }
}
