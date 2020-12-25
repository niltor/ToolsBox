using DataHelper.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace DataHelper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "excel files (*.xlsx)|*.xlsx";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //Get the path of specified file
                    FilePath.Text = openFileDialog.FileName;
                    //Read the contents of the file into a stream


                }

            }
        }

        private async void button1_ClickAsync(object sender, RoutedEventArgs e)
        {
            button1.IsEnabled = false;
            // 读取内容
            var list = new List<WSUserDto>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            try
            {
                using (var package = new ExcelPackage(new FileInfo(FilePath.Text)))
                {
                    var sheet = package.Workbook.Worksheets.First();

                    int startRowNumber = sheet.Dimension.Start.Row + 2;
                    int endRowNumber = sheet.Dimension.End.Row;

                    int startColumn = sheet.Dimension.Start.Column;
                    int endColumn = sheet.Dimension.End.Column;

                    // 循环获取整个Excel数据表数据
                    for (int i = startRowNumber; i <= endRowNumber; i++)
                    {
                        list.Add(new WSUserDto
                        {
                            RealName = sheet.Cells[i, 2].Text.Trim(),
                            Phone = sheet.Cells[i, 3].Text.Trim(),
                            Province = sheet.Cells[i, 4].Text.Trim(),
                            City = sheet.Cells[i, 5].Text.Trim(),
                            RoleName = sheet.Cells[i, 6].Text.Trim(),
                        });
                    }
                }
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("请选择相对应的表格");
            }

            // 入库
            var helper = new WorkSafetyDBHelper(OutputMsg);
            await helper.InsertUsersAsync(list);
            button1.IsEnabled = true;
        }

        private async void button2_ClickAsync(object sender, RoutedEventArgs e)
        {
            button2.IsEnabled = false;
            // 读取内容
            var list = new List<PersonFileDto>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            try
            {
                using (var package = new ExcelPackage(new FileInfo(FilePath.Text)))
                {
                    var sheet = package.Workbook.Worksheets.First();

                    int startRowNumber = sheet.Dimension.Start.Row + 2;
                    int endRowNumber = sheet.Dimension.End.Row;
                    // 循环获取整个Excel数据表数据
                    for (int i = startRowNumber; i <= endRowNumber; i++)
                    {
                        var fulltime = sheet.Cells[i, 11].Text?.Trim();
                        var birthday = sheet.Cells[i, 8].Text?.Trim();
                        var getBirthday = false;
                        DateTime date = DateTime.Today;
                        if (birthday != null)
                        {
                            getBirthday = DateTime.TryParseExact(birthday, "yyyy/M/d", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
                        }
                        var contactRole = sheet.Cells[i, 14].Text?.Trim();
                        byte contactRoleIntValue = 0;
                        switch (contactRole)
                        {
                            case "安全生产分管领导":
                                contactRoleIntValue = 1;
                                break;
                            case "安监机构负责人":
                                contactRoleIntValue = 2;
                                break;
                            case "本部门负责安全生产领导":
                                contactRoleIntValue = 3;
                                break;
                            case "安全生产工作联系人":
                                contactRoleIntValue = 4;
                                break;
                            default:
                                break;
                        }

                        var personFile = new PersonFileDto
                        {
                            ProvinceName = sheet.Cells[i, 2].Text?.Trim(),
                            CityName = sheet.Cells[i, 3].Text?.Trim(),
                            OrgName = sheet.Cells[i, 4].Text?.Trim(),
                            RealName = sheet.Cells[i, 5].Text?.Trim(),
                            Sex = sheet.Cells[i, 6].Text?.Trim(),
                            Position = sheet.Cells[i, 7].Text?.Trim(),
                            Birthday = getBirthday ? date : DateTime.Today,
                            Number = sheet.Cells[i, 9].Text?.Trim(),
                            Education = sheet.Cells[i, 10].Text?.Trim(),
                            IsFulltime = (byte)(fulltime == "是" ? 1 : 0),
                            Phone = sheet.Cells[i, 12].Text?.Trim(),
                            Email = sheet.Cells[i, 13].Text?.Trim(),
                            ContactRole = contactRoleIntValue,
                            InternalPhone = sheet.Cells[i, 15].Text?.Trim(),
                            PublicPhone = sheet.Cells[i, 16].Text?.Trim(),
                            IsPartTime = 0
                        };

                        list.Add(personFile);
                    }
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                System.Windows.MessageBox.Show("解析错误，请选择相对应的表格");

            }
            // 入库
            var helper = new WorkSafetyDBHelper(OutputMsg);
            var task = helper.InsertPersonFileAsync(list);
            task.Wait();
            button2.IsEnabled = true;

        }

        private async void button3_ClickAsync(object sender, RoutedEventArgs e)
        {
            button3.IsEnabled = false;
            // 读取内容
            var list = new List<OrgInfoDto>();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(new FileInfo(FilePath.Text)))
            {
                var sheet = package.Workbook.Worksheets.First();

                int startRowNumber = sheet.Dimension.Start.Row + 2;
                int endRowNumber = sheet.Dimension.End.Row - 1;

                // 循环获取整个Excel数据表数据
                for (int i = startRowNumber; i <= endRowNumber; i++)
                {
                    var totalNumber = sheet.Cells[i, 23].Text?.Trim();
                    var mainFullTimeNumber = sheet.Cells[i, 24].Text?.Trim();
                    var mainPartTimeNumber = sheet.Cells[i, 25].Text?.Trim();

                    var orgInfoDto = new OrgInfoDto
                    {
                        OrgName = sheet.Cells[i, 1].Text?.Trim(),
                        Leader = sheet.Cells[i, 2].Text?.Trim(),
                        LeaderInnerPhone = sheet.Cells[i, 3].Text?.Trim(),
                        LeaderPublicPhone = sheet.Cells[i, 4].Text?.Trim(),
                        LeaderPhone = sheet.Cells[i, 5].Text?.Trim(),
                        LeaderEmail = sheet.Cells[i, 6].Text?.Trim(),
                        Name = sheet.Cells[i, 7].Text?.Trim(),
                        Principal = sheet.Cells[i, 8].Text?.Trim(),
                        PrincipalInnerPhone = sheet.Cells[i, 9].Text?.Trim(),
                        PrincipalPublicPhone = sheet.Cells[i, 10].Text?.Trim(),
                        PrincipalPhone = sheet.Cells[i, 11].Text?.Trim(),
                        PrincipalEmail = sheet.Cells[i, 12].Text?.Trim(),
                        PrincipalLeader = sheet.Cells[i, 13].Text?.Trim(),
                        PrincipalLeaderInnerPhone = sheet.Cells[i, 14].Text?.Trim(),
                        PrincipalLeaderPublicPhone = sheet.Cells[i, 15].Text?.Trim(),
                        PrincipalLeaderPhone = sheet.Cells[i, 16].Text?.Trim(),
                        PrincipalLeaderEmail = sheet.Cells[i, 17].Text?.Trim(),
                        Contact = sheet.Cells[i, 18].Text?.Trim(),
                        ContactInnerPhone = sheet.Cells[i, 19].Text?.Trim(),
                        ContactPublicPhone = sheet.Cells[i, 20].Text?.Trim(),
                        ContactPhone = sheet.Cells[i, 21].Text?.Trim(),
                        ContactEmail = sheet.Cells[i, 22].Text?.Trim(),
                        TotalNumber = Convert.ToInt32(totalNumber),
                        MainFullTimeNumber = Convert.ToInt32(mainFullTimeNumber),
                        MainPartTimeNumber = Convert.ToInt32(mainPartTimeNumber),
                    };

                    list.Add(orgInfoDto);
                }
            }
            // 入库
            var helper = new WorkSafetyDBHelper(OutputMsg);
            await helper.InsertOrgInfoAsync(list);
            button3.IsEnabled = true;


        }
    }
}
