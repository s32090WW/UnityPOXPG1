using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public string mainWord = "default"; // to zgadujemy
    public int livesCount = 10;
    public TextMeshProUGUI mainWordText;
    public TextMeshProUGUI livesCountText;
    public TextMeshProUGUI messageText;
    public TMP_InputField inputField; // input
    public Button submitButton;
    private string guess;

    void Start()
    {
        mainWordText.text = new string('_', mainWord.Length);
        submitButton.onClick.AddListener(OnSubmit);
        livesCountText.text = $"Zostało {livesCount} prób"; 
    }
    public void OnClick() {

        Debug.Log($"submited");
        livesCount--;
        livesCountText.text = $"Zostało {livesCount} prób";


    }


    
        void OnSubmit()
    {
        guess = inputField.text.ToLower().Trim();
        inputField.text = "";

        if (guess == mainWord.ToLower())
        {
            mainWordText.text = mainWord.ToUpper();
            //tu ma byc info ze sie zgadlo i fajnie
            messageText.text = $"Dobrze";
            return; // koniec 
        }
        if (mainWord.Length != guess.Length)
        {
            messageText.text = $"Zła liczba liter";
            return; // koniec 
        }
  



        int bullsCount = CountBulls();
        int cowsCount = CountCows();
        messageText.text = $"Bulls: {bullsCount} and Cows: {cowsCount}";

    }
    public int CountBulls()
    {
        int result = 0;

        for (int i = 0; i < mainWord.Length; i++)
        {
            if (mainWord[i] == guess[i])
            {
                result++;
            }
        
        }
        return result;
    }
    public int CountCows()
    {
        int result = 0;

        for (int i = 0; i < mainWord.Length; i++)
        {
            if (mainWord[i] == guess[i] && mainWord.Contains(guess[i]) )
            {
                result++;
            }

        }
        return result;
    }
    void Update()
    {
       
    }
}