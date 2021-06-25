using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

using Newtonsoft.Json;

namespace SynacorExecutor
{
    public class VM
    {
        // Core Parts
        public ushort[] Memory { get; set; }
        public ushort[] Registers { get; set; }
        public Stack<ushort> Stack { get; set; }
        public int Pointer { get; set; }

        // IO
        [JsonIgnore]
        public Func<char> In;
        [JsonIgnore]
        public Action<char> Out;
        [JsonIgnore]
        public Action<Instruction> InstructionExecuted;

        // Control
        public bool Halted { get; set; }
        public bool IsStepping { get; set; }
        [JsonIgnore]

        private ushort Modulo;

        public VM(ushort[] startingMemory)
        {
            Modulo = 0b1000000000000000; // 2 ^ 15

            Memory = new ushort[Modulo];
            Array.Copy(startingMemory, 0, Memory, 0, startingMemory.Length);

            Registers = new ushort[8];
            Stack = new Stack<ushort>();
            Pointer = 0;
        }

        public ushort GetValue(ushort addr)
        {
            if (addr >= Modulo + 8) { addr = (ushort)(addr % Modulo); }
            return addr < Modulo ? addr : Registers[addr % Modulo];
        }

        public void SetValue(int valInt, ushort addr)
        {
            var val = (ushort)valInt;
            if (addr >= Modulo + 8) { addr = (ushort)(addr % Modulo); }

            if (addr < Modulo)
            {
                Memory[addr] = val;
                return;
            }

            Registers[addr - Modulo] = val;
        }

        public OpCode Step()
        {
            IsStepping = true;
            var opCode = (OpCode)Memory[Pointer];

            var oldPointer = Pointer;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            ushort P(ushort i) => Memory[oldPointer + i + 1];

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            ushort A() => GetValue(P(0));
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            ushort B() => GetValue(P(1));
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            ushort C() => GetValue(P(2));

            var paramCount = 0;
            var jumped = false;

            switch (opCode)
            {
                case OpCode.Halt:
                    Halted = true;
                    break;
                case OpCode.Set:
                    SetValue(B(), P(0));
                    paramCount = 2;
                    break;
                case OpCode.Push:
                    Stack.Push(A());
                    paramCount = 1;
                    break;
                case OpCode.Pop:
                    SetValue(Stack.Pop(), P(0));
                    paramCount = 1;
                    break;
                case OpCode.Eq:
                    SetValue(B() == C() ? 1 : 0, P(0));
                    paramCount = 3;
                    break;
                case OpCode.Gt:
                    SetValue(B() > C() ? 1 : 0, P(0));
                    paramCount = 3;
                    break;
                case OpCode.Jmp:
                    Pointer = A();
                    paramCount = 1;
                    jumped = true;
                    break;
                case OpCode.Jt:
                    if (A() != 0)
                    {
                        Pointer = B();
                        jumped = true;
                    }
                    paramCount = 2;
                    break;
                case OpCode.Jf:
                    if (A() == 0)
                    {
                        Pointer = B();
                        jumped = true;
                    }
                    paramCount = 2;
                    break;
                case OpCode.Add:
                    SetValue((B() + C()) % Modulo, P(0));
                    paramCount = 3;
                    break;
                case OpCode.Mult:
                    SetValue((B() * C() % Modulo), P(0));
                    paramCount = 3;
                    break;
                case OpCode.Mod:
                    SetValue(B() % C(), P(0));
                    paramCount = 3;
                    break;
                case OpCode.And:
                    SetValue(B() & C(), P(0));
                    paramCount = 3;
                    break;
                case OpCode.Or:
                    SetValue(B() | C(), P(0));
                    paramCount = 3;
                    break;
                case OpCode.Not:
                    var notted = ~B();
                    if (B() < Modulo) { notted -= Modulo; }
                    SetValue(notted, P(0));
                    paramCount = 2;
                    break;
                case OpCode.Rmem:
                    SetValue(Memory[B()], P(0));
                    paramCount = 2;
                    break;
                case OpCode.WMem:
                    SetValue(B(), A());
                    paramCount = 2;
                    break;
                case OpCode.Call:
                    Stack.Push((ushort)(Pointer + 2));
                    Pointer = A();
                    jumped = true;
                    paramCount = 1;
                    break;
                case OpCode.Ret:
                    Pointer = Stack.Pop();
                    jumped = true;
                    paramCount = 0;
                    break;
                case OpCode.Out:
                    Out?.Invoke((char)GetValue(P(0)));
                    paramCount = 1;
                    break;
                case OpCode.In:
                    SetValue(In.Invoke(), P(0));
                    paramCount = 1;
                    break;
            }

            if (InstructionExecuted is not null)
            {
                var p = new ushort[paramCount];
                for (var i = 0; i < paramCount; i++)
                {
                    p[i] = P((ushort)i);
                }

                InstructionExecuted.Invoke(new Instruction()
                {
                    Pointer = Pointer,
                    OpCode = opCode,
                    Parameters = p,
                });
            }

            Pointer += jumped ? 0 : paramCount + 1;

            IsStepping = false;
            return opCode;
        }
    }
}
