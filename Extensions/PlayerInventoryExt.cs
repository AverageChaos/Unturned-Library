using SDG.Unturned;

namespace ChaosLib.Extensions
{
    public static class PlayerInventoryExt
    {
        /// <summary>
        /// All <see cref="PlayerInventory.PAGES"/> assigned names and their corresponding numeric value.
        /// </summary>
        public enum EInventoryPage
        {
            // Stored in the player save
            PRIMARYWEAPON = 0,
            SECONDARYWEAPON = 1,
            SLOTS = 2,
            BACKPACK = 3,
            VEST = 4,
            SHIRT = 5,
            PANTS = 6,

            // Not stored in the player save
            STORAGE = 7,
            AREA = 8
        }
    }
}