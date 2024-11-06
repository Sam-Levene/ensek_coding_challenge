namespace ensek_coding_challenge.Utilities
{ 
    public class HelperFunctions
    {
        public static long GetUnixTimeStamp() {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds();
        }

    }
}