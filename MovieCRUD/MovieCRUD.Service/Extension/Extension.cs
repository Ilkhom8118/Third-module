namespace MovieCRUD.Service.Extension
{
    public static class Extension
    {

        public static int DurationMinutes(this int minuts)
        {
            return minuts * 60;
        }
    }
}
