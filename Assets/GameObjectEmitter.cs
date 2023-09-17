using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectEmitter : MonoBehaviour
{
    [field: SerializeField] public GameObject ObjectPrefub { get; private set; }

    private ParticleSystem _ps;
    private List<ParticleSystem.Particle> exitParticles = new();

    private void Start()
    {
        _ps = GetComponent<ParticleSystem>();
    }

    private void OnParticleTrigger()
    {
        _ps.GetTriggerParticles(ParticleSystemTriggerEventType.Exit, exitParticles);

        foreach(ParticleSystem.Particle p in exitParticles)
        {
            GameObject spawnObject = Instantiate(ObjectPrefub);
            spawnObject.transform.position = p.position;
        }
    }
}
