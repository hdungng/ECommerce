using ECommerce.Domain.Common;

namespace ECommerce.Domain.Entities;

public sealed class User : BaseEntity
{
    private User() { }

    public User(string email)
    {
        SetEmail(email);
    }

    public string Email { get; private set; } = string.Empty;

    public void SetEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException("Email is required.", nameof(email));
        }

        Email = email.Trim();
        MarkUpdated();
    }
}
