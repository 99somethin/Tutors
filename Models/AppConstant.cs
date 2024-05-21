using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TutorsBro.Controls;
using TutorsBro.Views.Dashboard;

namespace TutorsBro.Models
{
    public class AppConstant
    {
        public async static Task AddFlyoutMenusDetails()
        {
            AppShell.Current.FlyoutHeader = new Flyout();

            var studentProfileInfo = AppShell.Current.Items.Where(f => f.Route == nameof(StudentDashboardPagexaml)).FirstOrDefault();

            if(studentProfileInfo != null)
            {
                AppShell.Current.Items.Remove(studentProfileInfo);
            }

            var teacherProfileInfo = AppShell.Current.Items.Where(f => f.Route == nameof(TeacherDashboardPage)).FirstOrDefault();

            if (teacherProfileInfo != null)
            {
                AppShell.Current.Items.Remove(teacherProfileInfo);
            }

            var adminProfileInfo = AppShell.Current.Items.Where(f => f.Route == nameof(AdminDashboardPage)).FirstOrDefault();

            if (adminProfileInfo != null)
            {
                AppShell.Current.Items.Remove(adminProfileInfo);
            }

            if (App.UserDetails.RoleId == (int)RoleType.Student)
            {
                var flyoutItem = new FlyoutItem()
                {
                    Title = "Dashboard Page",
                    Route = nameof(StudentDashboardPagexaml),
                    FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                    Items =
                        {
                            new ShellContent
                            { 
                                Title = "Student Dashboard",
                                ContentTemplate = new DataTemplate(typeof(StudentDashboardPagexaml)),
                            },

                            new ShellContent
                            {
                                Title = "Student Profile",
                                ContentTemplate = new DataTemplate(typeof(StudentDashboardPagexaml)),
                            },
                        }
                };

                if (!Shell.Current.Items.Contains(flyoutItem))
                {
                    AppShell.Current.Items.Add(flyoutItem);
                    await Shell.Current.GoToAsync($"//{nameof(StudentDashboardPagexaml)}");
                }
            }


            if (App.UserDetails.RoleId == (int)RoleType.Teacher)
            {
                var flyoutItem = new FlyoutItem()
                {
                    Title = "Dashboard Page",
                    Route = nameof(TeacherDashboardPage),
                    FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                    Items =
                        {
                            new ShellContent
                            {
                                Title = "Teacher Dashboard",
                                ContentTemplate = new DataTemplate(typeof(TeacherDashboardPage)),
                            },

                            new ShellContent
                            {
                                Title = "Teacher Profile",
                                ContentTemplate = new DataTemplate(typeof(TeacherDashboardPage)),
                            },
                        }
                };

                if (!Shell.Current.Items.Contains(flyoutItem))
                {
                    AppShell.Current.Items.Add(flyoutItem);
                    await Shell.Current.GoToAsync($"//{nameof(TeacherDashboardPage)}");
                }
            }


            if (App.UserDetails.RoleId == (int)RoleType.Admin)
            {
                var flyoutItem = new FlyoutItem()
                {
                    Title = "Dashboard Page",
                    Route = nameof(AdminDashboardPage),
                    FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                    Items =
                        {
                            new ShellContent
                            {
                                Title = "Admin Dashboard",
                                ContentTemplate = new DataTemplate(typeof(AdminDashboardPage)),
                            },

                            new ShellContent
                            {
                                Title = "Admin Profile",
                                ContentTemplate = new DataTemplate(typeof(AdminDashboardPage)),
                            },
                        }
                };

                if (!Shell.Current.Items.Contains(flyoutItem))
                {
                    AppShell.Current.Items.Add(flyoutItem);
                    await Shell.Current.GoToAsync($"//{nameof(AdminDashboardPage)}");
                }
            }
        }
    }
}
