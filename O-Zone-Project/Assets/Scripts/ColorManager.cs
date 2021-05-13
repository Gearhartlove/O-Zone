using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    [SerializeField] private Texture2D Palette1;
    [SerializeField] private Texture2D Palette2;
    [SerializeField] private Texture2D Palette3;
    [SerializeField] private Texture2D Palette4;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SwapPalette(GameObject player, int playerIndex)
    {
        switch (playerIndex)
        {
            case 0:
                player.GetComponent<octoPaletteSwapTest>().SetSwapPalette(Palette1);
                break;
            case 1:
                player.GetComponent<octoPaletteSwapTest>().SetSwapPalette(Palette2);
                break;
            case 2:
                player.GetComponent<octoPaletteSwapTest>().SetSwapPalette(Palette3);
                break;
            case 3:
                player.GetComponent<octoPaletteSwapTest>().SetSwapPalette(Palette4);
                break;
        }
    }
}
