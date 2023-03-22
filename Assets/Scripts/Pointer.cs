using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour {

    public Transform target;

    public enum Tracking{
        Immediate,
        Delayed,
        ImmediateHorizontal,
        DelayedHorizontal,
    };

    public Tracking tracking;
    public float speed = 1;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {

        switch (tracking){
            case Tracking.Immediate:
                MathsUtils.FollowImmediate(transform, target.position);
                break;

            case Tracking.Delayed:
                MathsUtils.FollowDelayed(transform, target.position, speed);
                break;

            case Tracking.ImmediateHorizontal:
                MathsUtils.FollowImmediateHorizontal(transform, target.position);
                break;

            case Tracking.DelayedHorizontal:
                MathsUtils.FollowDelayedHorizontal(transform, target.position, speed);
                break;
        }
	}
}
