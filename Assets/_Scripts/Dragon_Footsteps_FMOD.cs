using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon_Footsteps_FMOD : MonoBehaviour
{
    public float Material;
    public string path;
    public void PlaySoundEvent(string path)
    {
        FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);
    }

    public void PlayFootstepsEvent(string path)
    {
        FMOD.Studio.EventInstance Footsteps = FMODUnity.RuntimeManager.CreateInstance(path);
        Footsteps.setParameterByName("GroundType", Material);
        Footsteps.start();
        Footsteps.release();
    }
    
}
