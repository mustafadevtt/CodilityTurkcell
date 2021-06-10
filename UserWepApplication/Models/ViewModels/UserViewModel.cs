using System;

namespace UserWepApplication.Models.ViewModels
{
	public class UserViewModel
	{
        public Guid? Id { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Title { get; set; }
        public string ErrorMessage { get; set; }
        public bool CreationMode { get; set; }
    }
}
