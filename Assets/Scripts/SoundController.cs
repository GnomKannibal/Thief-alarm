using System.Collections;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private Coroutine _coroutine;
    private bool _isInside = false;

    private void Awake()
    {
        _audioSource.volume = 0f;

        _audioSource.Play();
    }

    public IEnumerator ChangingVolume() 
    {
        float delay = 1f;
        bool IsRun = false;
        var wait = new WaitForSeconds(delay);

        while (IsRun == false) 
        {
            if (_isInside == false)
                _audioSource.volume -= 0.1f;
            else
                _audioSource.volume += 0.1f;

            yield return wait;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _isInside = !_isInside;

        _coroutine = StartCoroutine(ChangingVolume());
    }
}
