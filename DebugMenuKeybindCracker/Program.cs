using Keen.VRage.Core.Input;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO.Hashing;
using System.Numerics;
using System.Runtime.InteropServices;

namespace DebugMenuKeybindCracker
{
    internal class Program
    {
        private const ulong DEBUG_MENU_DEV_KEY_HASH = 15386013031716063262;

        private static readonly ImmutableArray<SmallInputId> _keys;

        [StructLayout(LayoutKind.Explicit)]
        struct SmallInputId
        {
            [FieldOffset(0)] public byte DeviceClass;
            [FieldOffset(1)] public byte Index;

            public SmallInputId(InputId id)
            {
                DeviceClass = (byte)id.DeviceClass;
                Index = (byte)id.Index;
            }

            public static explicit operator SmallInputId(InputId id)
            {
                return new SmallInputId(id);
            }
        }

        static Program()
        {
            InputId[] inputIdArray = new InputId[238];
            inputIdArray[1] = KeyboardInputs.Escape;
            inputIdArray[2] = KeyboardInputs.D1;
            inputIdArray[3] = KeyboardInputs.D2;
            inputIdArray[4] = KeyboardInputs.D3;
            inputIdArray[5] = KeyboardInputs.D4;
            inputIdArray[6] = KeyboardInputs.D5;
            inputIdArray[7] = KeyboardInputs.D6;
            inputIdArray[8] = KeyboardInputs.D7;
            inputIdArray[9] = KeyboardInputs.D8;
            inputIdArray[10] = KeyboardInputs.D9;
            inputIdArray[11] = KeyboardInputs.D0;
            inputIdArray[12] = KeyboardInputs.OemMinus;
            inputIdArray[13] = KeyboardInputs.OemEquals;
            inputIdArray[14] = KeyboardInputs.Back;
            inputIdArray[15] = KeyboardInputs.Tab;
            inputIdArray[16] = KeyboardInputs.Q;
            inputIdArray[17] = KeyboardInputs.W;
            inputIdArray[18] = KeyboardInputs.E;
            inputIdArray[19] = KeyboardInputs.R;
            inputIdArray[20] = KeyboardInputs.T;
            inputIdArray[21] = KeyboardInputs.Y;
            inputIdArray[22] = KeyboardInputs.U;
            inputIdArray[23] = KeyboardInputs.I;
            inputIdArray[24] = KeyboardInputs.O;
            inputIdArray[25] = KeyboardInputs.P;
            inputIdArray[26] = KeyboardInputs.OemOpenBrackets;
            inputIdArray[27] = KeyboardInputs.OemCloseBrackets;
            inputIdArray[28] = KeyboardInputs.Enter;
            inputIdArray[29] = KeyboardInputs.Control;
            inputIdArray[30] = KeyboardInputs.A;
            inputIdArray[31] = KeyboardInputs.S;
            inputIdArray[32] = KeyboardInputs.D;
            inputIdArray[33] = KeyboardInputs.F;
            inputIdArray[34] = KeyboardInputs.G;
            inputIdArray[35] = KeyboardInputs.H;
            inputIdArray[36] = KeyboardInputs.J;
            inputIdArray[37] = KeyboardInputs.K;
            inputIdArray[38] = KeyboardInputs.L;
            inputIdArray[39] = KeyboardInputs.OemSemicolon;
            inputIdArray[40] = KeyboardInputs.OemQuotes;
            inputIdArray[41] = KeyboardInputs.OemBacktick;
            inputIdArray[42] = KeyboardInputs.Shift;
            inputIdArray[43] = KeyboardInputs.OemBackSlash;
            inputIdArray[44] = KeyboardInputs.Z;
            inputIdArray[45] = KeyboardInputs.X;
            inputIdArray[46] = KeyboardInputs.C;
            inputIdArray[47] = KeyboardInputs.V;
            inputIdArray[48] = KeyboardInputs.B;
            inputIdArray[49] = KeyboardInputs.N;
            inputIdArray[50] = KeyboardInputs.M;
            inputIdArray[51] = KeyboardInputs.OemComma;
            inputIdArray[52] = KeyboardInputs.OemPeriod;
            inputIdArray[53] = KeyboardInputs.OemForwardSlash;
            inputIdArray[54] = KeyboardInputs.Shift;
            inputIdArray[55] = KeyboardInputs.NumpadMultiply;
            inputIdArray[56] = KeyboardInputs.Alt;
            inputIdArray[57] = KeyboardInputs.Space;
            inputIdArray[58] = KeyboardInputs.Capital;
            inputIdArray[59] = KeyboardInputs.F1;
            inputIdArray[60] = KeyboardInputs.F2;
            inputIdArray[61] = KeyboardInputs.F3;
            inputIdArray[62] = KeyboardInputs.F4;
            inputIdArray[63] = KeyboardInputs.F5;
            inputIdArray[64] = KeyboardInputs.F6;
            inputIdArray[65] = KeyboardInputs.F7;
            inputIdArray[66] = KeyboardInputs.F8;
            inputIdArray[67] = KeyboardInputs.F9;
            inputIdArray[68] = KeyboardInputs.F10;
            inputIdArray[69] = KeyboardInputs.NumLock;
            inputIdArray[70] = KeyboardInputs.ScrollLock;
            inputIdArray[71] = KeyboardInputs.Numpad7;
            inputIdArray[72] = KeyboardInputs.Numpad8;
            inputIdArray[73] = KeyboardInputs.Numpad9;
            inputIdArray[74] = KeyboardInputs.NumpadSubtract;
            inputIdArray[75] = KeyboardInputs.Numpad4;
            inputIdArray[76] = KeyboardInputs.Numpad5;
            inputIdArray[77] = KeyboardInputs.Numpad6;
            inputIdArray[78] = KeyboardInputs.NumpadAdd;
            inputIdArray[79] = KeyboardInputs.Numpad1;
            inputIdArray[80] = KeyboardInputs.Numpad2;
            inputIdArray[81] = KeyboardInputs.Numpad3;
            inputIdArray[82] = KeyboardInputs.Numpad0;
            inputIdArray[83] = KeyboardInputs.NumpadDecimal;
            inputIdArray[87] = KeyboardInputs.F11;
            inputIdArray[88] = KeyboardInputs.F12;
            inputIdArray[100] = KeyboardInputs.F13;
            inputIdArray[101] = KeyboardInputs.F14;
            inputIdArray[102] = KeyboardInputs.F15;
            //inputIdArray[144] = KeyboardInputs.MediaPrevTrack; // exclude unlikely keys
            //inputIdArray[153] = KeyboardInputs.MediaNextTrack;
            inputIdArray[156] = KeyboardInputs.Enter;
            inputIdArray[157] = KeyboardInputs.Control;
            //inputIdArray[160] = KeyboardInputs.VolumeMute;
            //inputIdArray[162] = KeyboardInputs.MediaPlayPause;
            //inputIdArray[164] = KeyboardInputs.MediaStop;
            //inputIdArray[174] = KeyboardInputs.VolumeDown;
            //inputIdArray[176] = KeyboardInputs.VolumeUp;
            //inputIdArray[178] = KeyboardInputs.BrowserHome;
            inputIdArray[179] = KeyboardInputs.NumpadSeparator;
            inputIdArray[181] = KeyboardInputs.NumpadDivide;
            inputIdArray[183] = KeyboardInputs.PrintScreen;
            inputIdArray[184] = KeyboardInputs.Alt;
            inputIdArray[197] = KeyboardInputs.Pause;
            inputIdArray[199] = KeyboardInputs.Home;
            inputIdArray[200] = KeyboardInputs.Up;
            inputIdArray[201] = KeyboardInputs.PageUp;
            inputIdArray[203] = KeyboardInputs.Left;
            inputIdArray[205] = KeyboardInputs.Right;
            inputIdArray[207] = KeyboardInputs.End;
            inputIdArray[208] = KeyboardInputs.Down;
            inputIdArray[209] = KeyboardInputs.PageDown;
            inputIdArray[210] = KeyboardInputs.Insert;
            inputIdArray[211] = KeyboardInputs.Delete;
            //inputIdArray[219] = KeyboardInputs.LWin;
            //inputIdArray[220] = KeyboardInputs.RWin;
            //inputIdArray[221] = KeyboardInputs.Apps;
            //inputIdArray[223] = KeyboardInputs.Sleep;
            //inputIdArray[229] = KeyboardInputs.BrowserSearch;
            //inputIdArray[230] = KeyboardInputs.BrowserFavorites;
            //inputIdArray[231] = KeyboardInputs.BrowserRefresh;
            //inputIdArray[232] = KeyboardInputs.BrowserStop;
            //inputIdArray[233] = KeyboardInputs.BrowserForward;
            //inputIdArray[234] = KeyboardInputs.BrowserBack;
            //inputIdArray[236] = KeyboardInputs.LaunchMail;
            //inputIdArray[237] = KeyboardInputs.LaunchMediaSelect;
            _keys = ImmutableArray.Create<SmallInputId>(inputIdArray
                .Where(i => i != default(InputId))
                .Select(i => new SmallInputId(i))
                .DistinctBy(i => i.Index)
                .OrderBy(i => i.Index)
                .ToArray());
        }

        // "reference" function
        private static ulong HashInput(Span<SmallInputId> sortedInputs, int numInputsToHash)
        {
            Span<byte> source = stackalloc byte[numInputsToHash * 2];
            for (int index = 0; index < numInputsToHash; ++index)
            {
                SmallInputId inputId = sortedInputs[index];
                source[index * 2] = (byte)inputId.DeviceClass;
                source[index * 2 + 1] = (byte)inputId.Index;
            }
            return XxHash64.HashToUInt64((ReadOnlySpan<byte>)source, 5417L);
        }

        private static unsafe ulong HashInputFast(Span<SmallInputId> sortedInputs, int numInputsToHash)
        {
            fixed (SmallInputId* ptr = sortedInputs)
            {
                return XxHash64.HashToUInt64(new ReadOnlySpan<byte>(ptr, numInputsToHash * 2), 5417L);
            }
        }

        private static unsafe ulong HashInputFast(SmallInputId* sortedInputsPtr, int numInputsToHash)
        {
            return XxHash64.HashToUInt64(new ReadOnlySpan<byte>(sortedInputsPtr, numInputsToHash * 2), 5417L);
        }

        static async Task PrintThroughput(Func<ulong> processedHashCountFunc, Stopwatch sw, ulong totalHashes)
        {
            await Task.Delay(1000);

            while (sw.IsRunning)
            {
                ulong hashes = processedHashCountFunc.Invoke();
                double elapsedSeconds = sw.Elapsed.TotalSeconds;
                Console.WriteLine($"Throughput={hashes / elapsedSeconds / 1_000_000.0:0.00} million hashes/s | Elapsed={elapsedSeconds:0.00}s | Hashed={hashes / 1_000_000_000.0:0.00}B / {totalHashes / 1_000_000_000.0:0.00}B");
                await Task.Delay(1000);
            }
        }

        static BigInteger Factorial(BigInteger f)
        {
            BigInteger result = 1;
            for (BigInteger i = f; i > 0; i--)
            {
                result *= i;
            }
            return result;
        }

        static BigInteger CalculateTotalHashes(int setSize, int maxComboLength)
        {
            // 101!/((101-6)!*6!)
            return (Factorial(setSize) / (Factorial(setSize - maxComboLength) * Factorial(maxComboLength)));
        }

        static void TestDevCombo()
        {
            SmallInputId[] devCombo =
            {
                (SmallInputId)KeyboardInputs.Control.Id,
                (SmallInputId)KeyboardInputs.Shift.Id,
                (SmallInputId)KeyboardInputs.Alt.Id,
                (SmallInputId)KeyboardInputs.Delete.Id,
                (SmallInputId)KeyboardInputs.OemComma.Id,
                (SmallInputId)KeyboardInputs.OemPeriod.Id,
            };
            devCombo = devCombo.OrderBy(i => i.Index).ToArray();
            ulong hash = HashInput(devCombo, devCombo.Length);
            Debug.Assert(hash == DEBUG_MENU_DEV_KEY_HASH);
        }

        static void TestHashInputFast()
        {
            // check that they both produce the same hash
            SmallInputId[] testCombo = [_keys[12], _keys[34], _keys[56]];
            ulong h1 = HashInput(testCombo, testCombo.Length);
            ulong h2 = HashInputFast(testCombo, testCombo.Length);
            Debug.Assert(h1 == h2);
        }

        static unsafe void Main(string[] args)
        {
            TestDevCombo();
            TestHashInputFast();

            // this code only works when inputs are sorted by index in ascending order

            Stopwatch sw = new Stopwatch();
            sw.Start();
            ulong processed = 0;
            int maxLength = 7;
            ulong totalHashes = (ulong)CalculateTotalHashes(_keys.Length, maxLength);
            Task.Run(() => PrintThroughput(() => processed, sw, totalHashes));

            SmallInputId* sortedInputs = stackalloc SmallInputId[maxLength];
            int* indices = stackalloc int[maxLength];
            SmallInputId* keysPtr = stackalloc SmallInputId[_keys.Length];
            for (int i = 0; i < _keys.Length; i++)
                keysPtr[i] = _keys[i];

            for (int k = 1; k <= maxLength; k++)
            {
                while (true)
                {
                    for (int i = 0; i < k; i++)
                    {
                        sortedInputs[i] = keysPtr[indices[i]];
                    }

                    processed++;
                    ulong hash = HashInputFast(sortedInputs, k);

                    if (hash == DEBUG_MENU_DEV_KEY_HASH)
                    {
                        sw.Stop();
                        Console.WriteLine($"Match found in {sw.Elapsed.TotalSeconds:0.00} seconds");
                        for (int i = 0; i < k; i++)
                        {
                            Console.WriteLine(KeyboardInputs.Inputs.First(kv => kv.Key.Index == sortedInputs[i].Index).Value);
                        }
                        Console.ReadKey();
                    }

                    if (++indices[k - 1] >= _keys.Length)
                    {
                        for (int i = k - 1; i > 0; i--)
                        {
                            indices[i] = Math.Min(indices[i - 1] + 1, _keys.Length - 1); // significantly reduce the number of hashes with duplicate keys (wasted computations)
                            if (++indices[i - 1] < _keys.Length - 1)
                            {
                                break;
                            }
                        }

                        if (indices[0] >= _keys.Length)
                        {
                            break;
                        }
                    }
                }

                Console.WriteLine($"Hash not found in {k} length combos");

                for (int i = 0; i < k; i++)
                {
                    indices[i] = 0;
                }
            }

            sw.Stop();
            Console.WriteLine($"Finished hashing, no match found in {processed} hashes.");
            Console.ReadKey();
        }
    }
}
