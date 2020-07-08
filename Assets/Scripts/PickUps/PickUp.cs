using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    
   //TODO get most of this out of PickUp and into a script that starts the coroutine on a button press instead
   //TODO make this class the one that equips the item that was picked up (weapon or pill)
    private AudioSource audio;
    [SerializeField] private AudioClip pickUpSound;
    [SerializeField] private GameObject clock;
    private SpriteRenderer _spriteRenderer;
    private Collider2D _collider2D;
    
    [SerializeField] private float time = 3f;
    [SerializeField] private float timerBeforeEffect = 5f;
    private bool _clockIsAnimating;
    public Action<GameObject> onPillEffectStart;
    public Action<GameObject> onPillEffectEnd;
    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _collider2D = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (_clockIsAnimating)
        {
            
            var degreesPerSecond = 360 / timerBeforeEffect;

            clock.transform.GetChild(0).transform.Rotate(new Vector3(0, 0, -degreesPerSecond * Time.deltaTime));
        }
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
        //Start the clock animation
        clock.SetActive(true);
        _clockIsAnimating = true;
        yield return new WaitForSeconds(timerBeforeEffect);
        _clockIsAnimating = false;
        clock.SetActive(false);
        StartCoroutine(PillEffectFor(player));
    }
    
    private IEnumerator PillEffectFor(GameObject player)
    {
        onPillEffectStart?.Invoke(player);
        yield return new WaitForSeconds(time);
        onPillEffectEnd?.Invoke(player);
        Destroy(gameObject);
        
    }

    private void MakeInvisible()
    {
        _spriteRenderer.sprite = null;
        _collider2D.enabled = false;
    }
    
}
