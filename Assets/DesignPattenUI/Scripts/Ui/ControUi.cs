using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControUi : MonoBehaviour
{
   public virtual void Show(bool value)
    {
        gameObject.SetActive(value);
    }    
}
