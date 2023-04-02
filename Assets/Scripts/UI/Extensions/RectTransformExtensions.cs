﻿using UnityEngine;

namespace TheChest.UI.Extensions
{
    public static class RectTransformExtensions
    {
        public static Vector3 AdjacentPosition(this RectTransform rectTransform, RectTransform positionedTransform)
        {
            return rectTransform.AdjacentPosition(positionedTransform,Vector3.zero);
        }
        public static Vector3 AdjacentPosition(this RectTransform rectTransform, RectTransform positionedTransform, Vector3 spacing)
        {
            if (Camera.current != null)//TODO: remove Camera.Current
            {
                Vector3 vertical   = Vector3.down * (rectTransform.rect.height / 2);
                Vector3 horizontal;

                if (rectTransform.transform.position.x > Camera.current.pixelWidth / 2)
                {
                    horizontal = Vector3.left * (positionedTransform.rect.width + (rectTransform.rect.width / 2));
                }
                else
                {
                    horizontal = Vector3.right * (rectTransform.rect.width / 2);
                }
                
                return rectTransform.localPosition + horizontal + vertical + spacing;
            }

            return rectTransform.localPosition;
        } 
    }
}