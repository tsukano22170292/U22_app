using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBehaviour : MonoBehaviour
{

    public void DestoryMe() {
        //effects are only played once in most games so by default
        this.gameObject.SetActive(false);

        //If you want to destory the effect's game object to save memory
        //GameObject.Destroy(this.gameObject);

        //or comment out if you want to repeat. 
    }


}
