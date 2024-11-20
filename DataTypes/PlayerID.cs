using SDG.Unturned;
using Steamworks;

namespace ChaosLib.DataTypes
{
    public struct PlayerID
    {
        public ulong SteamID;
        public byte CharacterID;

        public PlayerID(ulong steamID, byte characterID)
        {
            SteamID = steamID;
            CharacterID = characterID;
        }

        public static implicit operator CSteamID(PlayerID rValue) => new CSteamID(rValue.SteamID);
        public static implicit operator ulong(PlayerID rValue) => rValue.SteamID;
        public static implicit operator byte(PlayerID rValue) => rValue.CharacterID;
        public static implicit operator PlayerID(SteamPlayerID rValue) => new PlayerID(rValue.steamID.m_SteamID, rValue.characterID);
    }
}