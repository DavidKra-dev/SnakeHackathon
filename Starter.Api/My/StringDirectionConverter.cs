namespace Starter.Api
{
    public static class StringDirectionConverter
    {
        public static Coordinate String2Dir(string value)
        {
            Coordinate newCord = new Coordinate(0, 0);
            switch (value)
            {
                case "left":
                    newCord.X = -1;
                    newCord.Y = 0;
                    break;
                case "right":
                    newCord.X = 1;
                    newCord.Y = 0;
                    break;
                case "up":
                    newCord.X = 0;
                    newCord.Y = 1;
                    break;
                case "down":
                    newCord.X = 0;
                    newCord.Y = -1;
                    break;
            }

            return newCord;
        }

        public static string Dir2String(Coordinate value)
        {
            if (value.X == -1 && value.Y == 0)
                return "left";
            if (value.X == 1 && value.Y == 0)
                return "right";
            if (value.X == 0 && value.Y == 1)
                return "up";
            if (value.X == 0 && value.Y == -1)
                return "down";

            return "havent idea...";
        }
    }
}