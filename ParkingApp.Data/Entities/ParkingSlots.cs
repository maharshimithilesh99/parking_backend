using System;
using System.Collections.Generic;

namespace ParkingApp.Data.Entities;

public partial class ParkingSlots
{
    public int Id { get; set; }

    public string SlotNumber { get; set; } = null!;

    public bool IsOccupied { get; set; }
}
