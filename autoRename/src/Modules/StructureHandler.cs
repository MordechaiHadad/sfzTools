﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace autoRename.Modules
{
    public class StructureHandler
    {
        public static string[][] SortByDirs(string rootPath, string extension = null)
        {
            var result = new List<string[]> { extension != null ? ByExtension(rootPath, extension) : Directory.GetFiles(rootPath) };
            Directory.GetDirectories(rootPath).ToList().ForEach(d => result.AddRange(SortByDirs(d, extension)));

            return result.ToArray();
        }

        private static string[] ByExtension(string path, string extension)
        {
            var files = new List<string>();
            foreach (var file in Directory.GetFiles(path))
            {
                if (Path.GetExtension(file).Equals(extension, StringComparison.CurrentCultureIgnoreCase))
                    files.Add(file);
            }
            return files.ToArray();
        }
    }
}