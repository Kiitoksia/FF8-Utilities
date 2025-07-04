using System;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace FlowTimer {

    public static class Extensions {

        public static void AbortIfAlive(this Thread thread) {
            if(thread.IsAlive) {
                thread.Abort();
                thread.Join();
            }
        }

        public static double ToDouble(this string val) {
            return double.Parse(val, CultureInfo.InvariantCulture);
        }

        public static string ToFormattedString(this double val) {
            return val.ToString("F3", CultureInfo.InvariantCulture);
        }

        public static string ToFormattedString(this Keys val) {
            return val == Keys.None ? "Unset" : val.ToString();
        }

        // credit to https://stackoverflow.com/a/32859334/7281499
        private static readonly Action<Control, ControlStyles, bool> SetStyle = (Action<Control, ControlStyles, bool>) Delegate.CreateDelegate(typeof(Action<Control, ControlStyles, bool>), typeof(Control).GetMethod("SetStyle", BindingFlags.NonPublic | BindingFlags.Instance, null, new[] { typeof(ControlStyles), typeof(bool) }, null));
        public static void DisableSelect(this Control control) {
            SetStyle(control, ControlStyles.Selectable, false);
        }

        public static T[] Subarray<T>(this T[] source, int index, int length) {
            T[] subarray = new T[length];
            Array.Copy(source, index, subarray, 0, length);
            return subarray;
        }

        public static T Consume<T>(this byte[] array, ref int pointer) where T : unmanaged {
            T ret = ReadStruct<T>(array, pointer);
            pointer += Marshal.SizeOf<T>();
            return ret;
        }

        public static T ReadStruct<T>(this byte[] array, int pointer) where T : unmanaged {
            int structSize = Marshal.SizeOf<T>();
            IntPtr ptr = Marshal.AllocHGlobal(structSize);
            Marshal.Copy(array, pointer, ptr, structSize);
            T str = Marshal.PtrToStructure<T>(ptr);
            Marshal.FreeHGlobal(ptr);
            return str;
        }

        public static void Init(string appDataFolder)
        {
            string extractedDllPath = Path.Combine(appDataFolder, "SDL2.dll");
            if (!File.Exists(extractedDllPath))
            {
                var assembly = Assembly.GetExecutingAssembly();
                using (var stream = assembly.GetManifestResourceStream("FF8Utilities.Resources.SDL2.dll"))
                {
                    if (!File.Exists(extractedDllPath))
                    {
                        // Write the DLL to disk
                        using (var fileStream = new FileStream(extractedDllPath, FileMode.Create, FileAccess.Write))
                        {
                            stream.CopyTo(fileStream);
                        }
                    }
                }
            }

            LoadLibrary(extractedDllPath);
            AudioContext.GlobalInit();

        }

        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern IntPtr LoadLibrary(string lpFileName);
    }
}
