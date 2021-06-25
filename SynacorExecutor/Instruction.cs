using System;

namespace SynacorExecutor
{
    [Serializable]
    public class Instruction
    {
        public ushort Pointer;
        public OpCode OpCode;
        public ushort[] Parameters;
    }
}
