# Logging

## Debug.Log
The Unity way of logging is via [`UnityEngine.Debug.Log(...)`](https://docs.unity3d.com/ScriptReference/Debug.Log.html) and its [variants](https://docs.unity3d.com/ScriptReference/Debug.html). The log file is `Parkitect\Parkitect_Data\output_log.txt`. Uncatched exceptions are logged to that file too (with their StackTrace).
The log file's created new every time Parkitect starts. New messages are added at the end of the file when they are logged. That means you must reload the file in your text editor to see new logs. Some text editors can auto-refresh a file when it changed (e.g. Notepad++ with a "Document monitor" plugin).  


Besides opening the log file in a text editor, a debug console with the log messages and exceptions can be brought up in Parkitect by hitting `Ctrl+Alt+D`. However that window only displays messages that are logged while it's open.  
![Debug Console](./img/DebugConsole.png)

<!--
Isn't compatible with Parkitect Alpha 1
## ModTools
[ModTools](https://github.com/parkitectLab/modTools/releases) is a Parkitect mod, that provides several helpful tools for creating a mod. Amongst them is a console which provides a more advanced output than by Parkitect's debug console. The console can be opened via the key `BackQuote` (or `Circumflex` for german keyboards).
-->

## ModTools.Debug
[ModTools.Debug](https://github.com/parkitectLab/modTools/blob/master/ModTools/Debug.cs) provides a wrapper around `UnityEnginge.Debug.Log` but can also put your log messages into the Parkitect notification bar.
![Debug Console](./img/ModToolsLogToNotificationBar.png)  
You can switch the output by setting `consoleOnly`: if `false` it displays messages in the notification bar, else (`false`) it uses `UnityEngine.Debug.Log` and therefore outputs the debug messages to `Parkitect\Parkitect_Data\output_log.txt`.

The available logging command are:
* `LogMT(string text)`: Logs the passed text. Prepends `Debug.textPrefix` and the current time (if `Debug.showTime` is enabled).
    * this function is the base for all other `LogMT` methods.
* `LogMT(List<string> texts)`: Logs each passed string individually.
* `LogMT(string[] names, string[] values)`: For key-value pairs. 
    * Each pair is logged individually. 
    * `names` and `values` must have the same length.
* `LogMT(string[] names, long[] values, uint mode = 0)`: For key-value pairs.
    * `mode=0`: same as above, `values` are just converted into strings
    * `mode=1`: assumes `values` are unix timestamps and converts them into date time
    * `mode=2`: assumes `values` are durations in ms and converts them into time span
    * Last two are useful for measuring time like with `System.Diagnostics.StopWatch`
