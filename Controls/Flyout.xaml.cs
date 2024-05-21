namespace TutorsBro.Controls;

public partial class Flyout : StackLayout
{
	public Flyout()
	{
		InitializeComponent();

		if(App.UserDetails != null)
		{
			lblUserName.Text = App.UserDetails.FullName;
            lblUserEmail.Text = App.UserDetails.Email;
			lblUserRole.Text = App.UserDetails.Role;
        }
	}
}