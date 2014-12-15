﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;

namespace SlickUpdater
{
    public static class regcheck
    {
        public static string arma3RegCheck()
        {
            string line = Properties.Settings.Default.A3path;
            if (line == "")
            {
                String value = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Bohemia Interactive\Arma 3", "MAIN", null);
                if (value != null) {
                    Properties.Settings.Default.A3path = value;
                    //ConfigManager.write("ArmA3", "path", value);
                    return value;
                } else {
                    return line;
                }
            } else {
                return line;
            }
        }
        //ArmA2 regcheck(Operation Arrowhead)
        public static string arma2RegCheck()
        {
            string line = Properties.Settings.Default.A2path;
            if (line == "")
            {
                String value = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Bohemia Interactive\ArmA 2 OA\BattlEye", "MAIN", null);
                if (value != null)
                {
                    Properties.Settings.Default.A2path = value;
                    //ConfigManager.write("ArmA2", "path", value);
                    return value;
                }
                else
                {
                    return line;
                }
            }
            else
            {
                return line;
            }
        }

        public static string varma2RegCheck()
        {
            string line = Properties.Settings.Default.vA2Path;
            if(line == "")
            {
                String value = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Bohemia Interactive\ArmA 2\BattlEye", "MAIN", null);
                if (value != null)
                {
                    Properties.Settings.Default.vA2Path = value;
                    return value;
                }
                else
                {
                    return line;
                }
            }
            else
            {
                return line;
            }
        }
        public static string ts3RegCheck() {
            string line = Properties.Settings.Default.ts3Dir;
            if (line == "") {
                String value = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Classes\ts3file\shell\open\command", null, null);
                if (value != null) {
                    char[] trimChars = {'\"', '\\', '%', '1', ' '};
                    value = value.Trim(trimChars);
                    string[] remove = { @"\ts3client_win64.exe", @"\ts3client_win32.exe" };
                    foreach (string removeinput in remove) {
                        if (value.EndsWith(removeinput)) {
                            value = value.Substring(0, value.IndexOf(removeinput));
                            break;
                        }
                    }

                    //ConfigManager.write("ArmA3", "ts3Dir", value);
                    Properties.Settings.Default.ts3Dir = value;
                    return value;
                } else {
                    return line;
                }
            } else {
                return line;
            }
        }
    }
}

