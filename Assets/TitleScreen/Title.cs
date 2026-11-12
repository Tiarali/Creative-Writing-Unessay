using System.Collections;
using UnityEngine;

public class Title : MonoBehaviour
{
    [SerializeField] ParticleSystem titleParticle;
    [SerializeField] SoundFXManager soundFx;
    [SerializeField] float fadeDelay = 1.0f;
    [SerializeField] float fadeDuration = 1.0f;
    [SerializeField] SpriteRenderer roseRenderer;
    [SerializeField] SpriteRenderer titleRenderer;
    [SerializeField] LevelManager levelManager;
    Animator animator;

    void Awake()
    {
        titleParticle.Stop();
    }

    void Start()
    {
        animator = GetComponent<Animator>();
       
    }

    public void PlayParticle()
    {
        if (titleParticle != null)
        {
            if (!titleParticle.isPlaying)
            {
                Invoke("PlaySting", 0.1f);
                titleParticle.Play();
            }
        }
    }

    public void PlayWhack()
    {
        soundFx.PlayTitleWhackClip();
    }

    void PlaySting()
    {
        soundFx.PlayTitleStingClip();
        Invoke("FadeTitle", fadeDelay);
    }

    public void startAnimation()
    {
        animator.SetTrigger("isChanging");
    }

    private void FadeTitle()
    {
        StartCoroutine(FadeRoutine(roseRenderer));
        StartCoroutine(FadeRoutine(titleRenderer));
    }

    private IEnumerator FadeRoutine(SpriteRenderer renderer)
    {
        Color startColor = renderer.color;
        float startAlpha = startColor.a;
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startAlpha, 0f, elapsed / fadeDuration);
            renderer.color = new Color(startColor.r, startColor.g, startColor.b, newAlpha);
            yield return null;
        }

        // Ensure it hits the exact target value at the end
        renderer.color = new Color(startColor.r, startColor.g, startColor.b, 0f);
        levelManager.LoadNextLevel();
    }
}
