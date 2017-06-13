using UnityEngine;
 using UnityEngine.UI;
 using System.Collections;
 using UnityEngine.Events;
 
 public class movieplay : MonoBehaviour{
     
    MovieTexture mt;
    RectTransform rt;
    public bool loop;
    void Awake(){
        rt = GetComponent<RectTransform>();
         
         
        RawImage rim = GetComponent<RawImage>();
        mt = (MovieTexture)rim.mainTexture;
        mt.Play();
        mt.loop = true;
        
    }
             
}