using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour
{
    public int SecondsToWait;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Disable());
    }

    // Update is called once per frame
    IEnumerator Disable()
    {
        yield return new WaitForSeconds(SecondsToWait);
        
        Close();
    }

    public void Enable()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }
}
