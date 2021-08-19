using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlePlayer : MonoBehaviour
{
    [SerializeField] 
    ParticleSystem birthParticles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            
            PlayParticles();
        }
    }

    public void PlayParticles()
    {
        Debug.Log("Playing the particles... now!");
        //birthParticles.Play();
        birthParticles.Play(true);
    }
}
