$filePath = "C:\Users\Juan Camilo\Desktop\test";
$sdkPath = "C:\Windows\Microsoft.NET\Framework\v4.0.30319\";
$ilasmPath = $sdkPath + "ilasm.exe";
$LanguageExe = "C:\Users\Juan Camilo\Source\Repos\IFN660_M3J1\GPLexTutorial\bin\Debug\GPLexTutorial.exe";
$LanguageInput = "C:\Users\Juan Camilo\Source\Repos\IFN660_M3J1\GPLexTutorial\Tests\test2.j";
$ilPath = $filePath+".il";
$languagePrms = $LanguageInput, $ilPath
& $LanguageExe $languagePrms
& $ilasmPath $ilPath