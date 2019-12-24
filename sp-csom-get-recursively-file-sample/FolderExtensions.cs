using System;
using Microsoft.SharePoint.Client;

namespace sp_csom_get_recursively_file_sample
{
    public static class FolderExtensions
    {
        public static void RecursiveFolder(this Folder folder)
        {
            var context = folder.Context;

            // フォルダー配下のサブフォルダー、ファイルを読み込む
            context.Load(folder, f => f.Folders, f => f.Files);
            context.ExecuteQuery();

            // サブフォルダーを再帰的に処理
            for (var i = folder.Folders.Count - 1; i >= 0; i--)
            {
                var subFolder = folder.Folders[i];

                subFolder.RecursiveFolder();
            }

            // ファイル情報を出力
            for (var i = folder.Files.Count - 1; i >= 0; i--)
            {
                var file = folder.Files[i];
                Console.WriteLine($"{file.TimeLastModified} | {file.Name}");
            }
        }
    }
}