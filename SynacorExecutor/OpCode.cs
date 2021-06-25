namespace SynacorExecutor
{
    public enum OpCode : byte
    {
        Halt = 0,
        Set = 1,
        Push = 2,
        Pop = 3,
        Eq = 4,
        Gt = 5,
        Jmp = 6,
        Jt = 7,
        Jf = 8,
        Add = 9,
        Mult = 10,
        Mod = 11,
        And = 12,
        Or = 13,
        Not = 14,
        Rmem = 15,
        WMem = 16,
        Call = 17,
        Ret = 18,
        Out = 19,
        In = 20,
        Noop = 21,
        Cancelled = 22,
    }
}
