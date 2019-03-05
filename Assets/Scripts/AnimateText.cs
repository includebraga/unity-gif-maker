using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class AnimateText : MonoBehaviour
{
    public Controller controller;

    public string string1;
    public string string2;
    public string string3;

    public Text animatedText;

    private string _newString;
    private string _randomString;

    private IEnumerator Start()
    {
        _randomString = RandomString(string2);
        _newString = string1;

        animatedText.text = _newString;

        yield return AnimateTextt();
    }

    private IEnumerator AnimateTextt()
    {
        /*while (!IsStringTransitionComplete(_newString, string1))
        {
            _newString = TransformText(_newString, string1);

            animatedText.text = _newString;

            yield return null;
        }*/

        yield return new WaitForSeconds(3);

        while (!IsStringTransitionComplete(_newString, string2))
        {
            _newString = TransformText(_newString, string2);

            animatedText.text = _newString;

            yield return null;
        }

        yield return new WaitForSeconds(3);

        while (!IsStringTransitionComplete(_newString, string3))
        {
            _newString = TransformText(_newString, string3);

            animatedText.text = _newString;

            yield return null;
        }

        yield return new WaitForSeconds(3);

        while (!IsStringTransitionComplete(_newString, string1))
        {
            _newString = TransformText(_newString, string1);

            animatedText.text = _newString;

            yield return null;
        }

        controller.recorder.Save();
    }

    private string TransformText(string fromString, string toString)
    {

        if (fromString.Length < toString.Length)
        {
            for (int i = fromString.Length - 1; i < toString.Length; i++)
            {
                fromString += " ";
            }
        }

        char[] newString = fromString.ToCharArray();

        int randomChar;

        do
        {
            randomChar = Random.Range(0, fromString.Length);

        } while (randomChar < toString.Length - 1 && newString[randomChar] == toString.ToCharArray()[randomChar]);

        if (randomChar > toString.Length - 1)
        {
            newString[randomChar] = ' ';
        }
        else
        {
            newString[randomChar] = toString.ToCharArray()[randomChar];
        }

        return new string(newString);
    }

    private string RandomString(string stringToGlitch)
    {
        string newString = String.Empty;

        for (int j = 0; j < stringToGlitch.Length; j++)
        {
            var c = (char)(Random.Range(33, 122));
            newString = newString.Insert(j, c.ToString());
        }

        return newString;
    }

    private bool IsStringTransitionComplete(string newString, string finalString)
    {
        string cleanString = string.Empty;

        for (int i = newString.Length - 1; i >= 0; i--)
        {
            if (newString[i] != ' ')
            {
                cleanString = newString.Substring(0, i + 1);
                break;
            }
        }

        return cleanString == finalString;
    }
}
