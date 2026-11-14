namespace nov13.DTO;

public record RegisterRequest(string Name, string LastName, DateOnly Bdate, string Email, string Login, string Password);
