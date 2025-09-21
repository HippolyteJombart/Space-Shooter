using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [SerializeField] private AudioSource[] audioSources;
    private void Awake()
    {
        if (instance == null) { instance = this; }
        else { Destroy(gameObject); }
    }
    public void ShootAudio()
    {
        audioSources[1].Play();
    }
    public void AsteroidsExplosionAudio()
    {
        audioSources[2].Play();
    }
    public void PlayerExplosionAudio()
    {
        audioSources[3].Play();
    }
}