
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class DamageParticleText : MonoBehaviour
{
    private TextMeshProUGUI textMeshProUGUI;
   [SerializeField]private float alphaFadeTime = 1f;
    
    private void Awake()
    {
        textMeshProUGUI = GetComponent<TextMeshProUGUI>();
    }


    private void Start()
    {
        StartCoroutine(TextEffect());
    }


    private IEnumerator TextEffect()
    {
        float startAlpha = textMeshProUGUI.color.a;
        float a = startAlpha;

        while (a > 0)
        {
            a -= (startAlpha / alphaFadeTime) * Time.deltaTime;
            textMeshProUGUI.color = new Color(1,1,1,a);
            transform.position += Vector3.up * 0.01f;  
            yield return null; 
        }
        
        Destroy(gameObject);
    }



}
