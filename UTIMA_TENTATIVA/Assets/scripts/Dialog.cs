using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour {

    public Text textDisplay;
    public string[] sentences;
    private int index;
    public float typeSpeed;

    public GameObject objective;
    public GameObject image;
    public GameObject continueButtom;

    private void Start()
    {
        
            StartCoroutine(Type());
            
            Time.timeScale = 0.3f;

    }

    private void Update()
    {
        if (textDisplay.text == sentences[index])
        {
            continueButtom.SetActive(true);
            
        }
       
    }

   
    IEnumerator Type() {
        
        foreach (char letter in sentences[index].ToCharArray()) {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typeSpeed);

        }

    }
    public void NextSentence() {
        continueButtom.SetActive(false);
        image.SetActive(true);

        if (index < sentences.Length - 1)
        {
            
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
            Time.timeScale = 0.3f;

        }
        
        else
        {
            textDisplay.text = "";
            continueButtom.SetActive(false);
            image.SetActive(false);
            Instantiate(objective, transform.position, Quaternion.identity);
            Time.timeScale = 1f;
          
         
        }
        

    }
   
}
