namespace EhouarnPerret.CSharp.Utilities.Core.IO
{
    public enum FileTimeKind : byte
    {
        Creation = 0x00,
        LastAccess = 0x01,
        LastWrite = 0x02,
        CreationUtc = 0x03,
        LastAccessUtc = 0x04,
        LastWriteUtc = 0x05,
    }
}