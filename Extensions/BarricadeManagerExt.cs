using SDG.Unturned;
using System;
using UnityEngine;

namespace ChaosLib.Extensions
{
    public static class BarricadeManagerExt
    {
        /// <summary>
        /// Looks for a <see cref="Barricade"/> at the provided <see cref="Transform"/>. Calls <see cref="Func{T, TResult}">Func{in <see cref="BarricadeDrop">BarricadeDrop drop</see>, out <see cref="bool">bool allowDestroy = true</see>}</see> before the barricade is destroyed.
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="onBeforeDeleted"></param>
        public static void DestroyBarricade(Transform transform, Func<BarricadeDrop, bool> onBeforeDeleted = null)
        {
            BarricadeDrop drop = BarricadeManager.FindBarricadeByRootTransform(transform);
            if (drop == null)
                return;

            if (!Regions.tryGetCoordinate(transform.position, out byte x, out byte y))
                return;

            if (onBeforeDeleted?.Invoke(drop) ?? true)
                BarricadeManager.destroyBarricade(drop, x, y, 65535);
        }
    }
}