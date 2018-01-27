using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class IOUtil
{
    private static string[] twoPaths = new string[2];
    private static string[] threePaths = new string[2];

    public static string CombinePath(string path1, string path2)
    {
        twoPaths[0] = path1;
        twoPaths[1] = path2;

        return CombinePath(twoPaths);
    }

    public static string CombinePath(string path1, string path2, string path3)
    {
        threePaths[0] = path1;
        threePaths[1] = path2;
        threePaths[2] = path3;

        return CombinePath(threePaths);
    }


    private static string CombinePath(string[] paths)
    {
        if (paths.Length == 0)
        {
            throw new ArgumentException("please input path");
        }
        else
        {
            StringBuilder builder = new StringBuilder();
            char spliter = '/';
            string firstPath = paths[0];
            if (firstPath.Length > 0 && firstPath[firstPath.Length - 1] != spliter)
            {
                firstPath = firstPath + spliter;
            }
            builder.Append(firstPath);
            for (int i = 1; i < paths.Length; i++)
            {
                string nextPath = paths[i];
                if (string.IsNullOrEmpty(nextPath))
                {
                    continue;
                }
                char nextPathStart = nextPath[0];
                if (nextPathStart == '/' || nextPathStart == '\\')
                {
                    nextPath = nextPath.Substring(1);
                }
                if (i != paths.Length - 1)//not the last one
                {
                    char nexPathLast = nextPath[nextPath.Length - 1];
                    if (nexPathLast == '/' || nexPathLast == '\\')
                    {
                        nextPath = nextPath.Substring(0, nextPath.Length - 1) + spliter;
                    }
                    else
                    {
                        nextPath = nextPath + spliter;
                    }
                }
                builder.Append(nextPath);
            }
            return builder.ToString();
        }
    }

    /// <summary>
    /// 檢測二進制某一位是否为1
    /// </summary>
    /// <param name="mark"></param>
    /// <param name="bit"></param>
    /// <returns></returns>
    public static bool CheckBit(int mark, int bit)
    {
        int bit2 = bit < 32 ? 1 << bit : 0;
        return (mark & bit2) > 0;
    }

    /// <summary>
    /// Asset 路径转换到绝对路径
    /// </summary>
    /// <returns></returns>
    public static string AssetPathToAbsPath(string assetPath)
    {
        if (!assetPath.StartsWith("Assets/"))
        {
            Debug.LogError("This path is not a asset path string!");
            return assetPath;
        }

        string dataPath = Application.dataPath;
        dataPath = dataPath.Substring(0, dataPath.Length - 6);
        string absPath = Path.Combine(dataPath, assetPath);

        return absPath;
    }
}