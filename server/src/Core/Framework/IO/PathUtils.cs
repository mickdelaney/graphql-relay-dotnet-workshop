using System.IO;

namespace Workshop.Core.Framework.IO
{
    public static class PathUtils
    {
        public static string MoveUp(string path, int noOfLevels)
        {
            var parentPath = path.TrimEnd(new[] { '/', '\\' });
            
            for (var i=0; i< noOfLevels; i++)
            {
                parentPath = Directory.GetParent(parentPath).ToString();
            }
            
            return parentPath;
        }
    }
}