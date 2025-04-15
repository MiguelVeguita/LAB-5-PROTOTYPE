using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    private AudioSource m_AudioSource;
    public AudioClip saltoPersonaje;
    public AudioClip EnemyDead;
    private void OnEnable()
    {
        Player.salto += ActivarSaltoSound;
        Player.matar += ActivarEnemyDeadSound;
    }

    private void OnDisable()
    {
        Player.salto -= ActivarSaltoSound;
        Player.matar -= ActivarEnemyDeadSound;

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ActivarSaltoSound()
    {
        print("sound de salto");

    }
    private void ActivarEnemyDeadSound()
    {
        print("sound de Enemy Dead");

    }
}
