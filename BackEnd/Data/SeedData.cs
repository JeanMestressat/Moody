public class SeedData
{
    public static void Init()
    {
        using var context = new ApiContext();

        if (context.Users.Any())
        {
            return;
        }

        // User user1 = new()
        // {
        //     Name = "Mestressat",
        //     Last_Name = "Jean",

        // };

        // context.Users.AddRange(user1);

        context.SaveChanges();
    }
}