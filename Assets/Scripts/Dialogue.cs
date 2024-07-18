using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[Serializable]
public class CharacterInfo {
    public string name;
    public TMP_FontAsset font;
}

public class Dialogue : MonoBehaviour
{
    public TextAsset script;
    public float timeBetweenCharacters;
    public float timeBetweenLines;
    public CharacterInfo[] characters;
    
    private TMP_Text textComp;

    // Start is called before the first frame update
    void Start()
    {
        textComp = GetComponent<TMP_Text>();
        
        // write dialogue
        string[] lines = script.text.Split('\n');
        StartCoroutine(Write(lines));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Write(string[] lines) {
        foreach (string line in lines)
        {
            yield return StartCoroutine(WriteLine(line));
            yield return new WaitForSeconds(timeBetweenLines);
        }
    }

    IEnumerator WriteLine(string line) {
        // separate character from text
        string characterName = line.Split('|')[0];
        line = line.Split('|')[1];

        // change font
        foreach (CharacterInfo characterInfo in characters)
        {
            if (characterInfo.name.Equals(characterName)) {
                textComp.font = characterInfo.font;
                break;
            }
        }
        
        // write text
        string textBuffer = "";
        foreach (char c in line)
        {
            textBuffer += c;
            textComp.text = textBuffer;
            yield return new WaitForSeconds(timeBetweenCharacters);
        }
    }
}
