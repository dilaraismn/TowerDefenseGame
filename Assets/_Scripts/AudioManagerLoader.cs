using UnityEngine;

public class AudioManagerLoader : MonoBehaviour
{
    public AudioManager _audioManager;

    private void Awake()
    {
        if (FindObjectOfType<AudioManager>() == null)
        {
            AudioManager.instance = Instantiate(_audioManager);
            DontDestroyOnLoad(AudioManager.instance.gameObject);
        }
    }
}
