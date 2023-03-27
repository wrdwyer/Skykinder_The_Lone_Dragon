using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonFire_FMOD : MonoBehaviour
{
  public string path;

    private void Start() 
    {
      PlayFireballEvent(path);
    }
    public void PlayFireballEvent(string path)
    {
        FMOD.Studio.EventInstance Fireball = FMODUnity.RuntimeManager.CreateInstance(path);
        Fireball.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        Fireball.start();
        Fireball.release();
    }
     public void PlayFireballCollideEvent()
    {
        FMOD.Studio.EventInstance Fireball = FMODUnity.RuntimeManager.CreateInstance("event:/SkyKender/FireballCollide");
        Fireball.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject));
        Fireball.start();
        Fireball.release();
    }
}
