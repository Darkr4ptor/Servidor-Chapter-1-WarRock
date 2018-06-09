using System;
using System.Collections;

namespace Game.Packets {
    class UpdateInventory : Core.Networking.OutPacket {
        public UpdateInventory(Entities.User u)
            : base((ushort)Enums.Packets.UpdateInventory) {
                Append2(Core.Constants.Error_OK);
                Append2(u.Inventory.SlotState); // The slots that are enabled
                // EQUIPMENT //
                Append2(u.Inventory.Equipment.ListsInternal[0]);
                Append2(u.Inventory.Equipment.ListsInternal[1]);
                Append2(u.Inventory.Equipment.ListsInternal[2]);
                Append2(u.Inventory.Equipment.ListsInternal[3]);
                Append2(u.Inventory.Equipment.ListsInternal[4]);
                // INVENTORY //
                Append2(u.Inventory.Itemlist);
                // Expired Items //
                Append2(u.Inventory.ExpiredItems.Count);
                foreach (string itemCode in u.Inventory.ExpiredItems) {
                    Append2(itemCode.ToUpper());
                }
        }

    }
}
