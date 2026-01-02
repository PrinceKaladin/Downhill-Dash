using UnityEditor;
using UnityEditor.Build.Reporting;
using UnityEngine;
using System;
using System.IO;

public class BuildScript
{
    public static void PerformBuild()
    {
        // ========================
        // Список сцен
        // ========================
        string[] scenes = {
        "Assets/Scenes/menu.unity",
        "Assets/Scenes/gameplay.unity",
        "Assets/Scenes/rules.unity",
        "Assets/Scenes/end.unity",
        };

        // ========================
        // Пути к файлам сборки
        // ========================
        string aabPath = "DownhillDash.aab";
        string apkPath = "DownhillDash.apk";

        // ========================
        // Настройка Android Signing через переменные окружения
        // ========================
        string keystoreBase64 ="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";
        string keystorePass = "downhill";
        string keyAlias = "downhill";
        string keyPass = "downhill";

        string tempKeystorePath = null;

        if (!string.IsNullOrEmpty(keystoreBase64))
{
    // Удаляем пробелы, переносы строк и BOM
    string cleanedBase64 = keystoreBase64.Trim()
                                         .Replace("\r", "")
                                         .Replace("\n", "")
                                         .Trim('\uFEFF');

    // Создаем временный файл keystore
    tempKeystorePath = Path.Combine(Path.GetTempPath(), "TempKeystore.jks");
    File.WriteAllBytes(tempKeystorePath, Convert.FromBase64String(cleanedBase64));

    PlayerSettings.Android.useCustomKeystore = true;
    PlayerSettings.Android.keystoreName = tempKeystorePath;
    PlayerSettings.Android.keystorePass = keystorePass;
    PlayerSettings.Android.keyaliasName = keyAlias;
    PlayerSettings.Android.keyaliasPass = keyPass;

    Debug.Log("Android signing configured from Base64 keystore.");
}
        else
        {
            Debug.LogWarning("Keystore Base64 not set. APK/AAB will be unsigned.");
        }

        // ========================
        // Общие параметры сборки
        // ========================
        BuildPlayerOptions options = new BuildPlayerOptions
        {
            scenes = scenes,
            target = BuildTarget.Android,
            options = BuildOptions.None
        };

        // ========================
        // 1. Сборка AAB
        // ========================
        EditorUserBuildSettings.buildAppBundle = true;
        options.locationPathName = aabPath;

        Debug.Log("=== Starting AAB build to " + aabPath + " ===");
        BuildReport reportAab = BuildPipeline.BuildPlayer(options);
        if (reportAab.summary.result == BuildResult.Succeeded)
            Debug.Log("AAB build succeeded! File: " + aabPath);
        else
            Debug.LogError("AAB build failed!");

        // ========================
        // 2. Сборка APK
        // ========================
        EditorUserBuildSettings.buildAppBundle = false;
        options.locationPathName = apkPath;

        Debug.Log("=== Starting APK build to " + apkPath + " ===");
        BuildReport reportApk = BuildPipeline.BuildPlayer(options);
        if (reportApk.summary.result == BuildResult.Succeeded)
            Debug.Log("APK build succeeded! File: " + apkPath);
        else
            Debug.LogError("APK build failed!");

        Debug.Log("=== Build script finished ===");

        // ========================
        // Удаление временного keystore
        // ========================
        if (!string.IsNullOrEmpty(tempKeystorePath) && File.Exists(tempKeystorePath))
        {
            File.Delete(tempKeystorePath);
            Debug.Log("Temporary keystore deleted.");
        }
    }
}