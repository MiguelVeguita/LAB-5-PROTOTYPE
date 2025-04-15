using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Uimanager : MonoBehaviour
{
    public TMP_Text puntaje;
    private int puntos;
    private void OnEnable()
    {
        Player.matar += updatePuntaje;
    }

    private void OnDisable()
    {
        Player.matar -= updatePuntaje;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updatePuntaje()
    {
        puntos = puntos + 10;
        puntaje.text=puntos.ToString();
    }
}
