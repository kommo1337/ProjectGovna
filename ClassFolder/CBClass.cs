using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ProjectKukushkin.ClassFolder
{
    class CBClass
    {
        SqlConnection sqlConnection = new SqlConnection(
             @"Data Source=DESKTOP-Q9BEC2K;Initial Catalog=Kukushkin;Integrated Security=True");
        SqlDataAdapter sqlData;
        DataSet dataSet;

        public enum CBType
        {
            Role,
            UserName,
            Mark
        }

        private void RoleCBLoad(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlData = new SqlDataAdapter("Select RoleId, RoleName " +
                    "From dbo.[Role] Order by RoleId ASC",
                    sqlConnection);
                dataSet = new DataSet();
                sqlData.Fill(dataSet, "[Role]");
                comboBox.ItemsSource = dataSet.Tables["[Role]"].DefaultView;
                comboBox.DisplayMemberPath = dataSet.
                    Tables["[Role]"].Columns["RoleName"].ToString();
                comboBox.SelectedValuePath = dataSet.
                   Tables["[Role]"].Columns["RoleId"].ToString();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }

        private void UserNameCBLoad(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlData = new SqlDataAdapter("Select UserId, UserName " +
                    "From dbo.[User] Order by UserId ASC",
                    sqlConnection);
                dataSet = new DataSet();
                sqlData.Fill(dataSet, "[User]");
                comboBox.ItemsSource = dataSet.Tables["[User]"].DefaultView;
                comboBox.DisplayMemberPath = dataSet.
                    Tables["[User]"].Columns["UserName"].ToString();
                comboBox.SelectedValuePath = dataSet.
                   Tables["[User]"].Columns["UserId"].ToString();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }
        private void MarkCBLoad(ComboBox comboBox)
        {
            try
            {
                sqlConnection.Open();
                sqlData = new SqlDataAdapter("Select CarId, Mark " +
                    "From dbo.[Car] Order by CarId ASC",
                    sqlConnection);
                dataSet = new DataSet();
                sqlData.Fill(dataSet, "[Car]");
                comboBox.ItemsSource = dataSet.Tables["[Car]"].DefaultView;
                comboBox.DisplayMemberPath = dataSet.
                    Tables["[Car]"].Columns["Mark"].ToString();
                comboBox.SelectedValuePath = dataSet.
                   Tables["[Car]"].Columns["CarId"].ToString();
            }
            catch (Exception ex)
            {
                MBClass.ErrorMB(ex);
            }
            finally
            {
                sqlConnection.Close();
            }
        }


        public void LoadCB(ComboBox comboBox, CBType type)
        {
            switch (type)
            {
                case CBType.Role:
                    RoleCBLoad(comboBox);
                    break;
                case CBType.UserName:
                    UserNameCBLoad(comboBox);
                    break;
                case CBType.Mark:
                    MarkCBLoad(comboBox);
                    break;
            }
        }
    }
}
