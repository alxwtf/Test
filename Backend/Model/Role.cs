using Microsoft.AspNetCore.Identity;

namespace Backend.Model
{
    public class Role : IdentityRole<int>
    {
        public Role() { }
        public Role(string name) => Name = name;
    }
}