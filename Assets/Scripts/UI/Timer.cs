using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject _timeTo3;
    [SerializeField] private GameObject _timeTo2;
    [SerializeField] private GameObject _timeTo1;
    [SerializeField] private GameObject _timeToRun;

    public void StartToTimer()
    {
        StartCoroutine(CountSequence());
    }

    private IEnumerator CountSequence()
    {
        _timeTo3.SetActive(true);
        yield return new WaitForSeconds(1f);
        _timeTo2.SetActive(true);
        yield return new WaitForSeconds(1f);
        _timeTo1.SetActive(true);
        yield return new WaitForSeconds(1f);
        _timeTo1.SetActive(false);
        _timeTo2.SetActive(false);
        _timeTo3.SetActive(false);
        _timeToRun.SetActive(true);
        yield return new WaitForSeconds(1f);
        _timeToRun.SetActive(false);
    }
}
