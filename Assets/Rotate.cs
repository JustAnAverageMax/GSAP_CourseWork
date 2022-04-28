using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Transform spherePos;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = spherePos.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        StartCoroutine(RotateTo(targetRotation, 1.0f));

    }

    private IEnumerator RotateTo(Quaternion targetRotation, float time)
    {
        float elapsedTime = 0.0f;
        Quaternion startingRotation = transform.rotation; // have a startingRotation as well
        while (elapsedTime < time)
        {
            elapsedTime += Time.deltaTime; // <- move elapsedTime increment here

            transform.rotation = Quaternion.Slerp(startingRotation, targetRotation, (elapsedTime / time));
            yield return new WaitForEndOfFrame();
        }
    }
}
