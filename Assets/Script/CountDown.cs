using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class CountDown : MonoBehaviour
{
    [SerializeField] int duration;

    public UnityEvent OnCountFinished = new UnityEvent();
    public UnityEvent<int> OnCount = new UnityEvent<int>();
    public bool isCounting;
    Coroutine countCoroutine;


    public void StartCount(){ 

        if (isCounting==true)
        {
        // //Cara memberhentikan coroutine 
            StopCoroutine(countCoroutine);
        }
        countCoroutine = StartCoroutine(CountCoroutine());

    }

    private IEnumerator CountCoroutine()
    {
        isCounting=true;
        for (int i = 0; i < duration; i++)
        {
            OnCount.Invoke(i);
            yield return new WaitForSecondsRealtime(1);
        }
        isCounting = false;
        OnCountFinished.Invoke();
    }

    // //CountDown with DoTween
    // public void StartCount(){
    //     if(isCounting==true){
    //         return;
    //     } else{
    //         isCounting=true;
    //     }
    //     DOTween.Kill(this.transform);

    //     var seq = DOTween.Sequence();
    //     int duration = Mathf.FloorToInt(this.duration);
    //     OnCount.Invoke(duration);
    //     for (int i = duration; i >= 0; i++)
    //     {
    //         var coount = i;
    //         seq.Append(transform
    //             .DOMove(this.transform.position,1)
    //             .SetUpdate(true)
    //             .OnComplete(()=>OnCount.Invoke(coount)));
    //     }
    //     seq.Append(transform
    //             .DOMove(this.transform.position,1))
    //             .SetUpdate(true)
    //             .OnComplete(()=>{
    //                 isCounting=false;
    //                 OnCountFinished.Invoke();
    //                 }
    //             );
    // }
}
