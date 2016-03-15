using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiNET;
using MiNET.BlockEntities;
using MiNET.Blocks;
using MiNET.Effects;
using MiNET.Entities;
using MiNET.Entities.ImageProviders;
using MiNET.Items;
using MiNET.Net;
using MiNET.Particles;
using MiNET.Plugins;
using MiNET.Plugins.Attributes;
using MiNET.Utils;
using MiNET.Worlds;
using MiNET.Security;

namespace KitsPlugin
{
    [Plugin]
    public class Kits : Plugin
    {

        //Global Vars/Arrays

        List<string> PlayersKitActivated = new List<string>();





        [Command]
        public void test(Player player)
        {
            player.SendMessage(string.Format(ChatColors.Yellow + "Hi " + player.Username + " this is test command :-)"), type: MessageType.Raw);
            var inventory = player.Inventory;
            inventory.Boots = new ItemLeatherBoots();
            inventory.Leggings = new ItemLeatherLeggings();
            inventory.Chest = new ItemLeatherChestplate();
            inventory.Helmet = new ItemLeatherHelmet();
            player.SendPlayerInventory();
            SendArmorForPlayer(player);
        }


        [PacketHandler]
        public Package McpeLogin(McpeLogin packet, Player player)
        {
            PlayersKitActivated.Remove(player.Username);

            player.SendMessage(string.Format(ChatColors.Yellow + "Welcome " + player.Username), type: MessageType.Chat);

            player.AddPopup(new Popup()
            {
                Message = $"{ChatColors.Gold}Fury Is Godly At C# ~ USER: " + player.Username,
                Duration = 99999999,
                Priority = 1000
            });

            return packet;
        }

        public void SendArmorForPlayer(Player player)
        {
            var armorEquipment = new McpePlayerArmorEquipment();
            armorEquipment.entityId = player.EntityId;
            armorEquipment.helmet = player.Inventory.Helmet;
            armorEquipment.chestplate = player.Inventory.Chest;
            armorEquipment.leggings = player.Inventory.Leggings;
            armorEquipment.boots = player.Inventory.Boots;
            player.Level.RelayBroadcast(armorEquipment);
        }


        [Command]
        public void Kit(Player player, string kitName)
        {
            var inventory = player.Inventory;
            var InHandItem = inventory.GetItemInHand();

            if (!PlayersKitActivated.Contains(player.Username))
            {
                switch (kitName)
                {
  

                    case "Leather":
                        // Kit leather tier
                        inventory.Boots = new ItemLeatherBoots();
                        inventory.Leggings = new ItemLeatherLeggings();
                        inventory.Chest = new ItemLeatherChestplate();
                        inventory.Helmet = new ItemLeatherHelmet();
                        InHandItem = new ItemWoodenSword();
                        player.SendMessage(string.Format(ChatColors.Blue + "You have selected kit: Leather"), type: MessageType.Raw);
                        SendArmorForPlayer(player);
                        player.SendPlayerInventory();
                        //set player kit var to true.
                        PlayersKitActivated.Add(player.Username);
                        break;
                    case "Gold":
                        // Kit gold tier
                        inventory.Boots = new ItemGoldBoots();
                        inventory.Leggings = new ItemGoldLeggings();
                        inventory.Chest = new ItemGoldChestplate();
                        inventory.Helmet = new ItemGoldHelmet();
                        InHandItem = new ItemGoldSword();
                        player.SendMessage(string.Format(ChatColors.Blue + "You have selected kit: Gold"), type: MessageType.Raw);
                        SendArmorForPlayer(player);
                        player.SendPlayerInventory();
                        //set player kit var to true.
                        PlayersKitActivated.Add(player.Username);
                        break;
                    case "Chain":
                        // Kit chain tier
                        inventory.Boots = new ItemChainmailBoots();
                        inventory.Leggings = new ItemChainmailLeggings();
                        inventory.Chest = new ItemChainmailChestplate();
                        inventory.Helmet = new ItemChainmailHelmet();
                        InHandItem = new ItemStoneSword();
                        player.SendMessage(string.Format(ChatColors.Blue + "You have selected kit: Chain"), type: MessageType.Raw);
                        SendArmorForPlayer(player);
                        player.SendPlayerInventory();
                        //set player kit var to true.
                        PlayersKitActivated.Add(player.Username);
                        break;
                    case "Iron":
                        // Kit iron tier
                        inventory.Boots = new ItemIronBoots();
                        inventory.Leggings = new ItemIronLeggings();
                        inventory.Chest = new ItemIronChestplate();
                        inventory.Helmet = new ItemIronHelmet();
                        InHandItem = new ItemIronSword();
                        player.SendMessage(string.Format(ChatColors.Blue + "You have selected kit: Iron"), type: MessageType.Raw);
                        SendArmorForPlayer(player);
                        player.SendPlayerInventory();
                        //set player kit var to true.
                        PlayersKitActivated.Add(player.Username);
                        break;
                    case "Diamond":
                        // Kit diamond tier
                        inventory.Boots = new ItemDiamondBoots();
                        inventory.Leggings = new ItemDiamondLeggings();
                        inventory.Chest = new ItemDiamondChestplate();
                        inventory.Helmet = new ItemDiamondHelmet();
                        InHandItem = new ItemDiamondSword();
                        player.SendMessage(string.Format(ChatColors.Blue + "You have selected kit: Diamond"), type: MessageType.Raw);
                        SendArmorForPlayer(player);
                        player.SendPlayerInventory();
                        //set player kit var to true.
                        PlayersKitActivated.Add(player.Username);
                        break;
                }
            }
            else if (PlayersKitActivated.Contains(player.Username))
            {
                player.SendMessage(string.Format(ChatColors.Blue + "You have already selected a kit, only one kit per life."), type: MessageType.Raw);
            }
        }
    }
}
