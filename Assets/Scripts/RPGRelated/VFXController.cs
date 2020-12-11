using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.VFX;
using UnityEngine.VFX;

public class VFXController : MonoBehaviour
{
    public float duration = 2.0f;
    public float timer = 0f;
    private VisualEffect visualEffect;

    AudioSource equipAudio;

    void Start()
    {
        //bool DestroyOnEnd = false;
        visualEffect = GetComponent<VisualEffect>();
        equipAudio = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
    }

    public IEnumerator Play()
    {
        //visualEffect.SendEvent("OnPlay");
        visualEffect.Play();
        equipAudio.Play();
        yield return new WaitForSeconds(1);
        visualEffect.Stop();
        /*if (timer >= duration)
        {
            Debug.Log("Stop");
            visualEffect.Stop();
        }*/
    }
}
