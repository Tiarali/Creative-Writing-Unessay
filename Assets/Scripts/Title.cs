using UnityEngine;

public class Title : MonoBehaviour
{
    [SerializeField] ParticleSystem titleParticle;
    [SerializeField] SoundFXManager soundFx;
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
    }

    public void startAnimation()
    {
        animator.SetTrigger("isChanging");
    }
}
