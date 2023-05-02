using EFCoreHW1.Data.DbContexts;
using EFCoreHW1.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EFCoreHW1.Views
{

    public partial class Home : Window
    {
        UniversityContext db;
        public Home()
        {
            InitializeComponent();


            db = new UniversityContext();
            //db.Groups.Load(); 
            Info_grid.ItemsSource = db.Students.Include(x => x.Group).ToList();
            GroupId_combo.ItemsSource = db.Groups.Local.ToBindingList();
            GroupId_combo.ItemsSource = db.Groups.Local.ToBindingList();
            this.Closing += Home_Closing;

        }
        private void Home_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }



        private void Add_btn_Click_1(object sender, RoutedEventArgs e)
        {
            if (Name_txt.Text != "" && Surame_txt.Text != "" && !GroupId_combo.Text.IsNullOrEmpty() )
            {
                db.Students.Add(new Student { Name = Name_txt.Text, Surname = Surame_txt.Text, GroupId = Int32.Parse(GroupId_combo.Text) });
                db.SaveChanges();
                Name_txt.Text = "";
                Surame_txt.Text = "";
                GroupId_combo.SelectedItem= null;
            }

            else MessageBox.Show("All fields are required");
        }

        private void Update_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Info_grid.SelectedItem != null && Info_grid.SelectedItems.Count == 1)
            {
                db.Students.Update((Student)Info_grid.SelectedItem);
                db.SaveChanges();
            }
            else MessageBox.Show("Select one row");

        }

        private void Delete_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Info_grid.SelectedItems.Count >= 0)
            {
                int count = Info_grid.SelectedItems.Count;
                for(int i = 0;i < count;i++)
                {
                    db.Students.Remove((Student)Info_grid.SelectedItems[0]);
                    db.SaveChanges();
                }
            }
            else MessageBox.Show("Select row(s)");

        }
    }
}
