using System;
using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
    public class RedColour : ImageEffectBase
    {
        public PlayerMovement a;

        private float k = 0F;
        void OnRenderImage(RenderTexture source, RenderTexture destination)
        {
            k = a.IsPlayerDamaged();
            material.SetFloat("_Koef", k);
            Graphics.Blit(source, destination, material);
        }
    }
}
