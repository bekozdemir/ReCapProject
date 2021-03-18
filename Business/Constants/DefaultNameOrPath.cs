using System;
using System.IO;

namespace Core.Constants
{
    public static class DefaultNameOrPath
    {
        public static string ImageDirectory = "images"; // Klasör adı
        public static string FileDirectory = "files"; // Klasör Adı
        public static string TestDirectory = "images/sub1/sub2/sub3/sub4/sub5/sub6/sub7/sub8/sub9"; // Test Path adı
        public static string NoImagePath = ImageDirectory + "/NoImage.png"; // Sabit resim yolu
    }
}
