using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakePhone : MonoBehaviour
{
    public Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void shakestart()
    {
        StopAllCoroutines();
        StartCoroutine(Shake());
    }

    public IEnumerator Shake()
    {
       
        _animator.SetBool("Shake", true);
        yield return new WaitForSeconds(2.5f);
        _animator.SetBool("Shake", false);

    }

  
}
