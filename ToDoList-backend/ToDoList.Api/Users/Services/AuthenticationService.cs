namespace ToDoList.Api.Users.Services;

public class AuthenticationService
{
    public static bool VerifyPassword(string hashedPassword, string? enteredPassword)
    {
        return BCrypt.Net.BCrypt.Verify(enteredPassword, hashedPassword);
    }
}
