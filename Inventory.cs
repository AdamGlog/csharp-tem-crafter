namespace FirstFiddle;

using System;

public class Inventory(string owner, string[] inventoryItems)
{
    public string? Owner { get; set; } = owner;
    public string[]? InventoryItems { get; set; } = inventoryItems;
}
