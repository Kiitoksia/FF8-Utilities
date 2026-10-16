using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;

namespace FF8Utilities
{
    public enum GlobalKey
    {
        Digit,
        Backspace,
        Enter
    }

    /// <summary>
    /// Low level keyboard hook used to react to numpad digits, backspace and enter whilst another
    /// application (i.e. FF8) has focus.  Keys are always passed through to the focused application,
    /// and are ignored entirely whilst one of our own windows is in the foreground so that normal WPF
    /// input handling is not doubled up.
    /// </summary>
    public static class GlobalKeyboardHook
    {
        /// <summary>
        /// Low-level keyboard hook identifier used with SetWindowsHookEx to install a hook procedure that monitors
        /// keyboard input events.
        /// </summary>
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;
        private const int WM_SYSKEYDOWN = 0x0104;
        private const int WM_SYSKEYUP = 0x0105;

        private const int VK_BACK = 0x08;
        private const int VK_RETURN = 0x0D;
        private const int VK_NUMPAD0 = 0x60;
        private const int VK_NUMPAD9 = 0x69;

        [StructLayout(LayoutKind.Sequential)]
        private struct KBDLLHOOKSTRUCT
        {
            public int vkCode;
            public int scanCode;
            public int flags;
            public int time;
            public IntPtr dwExtraInfo;
        }

        private delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll")]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        // Kept in a static field so the delegate is not garbage collected whilst the hook is installed
        private static readonly LowLevelKeyboardProc _proc = HookCallback;
        private static readonly uint _currentProcessId = (uint)Process.GetCurrentProcess().Id;
        private static readonly HashSet<int> _heldKeys = new HashSet<int>();
        private static readonly List<Action<GlobalKey, char?>> _subscribers = new List<Action<GlobalKey, char?>>();
        private static IntPtr _hookId = IntPtr.Zero;

        /// <summary>
        /// Subscribes to global key presses.  Must be called from the UI thread.  Dispose the result to unsubscribe;
        /// the hook is uninstalled once there are no subscribers left.
        /// </summary>
        public static IDisposable Subscribe(Action<GlobalKey, char?> handler)
        {
            _subscribers.Add(handler);
            if (_hookId == IntPtr.Zero)
            {
                using (Process process = Process.GetCurrentProcess())
                using (ProcessModule module = process.MainModule)
                {
                    _hookId = SetWindowsHookEx(WH_KEYBOARD_LL, _proc, GetModuleHandle(module.ModuleName), 0);
                }
            }

            return new Subscription(handler);
        }

        private static void Unsubscribe(Action<GlobalKey, char?> handler)
        {
            _subscribers.Remove(handler);
            if (_subscribers.Count == 0 && _hookId != IntPtr.Zero)
            {
                UnhookWindowsHookEx(_hookId);
                _hookId = IntPtr.Zero;
                _heldKeys.Clear();
            }
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                int message = wParam.ToInt32();
                KBDLLHOOKSTRUCT data = Marshal.PtrToStructure<KBDLLHOOKSTRUCT>(lParam);

                if (message == WM_KEYUP || message == WM_SYSKEYUP)
                {
                    _heldKeys.Remove(data.vkCode);
                }
                else if (message == WM_KEYDOWN || message == WM_SYSKEYDOWN)
                {
                    // HashSet.Add returns false if the key is already held, i.e. this is an auto-repeat.
                    // Repeats are allowed for backspace only, so it can be held to delete multiple digits
                    bool isRepeat = !_heldKeys.Add(data.vkCode) && data.vkCode != VK_BACK;
                    if (!isRepeat && !IsOwnWindowInForeground() && TryMapKey(data, out GlobalKey key, out char? digit))
                    {
                        Raise(key, digit);
                    }
                }
            }

            // Always pass the key on so the focused application still receives it
            return CallNextHookEx(_hookId, nCode, wParam, lParam);
        }

        private static bool IsOwnWindowInForeground()
        {
            IntPtr foreground = GetForegroundWindow();
            if (foreground == IntPtr.Zero) return false;
            GetWindowThreadProcessId(foreground, out uint processId);
            return processId == _currentProcessId;
        }

        private static bool TryMapKey(KBDLLHOOKSTRUCT data, out GlobalKey key, out char? digit)
        {
            key = GlobalKey.Digit;
            digit = null;

            if (data.vkCode >= VK_NUMPAD0 && data.vkCode <= VK_NUMPAD9)
            {
                digit = (char)('0' + (data.vkCode - VK_NUMPAD0));
                return true;
            }

            if (data.vkCode == VK_BACK)
            {
                key = GlobalKey.Backspace;
                return true;
            }

            if (data.vkCode == VK_RETURN)
            {
                key = GlobalKey.Enter;
                return true;
            }

            return false;
        }

        private static void Raise(GlobalKey key, char? digit)
        {
            // Windows silently removes low level hooks that take too long, so do the work asynchronously
            Application.Current?.Dispatcher.BeginInvoke(new Action(() =>
            {
                foreach (Action<GlobalKey, char?> subscriber in _subscribers.ToArray())
                {
                    subscriber(key, digit);
                }
            }));
        }

        private class Subscription : IDisposable
        {
            private Action<GlobalKey, char?> _handler;

            public Subscription(Action<GlobalKey, char?> handler)
            {
                _handler = handler;
            }

            public void Dispose()
            {
                if (_handler == null) return;
                Unsubscribe(_handler);
                _handler = null;
            }
        }
    }
}
