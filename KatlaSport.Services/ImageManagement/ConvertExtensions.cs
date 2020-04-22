namespace KatlaSport.Services.ImageManagement
{
    public static class ConvertExtensions
    {
        public static string Repead(this string str)
        {
            str = str.Substring(0, str.Length - 1);
            return str;
        }
    }
}
