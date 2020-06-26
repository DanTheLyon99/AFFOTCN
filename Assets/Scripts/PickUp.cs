using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    
   
    private AudioSource audio;
    [SerializeField] private AudioClip pickUpSound;
    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider2D;
    
    [SerializeField] private float time = 3f;
    [SerializeField] private float timerBeforeEffect = 5f;
    
    public Action<GameObject> OnPillEffectStart;
    public Action<GameObject> OnPillEffectEnd;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider2D = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            MakeInvisible();
            AudioSource.PlayClipAtPoint(pickUpSound,Camera.main.transform.position);
            StartCoroutine(WaitBeforePillEffect(other.gameObject));
        }
    }

    private IEnumerator WaitBeforePillEffect(GameObject player)
    {
        yield return new WaitForSeconds(timerBeforeEffect);
        StartCoroutine(PillEffectFor(player));
    }
    
    private IEnumerator PillEffectFor(GameObject player)
    {
        OnPillEffectStart?.Invoke(player);
        yield return new WaitForSeconds(time);
        OnPillEffectEnd?.Invoke(player);
        Destroy(gameObject);
        
    }

    private void MakeInvisible()
    {
        _spriteRenderer.sprite = null;
        _collider2D.enabled = false;
    }
    
}
