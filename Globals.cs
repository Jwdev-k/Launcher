using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Black_Desert_Private_Launcher
{
    class Globals
    {
        public static void WriteProcessMemory(long adress, byte[] processBytes, int processHandle)
        {
            WriteProcessMemory(processHandle, adress, processBytes, processBytes.Length, 0);
        }
        [DllImport("kernel32.dll")]
        public static extern int OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
        public static extern UIntPtr GetProcAddress(IntPtr hModule, string procName);

        [DllImport("kernel32.dll")]
        private static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, string lpBuffer, UIntPtr nSize, out IntPtr lpNumberOfBytesWritten);

        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(long hProcess, long lpBaseAddress, byte[] buffer, int size, int lpNumberOfBytesRead);

        [DllImport("kernel32.dll")]
        public static extern bool WriteProcessMemory(int hProcess, long lpBaseAddress, byte[] buffer, int size, int lpNumberOfBytesWritten);
        
        public static void Memory()
        {
            Task.Delay(5000);
            int GetProcessId(string proc)
            {
                return Process.GetProcessesByName(proc)[0].Id;
            }
            int processId = GetProcessId("BlackDesert64");
            Process[] processesByName = Process.GetProcessesByName("BlackDesert64");
            int processHandle = OpenProcess(0x1F0FFF, false, processesByName[0].Id);
            IntPtr baseAddress = processesByName[0].MainModule.BaseAddress;

            // Start server IP initialisation
            string serverIP = "127.0.0.1";
            byte[] serverIPtranslation = Encoding.ASCII.GetBytes(serverIP);

            // Start data stream manipulation
           /* WriteProcessMemory(baseAddress.ToInt64() + 0x0A28A26, new byte[] { 0x90, 0x90 }, processHandle); // Crypto fix v2100
            WriteProcessMemory(baseAddress.ToInt64() + 0x07A534A, new byte[] { 0x90, 0x90 }, processHandle); // XC fix 1 v2100
            WriteProcessMemory(baseAddress.ToInt64() + 0x07A5430, new byte[] { 0xEB }, processHandle); // XC fix 2 v2100
            WriteProcessMemory(baseAddress.ToInt64() + 0x05F4E9D, new byte[] { 0xE8, 0x8E, 0xFF, 0xFF, 0xFF }, processHandle);  //world boss timer fix v2100
            WriteProcessMemory(baseAddress.ToInt64() + 0x2B409C8, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, processHandle);// kr v2100 Wipe IP
            WriteProcessMemory(baseAddress.ToInt64() + 0x2B409D8, new byte[] { 0x09, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x0F }, processHandle); //kr v2100 IP 2
            WriteProcessMemory(baseAddress.ToInt64() + 0x2B409C8, serverIPtranslation, processHandle); // kr v2100 IP Set */



            //795 xc bypass
              WriteProcessMemory(baseAddress.ToInt64() + 0x0A29306, new byte[] { 0x90, 0x90 }, processHandle); // Crypto fix by Matt
              WriteProcessMemory(baseAddress.ToInt64() + 0x07A5B0A, new byte[] { 0x90, 0x90 }, processHandle); // XC Fix 1 by Matt
              WriteProcessMemory(baseAddress.ToInt64() + 0x07A5BF0, new byte[] { 0xEB }, processHandle); // XC Fix 2 by Matt
              WriteProcessMemory(baseAddress.ToInt64() + 0x2B41A38, new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, processHandle); // Wipe IP fix by r00tz
              WriteProcessMemory(baseAddress.ToInt64() + 0x05F563D, new byte[] { 0xE8, 0x8E, 0xFF, 0xFF, 0xFF }, processHandle); // world boss timer fix by Matt
              WriteProcessMemory(baseAddress.ToInt64() + 0x2B41A38, serverIPtranslation, processHandle); // Server IP fix by Matt
        }
    }
}
