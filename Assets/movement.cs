using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{

    Animator animator;
    [SerializeField] GameObject[] skillParticles;
    private IEnumerator coroutine;
    [SerializeField] AudioClip[] skillsAudioClips;
    [SerializeField] AudioSource audioSource;

    void Start()
    {
        animator = GetComponent<Animator>();
        for (int i = 0; i < skillParticles.Length; i++)
        {
            skillParticles[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("vertical", Input.GetAxis("Vertical"));
        animator.SetFloat("horizontal", Input.GetAxis("Horizontal"));
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Jump();
        }
        animator.SetBool("isrunning", true);
        if (Input.GetKey(KeyCode.LeftShift))
        {
            run();
        }
        if (Input.GetKeyUp(KeyCode.Alpha1)) UseSkill(1);
        if (Input.GetKeyUp(KeyCode.Alpha2)) UseSkill(2);

    }

    public void UseSkill(int skillNumber)
    {
        animator.SetTrigger("Skill" + skillNumber);
        skillParticles[skillNumber - 1].SetActive(true);
        // audioSource.clip = skillsAudioClips[skillNumber - 1];
        // audioSource.Play();
        switch (skillNumber)
        {
            case 1:
                coroutine = WaitToEnableObject(skillParticles[skillNumber - 1], 1);
                break;
            case 2:
                coroutine = WaitToEnableObject(skillParticles[skillNumber - 1], 1);
                break;
        }


        StartCoroutine(coroutine);
    }

    IEnumerator WaitToEnableObject(GameObject obj, float time)
    {
        yield return new WaitForSeconds(time);
        obj.SetActive(false);
    }

    public void Jump()
    {
        animator.SetTrigger("jump");
    }
    public void run()
    {
        animator.SetBool("run", false);
    }
}
