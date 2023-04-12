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

    public void DragonBreathing (string path)
    {
        FMOD.Studio.EventInstance Footsteps = FMODUnity.RuntimeManager.CreateInstance(path);
        Footsteps.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        Footsteps.start();
        Footsteps.release();
    }

/*
public class AnimationSoundHandler : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField, EventRef] private string fmodEventPath;

    private FMOD.Studio.EventInstance eventInstance;
    private FMOD.Studio.PLAYBACK_STATE playbackState;

    private string currentAnimationName;

    private void Start()
    {
        animator = GetComponent<Animator>();
        eventInstance = RuntimeManager.CreateInstance(fmodEventPath);
    }

    private void Update()
    {
        AnimatorClipInfo[] currentClipInfo = animator.GetCurrentAnimatorClipInfo(0);
        string newAnimationName = currentClipInfo[0].clip.name;

        if (newAnimationName != currentAnimationName)
        {
            currentAnimationName = newAnimationName;
            eventInstance.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            eventInstance.start();
        }

        eventInstance.getPlaybackState(out playbackState);
    }

    private void OnDestroy()
    {
        eventInstance.release();
    }
}*/




    
}
