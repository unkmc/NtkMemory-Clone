#SingleInstance ignore

Loop
{
    WinWait, AutoHotkey.dll
	WinGet, processName, ProcessName, AutoHotkey.dll
	Process, Close, %processName%
	SoundPlay *16
}
