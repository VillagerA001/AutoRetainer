﻿namespace AutoRetainer.Configuration;

[Serializable]
public class AdditionalRetainerData
{
    public bool EntrustDuplicates = false;
    public bool WithdrawGil = false;
    public int WithdrawGilPercent = 100;
    public bool Deposit = false;
    public List<uint> VenturePlanner = new();
    public uint LastVenture = 0;
}
