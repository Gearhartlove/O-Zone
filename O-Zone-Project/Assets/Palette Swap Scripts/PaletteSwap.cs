using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PaletteSwap
{
    public static void SwapPalette(Texture2D sprite, Texture2D originalPalette, Texture2D swapPalette)
    {
        Color[] spriteColors = sprite.GetPixels(0, 0, sprite.width, sprite.height);
        Color[] originalColors = originalPalette.GetPixels(0, 0, originalPalette.width, originalPalette.height);
        Color[] swapColors = swapPalette.GetPixels(0, 0, swapPalette.width, swapPalette.height);

        for (int i = 0; i < spriteColors.Length; i++)
        {
            for (int j = 0; j < originalColors.Length; j++)
            {
                if (spriteColors[i].Equals(originalColors[j]))
                {
                    spriteColors[i] = swapColors[j];
                }
            }
        }
        sprite.SetPixels(0,0, sprite.width, sprite.height, spriteColors);
        sprite.Apply();
    }

    public static Texture2D SwapPaletteNewFile(Texture2D originalSprite, Texture2D originalPalette, Texture2D swapPalette)
    {
        Texture2D swappedSprite = new Texture2D(originalSprite.width, originalSprite.height);
        swappedSprite.SetPixels(originalSprite.GetPixels());
        swappedSprite.Apply();
        SwapPalette(swappedSprite, originalPalette, swapPalette);
        return swappedSprite;
    }
}
