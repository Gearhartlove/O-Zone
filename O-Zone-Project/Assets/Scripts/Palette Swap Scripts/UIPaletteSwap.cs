using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPaletteSwap : MonoBehaviour
{
    Texture2D mColorSwapTex;
    Color[] mSpriteColors;

    Image mSpriteRenderer;

    [SerializeField]
    private Texture2D SwapPalette;

    private void Awake()
    {
        mSpriteRenderer = GetComponent<Image>();
        InitColorSwapTex();
    }
    // Start is called before the first frame update
    void Start()
    {
        if (SwapPalette)
        {
            Color[] paletteColors = ColorFromPalette(SwapPalette);
            SwapColor(SwapIndex.Color1, paletteColors[1]);
            SwapColor(SwapIndex.Color2, paletteColors[2]);
            SwapColor(SwapIndex.Color3, paletteColors[3]);
            SwapColor(SwapIndex.Color4, paletteColors[4]);
            SwapColor(SwapIndex.Color5, paletteColors[5]);
            SwapColor(SwapIndex.Color6, paletteColors[6]);
        } else
        {
            SwapColor(SwapIndex.Color1, ColorFromIntRGB(251, 255, 134));
            SwapColor(SwapIndex.Color2, ColorFromIntRGB(213, 224, 75));
            SwapColor(SwapIndex.Color3, ColorFromIntRGB(162, 169, 71));
            SwapColor(SwapIndex.Color4, ColorFromIntRGB(103, 102, 51));
            SwapColor(SwapIndex.Color5, ColorFromIntRGB(69, 41, 63));
            SwapColor(SwapIndex.Color6, ColorFromIntRGB(69, 41, 63));
        }
        mColorSwapTex.Apply();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static Color[] ColorFromPalette(Texture2D palette)
    {
        Color[] paletteColors = palette.GetPixels(0, 0, palette.width, palette.height);
        return paletteColors;
    }

    public static Color ColorFromInt(int c, float alpha = 1.0f)
    {
        int r = (c >> 16) & 0x000000FF;
        int g = (c >> 8) & 0x000000FF;
        int b = c & 0x000000FF;

        Color ret = ColorFromIntRGB(r, g, b);
        ret.a = alpha;

        return ret;
    }

    public static Color ColorFromIntRGB(int r, int g, int b)
    {
        return new Color((float)r / 255.0f, (float)g / 255.0f, (float)b / 255.0f, 1.0f);
    }

    public void InitColorSwapTex()
    {
        Texture2D colorSwapTex = new Texture2D(256, 1, TextureFormat.RGBA32, false, false);
        colorSwapTex.filterMode = FilterMode.Point;

        for (int i = 0; i < colorSwapTex.width; ++i)
            colorSwapTex.SetPixel(i, 0, new Color(0.0f, 0.0f, 0.0f, 0.0f));

        colorSwapTex.Apply();
        Material mat = Instantiate(mSpriteRenderer.material);
        mat.SetTexture("_SwapTex", colorSwapTex);
        mSpriteRenderer.material = mat;

        mSpriteColors = new Color[colorSwapTex.width];
        mColorSwapTex = colorSwapTex;
    }

    public void SwapColor(SwapIndex index, Color color)
    {
        mSpriteColors[(int)index] = color;
        mColorSwapTex.SetPixel((int)index, 0, color);
    }


    public void SwapColors(List<SwapIndex> indexes, List<Color> colors)
    {
        for (int i = 0; i < indexes.Count; ++i)
        {
            mSpriteColors[(int)indexes[i]] = colors[i];
            mColorSwapTex.SetPixel((int)indexes[i], 0, colors[i]);
        }
        mColorSwapTex.Apply();
    }

    public void ClearColor(SwapIndex index)
    {
        Color c = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        mSpriteColors[(int)index] = c;
        mColorSwapTex.SetPixel((int)index, 0, c);
    }

    public void SwapAllSpritesColorsTemporarily(Color color)
    {
        for (int i = 0; i < mColorSwapTex.width; ++i)
            mColorSwapTex.SetPixel(i, 0, color);
        mColorSwapTex.Apply();
    }

    public void ResetAllSpritesColors()
    {
        for (int i = 0; i < mColorSwapTex.width; ++i)
            mColorSwapTex.SetPixel(i, 0, mSpriteColors[i]);
        mColorSwapTex.Apply();
    }

    public void ClearAllSpritesColors()
    {
        for (int i = 0; i < mColorSwapTex.width; ++i)
        {
            mColorSwapTex.SetPixel(i, 0, new Color(0.0f, 0.0f, 0.0f, 0.0f));
            mSpriteColors[i] = new Color(0.0f, 0.0f, 0.0f, 0.0f);
        }
        mColorSwapTex.Apply();
    }

    public void SetSwapPalette(Texture2D newPalette)
    {
        SwapPalette = newPalette;
    }
}
