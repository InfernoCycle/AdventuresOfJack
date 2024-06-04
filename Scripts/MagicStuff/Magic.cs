using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour
{
    [SerializeField] private float startingMagic;
    public float currentMagic { get; private set; }


    // Start is called before the first frame update
    void Awake()
    {
        currentMagic = startingMagic;
    }

    public void LoseMana(float Amount)
    {
        currentMagic = Mathf.Clamp(currentMagic - Amount, 0, startingMagic); 
    }
    public void AddMana(float _value)
    {
        currentMagic = Mathf.Clamp(currentMagic + _value, 0, startingMagic);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
