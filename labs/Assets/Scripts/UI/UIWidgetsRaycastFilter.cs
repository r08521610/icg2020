using Unity.UIWidgets.engine;
using UnityEngine;
using UnityEngine.UI;

[DisallowMultipleComponent]
[RequireComponent(typeof(UIWidgetsPanel))]
public class UIWidgetsRaycastFilter : MonoBehaviour, ICanvasRaycastFilter
{
    public bool reversed;

    private UIWidgetsPanel rawImage;

    void OnEnable()
    {
        rawImage = GetComponent<UIWidgetsPanel>();
    }


    public static Texture2D toTexture2D(RenderTexture rTex)
    {
        Texture2D tex = new Texture2D(rTex.width, rTex.height, TextureFormat.RGBA32, false);
        RenderTexture.active = rTex;
        tex.ReadPixels(new Rect(0, 0, rTex.width, rTex.height), 0, 0);
        tex.Apply();
        return tex;
    }

    public bool IsRaycastLocationValid(Vector2 screenPoint, Camera eventCamera)
    {
        if (!enabled)
            return true;

        Texture2D texture = null;
        var w = rawImage.texture;
        texture = toTexture2D(w as RenderTexture);
        if (texture == null)
            return true;

        Vector2 local;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rawImage.rectTransform, screenPoint, eventCamera, out local);

        Rect rect = rawImage.rectTransform.rect;

        // Convert to have lower left corner as reference point.
        local.x += rawImage.rectTransform.pivot.x * rect.width;
        local.y += rawImage.rectTransform.pivot.y * rect.height;

        Rect uvRect = rawImage.uvRect;
        float u = local.x / rect.width * uvRect.width + uvRect.x;
        float v = local.y / rect.height * uvRect.height + uvRect.y;

        // Debug.Log("alpha = " + texture.GetPixelBilinear(u, v).a);

        try
        {
            if (!reversed)
                return texture.GetPixelBilinear(u, v).a != 0;
            else
                return texture.GetPixelBilinear(u, v).a == 0;
        }
        catch (UnityException e)
        {
            Debug.LogException(e);
        }

        return true;
    }
}