using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MoveRose : MonoBehaviour
{
    [SerializeField] float endXPos;
    [SerializeField] float speed;
    [SerializeField] Title title;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Movement();
        CheckPosition();
        
    }

    private void Movement()
    {
        Vector3 targetPosition = new Vector3(endXPos, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    private void CheckPosition()
    {
        if (transform.position.x == endXPos)
        {
            StartHit();
        }
    }

    private void StartHit()
    {
        animator.SetTrigger("isAttacking");
    }

    public void ChangeTitle()
    {
        title.startAnimation();
    }
}
