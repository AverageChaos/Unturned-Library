using SDG.Unturned;
using System;

namespace ChaosLib.Extensions
{
    public static class BarricadeExt
    {
        /// <summary>
        /// Creates a new <see cref="Barricade"/> from the provided <see cref="Guid"/>.
        /// </summary>
        /// <param name="guid"></param>
        /// <returns>a new <see cref="Barricade"/>.</returns>
        /// <exception cref="Exception"></exception>
        public static Barricade CreateBarricade(Guid guid)
        {
            Asset asset = Assets.find(guid) ?? throw new Exception($"Asset of guid: {guid}, does not exist.");
            if (!(asset is ItemBarricadeAsset barricadeAsset))
                throw new Exception($"Asset of guid: {guid}, is not an ItemBarricadeAsset.");

            return new Barricade(barricadeAsset);
        }
    }
}