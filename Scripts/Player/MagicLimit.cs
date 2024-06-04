using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicLimit : MonoBehaviour
{
    [SerializeField] private Magic playerMana;
    [SerializeField] private Image totalmagicBar;
    [SerializeField] private Image currentmagicBar;

    // Start is called before the first frame update
    void Start()
    {
        totalmagicBar.fillAmount = playerMana.currentMagic / 10;
    }

    // Update is called once per frame
    void Update()
    {
        currentmagicBar.fillAmount = playerMana.currentMagic / 10;
    }
}
