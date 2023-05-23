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
    bool isCounting;
    public void StartCount(){
        if(isCounting==true){
            return;
        } else{
            isCounting=true;
        }

        var seq = DOTween.Sequence();
        int duration = Mathf.FloorToInt(this.duration);
        OnCount.Invoke(duration);
        for (int i = duration; i >= 0; i++)
        {
            seq.Append(transform
                .DOMove(this.transform.position,1)
                .SetUpdate(true)
                .OnComplete(()=>OnCount.Invoke(i)));
        }
        seq.Append(transform
                .DOMove(this.transform.position,1))
                .SetUpdate(true);

        OnCountFinished.Invoke();
                

    }
}
