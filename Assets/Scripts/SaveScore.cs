using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SaveScore : MonoBehaviour
{
    public static SaveScore instance;

    public string nameBest;
    public string nome;
    public int pontuacao=0;
    public int pontos=0;
     
    // Start is called before the first frame update
    private void Awake()
    {
         
        
        // start of new code
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code

        instance = this;
        DontDestroyOnLoad(gameObject);
        Load();
    }
    void Start()
    {
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
         
      
         
        
    }

    [System.Serializable]
    class SaveData
    {
        public string nome;
        public int pontuacao;

    }
    public void Save()
    {
        SaveData data = new SaveData();
        if (pontuacao<pontos)
        {
            pontuacao = pontos;
            nome = nameBest;
            

        }
        
        data.nome = nome;
        data.pontuacao = pontuacao;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile7.json", json);
        

    }
    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile7.json";
        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            nome = data.nome;
            pontuacao = data.pontuacao;
            
        }

    }
    public void StartGame()
    {
        
            SceneManager.LoadScene(1);

        


    }
    public void InputText(string t)
    {
        nameBest ="Best: "+ t+": ";

    }
   
}
